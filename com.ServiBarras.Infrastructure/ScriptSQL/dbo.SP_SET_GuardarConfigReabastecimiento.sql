-- =============================================================================
-- Guardado atómico (una sola transacción) de la configuración de reabastecimiento
-- de un producto: maestro (ConfigReabastecimientoProducto) + detalle
-- (ConfigReabastecimientoUbicacion).
--
--   @configReabastecimientoProductoId NULL  -> creación
--   @configReabastecimientoProductoId valor -> edición (ProductoId no cambia)
--
--   @ubicacionesJson: lista COMPLETA y final en el orden deseado, formato:
--       [{"ubicacionId":6377,"orden":1},{"ubicacionId":6378,"orden":2}]
--   El orden se renumera 1..N según la posición en el arreglo recibido.
--   Requiere SQL Server 2016+ (OPENJSON, compatibilidad >= 130).
--
-- Devuelve un result set con el contrato del endpoint:
--   exitoso (BIT) | mensaje (VARCHAR) | configReabastecimientoProductoId (BIGINT)
--   exitoso = 0 -> validación fallida (el API responde 400 con el mensaje)
-- Consumido por: POST /api/guardarConfigReabastecimiento
-- =============================================================================

CREATE PROCEDURE [dbo].[SP_SET_GuardarConfigReabastecimiento](
									@configReabastecimientoProductoId AS BIGINT = NULL,
									@productoId AS BIGINT,
									@cantidadMinima AS DECIMAL(18,4),
									@cantidadMaxima AS DECIMAL(18,4),
									@configToleranciaNotificacion AS DECIMAL(18,2),
									@usuarioId AS BIGINT,
									@ubicacionesJson AS NVARCHAR(MAX)
									)

