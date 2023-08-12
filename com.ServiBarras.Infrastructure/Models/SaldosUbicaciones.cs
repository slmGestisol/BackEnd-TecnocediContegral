using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class SaldosUbicaciones
    {
        public SaldosUbicaciones()
        {
            PreRuteosDetalle = new HashSet<PreRuteosDetalle>();
        }

        public long saldoUbicacionId { get; set; }
        public long saldoId { get; set; }
        public long ubicacionId { get; set; }
        public decimal? saldoUbicacionRealManejo { get; set; }
        public decimal? saldoUbicacionComprometidoManejo { get; set; }
        public decimal? saldoUbicacionInmovilizadoManejo { get; set; }
        public decimal? saldoUbicacionRealEscalar { get; set; }
        public decimal? saldoUbicacionDisponibleManejo { get; set; }
        public decimal? saldoUbicacionComprometidoEscalar { get; set; }
        public decimal? saldoUbicacionInmovilizadoEscalar { get; set; }
        public decimal? saldoUbicacionDisponibleEscalar { get; set; }

        public virtual Saldos saldo { get; set; }
        public virtual Ubicaciones ubicacion { get; set; }
        public virtual ICollection<PreRuteosDetalle> PreRuteosDetalle { get; set; }
    }
}
