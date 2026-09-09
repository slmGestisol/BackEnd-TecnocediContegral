using System;

namespace com.ServiBarras.Infrastructure.ModelDTO
{
    /// <summary>
    /// Fila de la grilla del módulo de parametrización de novedades
    /// (resultado de sp_GET_novedades). Incluye procesoNombre para
    /// mostrarlo en el front sin joins adicionales.
    /// </summary>
    public class NovedadItemDto
    {
        public int novedadId { get; set; }

        public string novedadCodigo { get; set; }

        public string novedadNombre { get; set; }

        public string novedadDescripcion { get; set; }

        public int procesoId { get; set; }

        public string procesoNombre { get; set; }

        public bool novedadActivo { get; set; }

        public DateTime? novedadFechaModificacion { get; set; }

        public int? novedadUsuarioIdModificacion { get; set; }
    }

    public class NovedadDto
    {
        public long novedadId { get; set; }
        public string novedadDescripcion { get; set; }
        public string novedadCodigo { get; set; }
        public string novedadNombre { get; set; }
        public string novedadAfectaSaldo { get; set; }
    }
}
