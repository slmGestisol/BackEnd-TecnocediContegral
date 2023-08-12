using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class TxOrdenEmpaque
    {
        public long txOrdenEmpaqueId { get; set; }
        public int txOrdenEmpaqueConcepto { get; set; }
        public long txOrdenEmpaqueConsecutivo { get; set; }
        public long? ordenEmpaqueId { get; set; }
        public long? presentacionId { get; set; }
        public long? identificacionId { get; set; }
        public long? contenedorId { get; set; }
        public long? valorProductoLoteId { get; set; }
        public long ubicacionId { get; set; }
        public long? estacionId { get; set; }
        public long bodegaLogicaId { get; set; }
        public decimal? txOrdenEmpaqueRealManejo { get; set; }
        public decimal? txOrdenEmpaqueRealEscalar { get; set; }
        public long? novedadId { get; set; }
        public long? saldoId { get; set; }
        public long? saldoDetalleId { get; set; }
        public long? documentoId { get; set; }
        public byte txOrdenEmpaqueEstado { get; set; }
        public long? txOrdenEmpaqueParentId { get; set; }
        public DateTime? txOrdenEmpaqueFechaCreacion { get; set; }
        public DateTime? txOrdenEmpaqueFechaModificacion { get; set; }
        public long? usuarioId { get; set; }
        public string txOrdenEmpaquePlano { get; set; }
        public DateTime? txOrdenEmpaqueFechaCierre { get; set; }
        public int? txOrdenEmpaqueTurno { get; set; }

        public virtual Contenedores contenedor { get; set; }
    }
}
