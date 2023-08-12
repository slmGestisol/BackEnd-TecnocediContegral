using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class OrdenesEmpaque
    {
        public long ordenEmpaqueId { get; set; }
        public long documentoId { get; set; }
        public int ordenEmpaqueConsecutivo { get; set; }
        public long productoId { get; set; }
        public DateTime ordenEmpaqueFechaCreacion { get; set; }
        public DateTime? ordenEmpaqueFechaFinalizacion { get; set; }
        public int? ordenEmpaqueNumeroUnidades { get; set; }
        public byte ordenEmpaqueEstado { get; set; }
        public long estacionId { get; set; }
        public int ordenEmpaqueEvaluacionIdOE { get; set; }
        public long puntoOperacionId { get; set; }
        public int? ordenEmpaqueUnidadesImpresas { get; set; }
        public long? presentacionId { get; set; }
        public long? novedadId { get; set; }
        public long? usuarioId { get; set; }
        public DateTime? ordenEmpaqueFechaNovedad { get; set; }
        public int? ordenEmpaqueGramaje { get; set; }
        public string ordenEmpaqueClientePreferente { get; set; }
        public long? estacionIdSalidaordenEmpaque { get; set; }
        public int? ordenEmpaqueNumeroUbicacion { get; set; }

        public virtual Documentos documento { get; set; }
        public virtual Estaciones estacion { get; set; }
        public virtual Novedades novedad { get; set; }
        public virtual Presentaciones presentacion { get; set; }
        public virtual Productos producto { get; set; }
        public virtual PuntosOperaciones puntoOperacion { get; set; }
        public virtual Usuarios usuario { get; set; }
    }
}