AS
BEGIN

						SET XACT_ABORT ON;
						SET NOCOUNT ON
						BEGIN TRY
						BEGIN TRANSACTION guardarConfigReab

						SET DATEFORMAT YMD

						DECLARE @mensaje VARCHAR(300)
						DECLARE @esCreacion BIT = CASE WHEN @configReabastecimientoProductoId IS NULL OR @configReabastecimientoProductoId = 0 THEN 1 ELSE 0 END

						------------------------------------------------------------------
						-- Parseo del arreglo de ubicaciones, renumerando orden = 1..N
						-- según la posición en el arreglo recibido ([key] de OPENJSON).
						------------------------------------------------------------------
						DECLARE @ubicaciones TABLE (
							 [ubicacionId]	BIGINT NOT NULL
							,[orden]		INT NOT NULL
						)

						INSERT INTO @ubicaciones ([ubicacionId], [orden])
						SELECT		CONVERT(BIGINT, JSON_VALUE(j.[value], '$.ubicacionId'))
								  ,ROW_NUMBER() OVER (ORDER BY CONVERT(INT, j.[key]) ASC)
						FROM		OPENJSON(@ubicacionesJson) AS j

						------------------------------------------------------------------
						-- Validaciones de servidor (exitoso = 0 -> el API responde 400)
						------------------------------------------------------------------
						IF @productoId IS NULL OR NOT EXISTS (SELECT 1 FROM [dbo].[Productos] p WHERE p.[productoId] = @productoId)
						BEGIN
							SET @mensaje = 'El producto no existe'
							GOTO ValidacionFallida
						END

						IF @cantidadMinima IS NULL OR @cantidadMinima < 0
						BEGIN
							SET @mensaje = 'La cantidad mínima debe ser mayor o igual a 0'
							GOTO ValidacionFallida
						END

						IF @cantidadMaxima IS NULL OR @cantidadMaxima <= @cantidadMinima
						BEGIN
							SET @mensaje = 'La cantidad máxima debe ser mayor que la cantidad mínima'
							GOTO ValidacionFallida
						END

						IF @configToleranciaNotificacion IS NULL OR @configToleranciaNotificacion < 0
						BEGIN
							SET @mensaje = 'La tolerancia de notificación debe ser mayor o igual a 0'
							GOTO ValidacionFallida
						END

						IF NOT EXISTS (SELECT 1 FROM @ubicaciones)
						BEGIN
							SET @mensaje = 'Debe asignar al menos una ubicación'
							GOTO ValidacionFallida
						END

						IF EXISTS (
							SELECT		[ubicacionId]
							FROM		@ubicaciones
							GROUP BY	[ubicacionId]
							HAVING		COUNT(*) > 1
						)
						BEGIN
							SET @mensaje = 'La lista contiene ubicaciones repetidas'
							GOTO ValidacionFallida
						END

						-- Todas las ubicaciones deben existir y ser elegibles
						-- (mismo criterio de SP_GET_UbicacionesReabastecimiento)
						IF EXISTS (
							SELECT		1
							FROM		@ubicaciones AS t
							LEFT JOIN	[dbo].[Ubicaciones] AS u
										ON u.[ubicacionId] = t.[ubicacionId]
										AND u.[ubicacionEstado] = 1
							WHERE		u.[ubicacionId] IS NULL
						)
						BEGIN
							SET @mensaje = 'Una o más ubicaciones no existen o no están vigentes para el proceso'
							GOTO ValidacionFallida
						END

						------------------------------------------------------------------
						-- CREACIÓN
						------------------------------------------------------------------
						IF @esCreacion = 1
						BEGIN
							IF EXISTS (
								SELECT		1
								FROM		[dbo].[ConfigReabastecimientoProducto] crp
								WHERE		crp.[ProductoId] = @productoId
								AND			crp.[Activo] = 1
							)
							BEGIN
								SET @mensaje = 'El producto ya tiene una configuración de reabastecimiento activa'
								GOTO ValidacionFallida
							END

							INSERT INTO [dbo].[ConfigReabastecimientoProducto] (
								   [ProductoId]
								  ,[CantidadMinima]
								  ,[CantidadMaxima]
								  ,[ConfigToleranciaNotificacion]
								  ,[Activo]
								  ,[FechaCreacion]
								  ,[UsuarioIdCreacion]
							)
							VALUES (
								   @productoId
								  ,@cantidadMinima
								  ,@cantidadMaxima
								  ,@configToleranciaNotificacion
								  ,1
								  ,GETDATE()
								  ,@usuarioId
							)

							SET @configReabastecimientoProductoId = SCOPE_IDENTITY()

							INSERT INTO [dbo].[ConfigReabastecimientoUbicacion] (
								   [ProductoId]
								  ,[UbicacionId]
								  ,[orden]
								  ,[Activo]
								  ,[FechaCreacion]
								  ,[UsuarioIdCreacion]
							)
							SELECT		 @productoId
										,t.[ubicacionId]
										,t.[orden]
										,1
										,GETDATE()
										,@usuarioId
							FROM		@ubicaciones AS t
						END
						------------------------------------------------------------------
						-- EDICIÓN
						------------------------------------------------------------------
						ELSE
						BEGIN
							-- La configuración debe existir y estar activa.
							-- ProductoId NO cambia en edición: se toma el del maestro.
							DECLARE @productoIdActual BIGINT = NULL

							SELECT		@productoIdActual = crp.[ProductoId]
							FROM		[dbo].[ConfigReabastecimientoProducto] crp
							WHERE		crp.[ConfigReabastecimientoProductoId] = @configReabastecimientoProductoId
							AND			crp.[Activo] = 1

							IF @productoIdActual IS NULL
							BEGIN
								SET @mensaje = 'La configuración no existe o ya fue inactivada'
								GOTO ValidacionFallida
							END

							UPDATE		[dbo].[ConfigReabastecimientoProducto]
							SET			 [CantidadMinima] = @cantidadMinima
										,[CantidadMaxima] = @cantidadMaxima
										,[ConfigToleranciaNotificacion] = @configToleranciaNotificacion
										,[FechaModificacion] = GETDATE()
										,[UsuarioIdModificacion] = @usuarioId
							WHERE		[ConfigReabastecimientoProductoId] = @configReabastecimientoProductoId

							-- 1) Filas activas cuya UbicacionId NO viene en la lista -> Activo = 0
							UPDATE		cru
							SET			 cru.[Activo] = 0
										,cru.[FechaModificacion] = GETDATE()
										,cru.[UsuarioIdModificacion] = @usuarioId
							FROM		[dbo].[ConfigReabastecimientoUbicacion] AS cru
							WHERE		cru.[ProductoId] = @productoIdActual
							AND			cru.[Activo] = 1
							AND	NOT EXISTS (
										SELECT	1
										FROM	@ubicaciones AS t
										WHERE	t.[ubicacionId] = cru.[UbicacionId]
									)

							-- 2) UbicacionId que viene y ya existe activa -> actualizar su orden
							UPDATE		cru
							SET			 cru.[orden] = t.[orden]
										,cru.[FechaModificacion] = GETDATE()
										,cru.[UsuarioIdModificacion] = @usuarioId
							FROM		[dbo].[ConfigReabastecimientoUbicacion] AS cru
							INNER JOIN	@ubicaciones AS t
										ON t.[ubicacionId] = cru.[UbicacionId]
							WHERE		cru.[ProductoId] = @productoIdActual
							AND			cru.[Activo] = 1

							-- 3) UbicacionId que viene y no existe activa -> insertar fila nueva
							INSERT INTO [dbo].[ConfigReabastecimientoUbicacion] (
								   [ProductoId]
								  ,[UbicacionId]
								  ,[orden]
								  ,[Activo]
								  ,[FechaCreacion]
								  ,[UsuarioIdCreacion]
							)
							SELECT		 @productoIdActual
										,t.[ubicacionId]
										,t.[orden]
										,1
										,GETDATE()
										,@usuarioId
							FROM		@ubicaciones AS t
							WHERE	NOT EXISTS (
										SELECT	1
										FROM	[dbo].[ConfigReabastecimientoUbicacion] AS cru
										WHERE	cru.[ProductoId] = @productoIdActual
										AND		cru.[UbicacionId] = t.[ubicacionId]
										AND		cru.[Activo] = 1
									)
						END

						COMMIT TRANSACTION guardarConfigReab

						SELECT		 CONVERT(BIT, 1)					AS [exitoso]
									,'Configuración guardada correctamente' AS [mensaje]
									,@configReabastecimientoProductoId	AS [configReabastecimientoProductoId]
						RETURN

						------------------------------------------------------------------
						-- Salida de validación fallida (el API traduce a HTTP 400)
						------------------------------------------------------------------
						ValidacionFallida:
						ROLLBACK TRANSACTION guardarConfigReab

						SELECT		 CONVERT(BIT, 0)	AS [exitoso]
									,@mensaje			AS [mensaje]
									,CONVERT(BIGINT, NULL) AS [configReabastecimientoProductoId]
						RETURN

						END TRY

						BEGIN CATCH

							IF @@TRANCOUNT > 0
								ROLLBACK TRANSACTION guardarConfigReab;

							SELECT		 CONVERT(BIT, 0)		AS [exitoso]
										,ERROR_MESSAGE()		AS [mensaje]
										,CONVERT(BIGINT, NULL)	AS [configReabastecimientoProductoId]

						END CATCH
END
