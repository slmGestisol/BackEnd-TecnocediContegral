-- =============================================================================
-- Lista las configuraciones de reabastecimiento activas con datos del producto,
-- para la tabla maestro del panel de parametrización.
-- Consumido por: GET /api/getConfigReabastecimiento
-- =============================================================================

CREATE PROCEDURE [dbo].[SP_GET_ConfigReabastecimiento]

AS
BEGIN
	SET NOCOUNT ON

	SELECT				crp.[ConfigReabastecimientoProductoId]	AS [configReabastecimientoProductoId]
					  ,p.[productoId]							AS [productoId]
					  ,p.[productoCodigo]						AS [productoCodigo]
					  ,p.[productoDescripcion]					AS [productoDescripcion]
					  ,crp.[CantidadMinima]						AS [cantidadMinima]
					  ,crp.[CantidadMaxima]						AS [cantidadMaxima]
					  ,crp.[ConfigToleranciaNotificacion]		AS [configToleranciaNotificacion]
					  ,ISNULL(cru.[totalUbicaciones], 0)		AS [totalUbicaciones]
					  ,crp.[FechaCreacion]						AS [fechaCreacion]
	FROM				[dbo].[ConfigReabastecimientoProducto] AS crp
	INNER JOIN			[dbo].[Productos] AS p
						ON p.[productoId] = crp.[ProductoId]
	OUTER APPLY		(
						-- Conteo de ubicaciones activas parametrizadas al producto
						SELECT		COUNT(*) AS [totalUbicaciones]
						FROM		[dbo].[ConfigReabastecimientoUbicacion] AS d
						WHERE		d.[ProductoId] = crp.[ProductoId]
						AND			d.[Activo] = 1
					) AS cru
	WHERE				crp.[Activo] = 1
	ORDER BY			p.[productoDescripcion] ASC
END
