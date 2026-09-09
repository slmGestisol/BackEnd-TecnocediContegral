-- =============================================================================
-- Configuración completa de un producto (maestro + ubicaciones activas) para el
-- panel de edición. Devuelve DOS result sets:
--   1) Maestro (una fila; vacío si el id no existe o está inactivo)
--   2) Ubicaciones activas del producto, ordenadas por [orden] ascendente
-- Consumido por: GET /api/getConfigReabastecimientoDetalle/{configReabastecimientoProductoId}
-- =============================================================================

CREATE PROCEDURE [dbo].[SP_GET_ConfigReabastecimientoDetalle](
									@configReabastecimientoProductoId AS BIGINT
									)

AS
BEGIN
	SET NOCOUNT ON

	DECLARE @productoId BIGINT = NULL

	SELECT				@productoId = crp.[ProductoId]
	FROM				[dbo].[ConfigReabastecimientoProducto] AS crp
	WHERE				crp.[ConfigReabastecimientoProductoId] = @configReabastecimientoProductoId
	AND					crp.[Activo] = 1

	-- Result set 1: maestro
	SELECT				crp.[ConfigReabastecimientoProductoId]	AS [configReabastecimientoProductoId]
					  ,p.[productoId]							AS [productoId]
					  ,p.[productoCodigo]						AS [productoCodigo]
					  ,p.[productoDescripcion]					AS [productoDescripcion]
					  ,crp.[CantidadMinima]						AS [cantidadMinima]
					  ,crp.[CantidadMaxima]						AS [cantidadMaxima]
					  ,crp.[ConfigToleranciaNotificacion]		AS [configToleranciaNotificacion]
	FROM				[dbo].[ConfigReabastecimientoProducto] AS crp
	INNER JOIN			[dbo].[Productos] AS p
						ON p.[productoId] = crp.[ProductoId]
	WHERE				crp.[ConfigReabastecimientoProductoId] = @configReabastecimientoProductoId
	AND					crp.[Activo] = 1

	-- Result set 2: ubicaciones activas del producto
	SELECT				cru.[ConfigReabastecimientoUbicacionId]	AS [configReabastecimientoUbicacionId]
					  ,u.[ubicacionId]							AS [ubicacionId]
					  ,u.[ubicacionCodigo]						AS [ubicacionCodigo]
					  ,cru.[orden]								AS [orden]
	FROM				[dbo].[ConfigReabastecimientoUbicacion] AS cru
	INNER JOIN			[dbo].[Ubicaciones] AS u
						ON u.[ubicacionId] = cru.[UbicacionId]
	WHERE				cru.[ProductoId] = @productoId
	AND					cru.[Activo] = 1
	ORDER BY			cru.[orden] ASC
END
