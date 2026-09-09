-- =============================================================================
-- Productos elegibles para crear una configuración de reabastecimiento nueva:
-- productos activos (productoEstado = 1) que NO tienen una configuración activa
-- en ConfigReabastecimientoProducto. Garantiza un solo registro activo por producto.
-- Consumido por: GET /api/getProductosSinConfigReabastecimiento
-- =============================================================================

CREATE PROCEDURE [dbo].[SP_GET_ProductosSinConfigReabastecimiento]

AS
BEGIN
	SET NOCOUNT ON

	SELECT				p.[productoId]				AS [productoId]
					  ,p.[productoCodigo]			AS [productoCodigo]
					  ,p.[productoDescripcion]		AS [productoDescripcion]
	FROM				[dbo].[Productos] AS p
	WHERE				p.[productoEstado] = 1
	AND	NOT EXISTS	(
						SELECT		1
						FROM		[dbo].[ConfigReabastecimientoProducto] AS crp
						WHERE		crp.[ProductoId] = p.[productoId]
						AND			crp.[Activo] = 1
					)
	ORDER BY			p.[productoDescripcion] ASC
END
