-- =============================================================================
-- Inactivación definitiva de una configuración de reabastecimiento (sin
-- reactivación posible; volver a configurar el producto crea registros nuevos).
-- En una sola transacción:
--   - Maestro:  Activo = 0 + fecha/usuario de modificación
--   - Detalle:  todas sus filas activas de ConfigReabastecimientoUbicacion
--               (por ProductoId) -> Activo = 0 + fecha/usuario de modificación
--
-- Devuelve un result set con el contrato del endpoint:
--   exitoso (BIT) | mensaje (VARCHAR)
--   exitoso = 0 -> validación fallida (el API responde 400 con el mensaje)
-- Consumido por: POST /api/inactivarConfigReabastecimiento
-- =============================================================================

CREATE PROCEDURE [dbo].[SP_SET_InactivarConfigReabastecimiento](
									@configReabastecimientoProductoId AS BIGINT,
									@usuarioId AS BIGINT
									)

AS
BEGIN

						SET XACT_ABORT ON;
						SET NOCOUNT ON
						BEGIN TRY
						BEGIN TRANSACTION inactivarConfigReab

						SET DATEFORMAT YMD

						DECLARE @productoId BIGINT = NULL

						-- Debe existir y estar activa
						SELECT		@productoId = crp.[ProductoId]
						FROM		[dbo].[ConfigReabastecimientoProducto] crp
						WHERE		crp.[ConfigReabastecimientoProductoId] = @configReabastecimientoProductoId
						AND			crp.[Activo] = 1

						IF @productoId IS NULL
						BEGIN
							ROLLBACK TRANSACTION inactivarConfigReab

							SELECT		 CONVERT(BIT, 0) AS [exitoso]
										,'La configuración no existe o ya fue inactivada' AS [mensaje]
							RETURN
						END

						-- Maestro
						UPDATE		[dbo].[ConfigReabastecimientoProducto]
						SET			 [Activo] = 0
									,[FechaModificacion] = GETDATE()
									,[UsuarioIdModificacion] = @usuarioId
						WHERE		[ConfigReabastecimientoProductoId] = @configReabastecimientoProductoId

						-- Detalle en cascada (todas las filas activas del producto)
						UPDATE		cru
						SET			 cru.[Activo] = 0
									,cru.[FechaModificacion] = GETDATE()
									,cru.[UsuarioIdModificacion] = @usuarioId
						FROM		[dbo].[ConfigReabastecimientoUbicacion] AS cru
						WHERE		cru.[ProductoId] = @productoId
						AND			cru.[Activo] = 1

						COMMIT TRANSACTION inactivarConfigReab

						SELECT		 CONVERT(BIT, 1) AS [exitoso]
									,'Configuración inactivada correctamente' AS [mensaje]

						END TRY

						BEGIN CATCH

							IF @@TRANCOUNT > 0
								ROLLBACK TRANSACTION inactivarConfigReab;

							SELECT		 CONVERT(BIT, 0)	AS [exitoso]
										,ERROR_MESSAGE()	AS [mensaje]

						END CATCH
END
