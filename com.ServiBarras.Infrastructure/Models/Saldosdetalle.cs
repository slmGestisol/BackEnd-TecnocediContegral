using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class SaldosDetalle
    {
        public long saldoDetalleId { get; set; }
        public long saldoId { get; set; }
        public long presentacionId { get; set; }
        public long contenedorId { get; set; }
        public long valorProductoLoteId { get; set; }
        public long ubicacionId { get; set; }
        public long bodegaLogicaId { get; set; }
        public decimal? saldoDetalleRealManejo { get; set; }
        public decimal? saldoDetalleComprometidoManejo { get; set; }
        public decimal? saldoDetalleInmovilizadoManejo { get; set; }
        public decimal? saldoDetalleRealEscalar { get; set; }
        public decimal? saldoDetalleDisponibleManejo { get; set; }
        public decimal? saldoDetalleComprometidoEscalar { get; set; }
        public decimal? saldoDetalleInmovilizadoEscalar { get; set; }
        public decimal? saldoDetalleDisponibleEscalar { get; set; }
        public string updatesSecuencia { get; set; }

        public virtual BodegasLogicas bodegaLogica { get; set; }
        public virtual Contenedores contenedor { get; set; }
        public virtual Presentaciones presentacion { get; set; }
        public virtual Saldos saldo { get; set; }
        public virtual Ubicaciones ubicacion { get; set; }
        public virtual ValoresPlantillasLotes valorProductoLote { get; set; }
    }
}
