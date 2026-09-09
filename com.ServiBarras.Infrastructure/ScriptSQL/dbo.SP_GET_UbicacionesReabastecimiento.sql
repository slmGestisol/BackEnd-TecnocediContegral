-- =============================================================================
-- Ubicaciones elegibles para asignar al proceso de reabastecimiento.
-- Criterio de elegibilidad (definido por backend):
--   - ubicacionEstado = 1 (ubicación vigente)
-- NOTA: una misma ubicación puede estar asignada a varios productos, por lo que
-- NO se excluyen las ya usadas en otras configuraciones.
-- Si el proceso requiere acotar más (p. ej. por tipoUbicacionId o instalacionId),
-- agregar el filtro aquí; el frontend sólo consume la lista.
-- Consumido por: GET /api/getUbicacionesReabastecimiento
-- =============================================================================

CREATE PROCEDURE [dbo].[SP_GET_UbicacionesReabastecimiento]

AS
BEGIN
	SET NOCOUNT ON

	SELECT				u.[ubicacionId]				AS [ubicacionId]
					  ,u.[ubicacionCodigo]			AS [ubicacionCodigo]
					  ,u.[ubicacionEtiqueta]		AS [ubicacionEtiqueta]
					  ,u.[ubicacionDescripcion]		AS [ubicacionDescripcion]
	FROM				[dbo].[Ubicaciones] AS u
	WHERE				u.[ubicacionEstado] = 1
	ORDER BY			u.[ubicacionCodigo] ASC
END
