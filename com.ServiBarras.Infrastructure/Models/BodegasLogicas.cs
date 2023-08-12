using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class BodegasLogicas
    {
        public BodegasLogicas()
        {
            DocumentosbodegaLogica = new HashSet<Documentos>();
            DocumentosbodegaLogicaCombo = new HashSet<Documentos>();
            Estaciones = new HashSet<Estaciones>();
            PreRuteosDetalle = new HashSet<PreRuteosDetalle>();
            RuteosDetalle = new HashSet<RuteosDetalle>();
            SaldosDetalle = new HashSet<SaldosDetalle>();
            TXPacking = new HashSet<TXPacking>();
            TXPicking = new HashSet<TXPicking>();
            TxCalidadUbicaciones = new HashSet<TxCalidadUbicaciones>();
            TxDespacho = new HashSet<TxDespacho>();
            TxDevolucion = new HashSet<TxDevolucion>();
            TxInventario = new HashSet<TxInventario>();
            TxReubicacion = new HashSet<TxReubicacion>();
        }

        public long bodegaLogicaId { get; set; }
        public byte bodegaLogicaEstado { get; set; }
        public long bodegaErpId { get; set; }
        public string bodegaLogicaCodigo { get; set; }
        public string bodegaLogicaDescripcion { get; set; }

        public virtual BodegasERP bodegaErp { get; set; }
        public virtual ICollection<Documentos> DocumentosbodegaLogica { get; set; }
        public virtual ICollection<Documentos> DocumentosbodegaLogicaCombo { get; set; }
        public virtual ICollection<Estaciones> Estaciones { get; set; }
        public virtual ICollection<PreRuteosDetalle> PreRuteosDetalle { get; set; }
        public virtual ICollection<RuteosDetalle> RuteosDetalle { get; set; }
        public virtual ICollection<SaldosDetalle> SaldosDetalle { get; set; }
        public virtual ICollection<TXPacking> TXPacking { get; set; }
        public virtual ICollection<TXPicking> TXPicking { get; set; }
        public virtual ICollection<TxCalidadUbicaciones> TxCalidadUbicaciones { get; set; }
        public virtual ICollection<TxDespacho> TxDespacho { get; set; }
        public virtual ICollection<TxDevolucion> TxDevolucion { get; set; }
        public virtual ICollection<TxInventario> TxInventario { get; set; }
        public virtual ICollection<TxReubicacion> TxReubicacion { get; set; }
    }
}
