using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class Saldos
    {
        public Saldos()
        {
            SaldosDetalle = new HashSet<SaldosDetalle>();
            SaldosUbicaciones = new HashSet<SaldosUbicaciones>();
        }

        public long saldoId { get; set; }
        public long productoId { get; set; }
        public decimal? saldoComprometidoManejo { get; set; }
        public decimal? saldoInmovilizadoManejo { get; set; }
        public decimal? saldoRealManejo { get; set; }
        public decimal? saldoDisponibleManejo { get; set; }
        public decimal? saldoComprometidoEscalar { get; set; }
        public decimal? saldoInmovilizadoEscalar { get; set; }
        public decimal? saldoRealEscalar { get; set; }
        public decimal? saldoDisponibleEscalar { get; set; }
        public long centroGestionId { get; set; }
        public byte separaSaldo { get; set; }

        public virtual Productos producto { get; set; }
        public virtual ICollection<SaldosDetalle> SaldosDetalle { get; set; }
        public virtual ICollection<SaldosUbicaciones> SaldosUbicaciones { get; set; }
    }
}
