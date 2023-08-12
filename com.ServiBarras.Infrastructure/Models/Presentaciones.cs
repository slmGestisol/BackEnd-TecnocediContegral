using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class Presentaciones
    {
        public Presentaciones()
        {
            DespachosDetalle = new HashSet<DespachosDetalle>();
            Identificaciones = new HashSet<Identificaciones>();
            Inventarios = new HashSet<Inventarios>();
            OrdenesEmpaque = new HashSet<OrdenesEmpaque>();
            PackingDetalle = new HashSet<PackingDetalle>();
            PedidosDetalle = new HashSet<PedidosDetalle>();
            PreRuteosDetalle = new HashSet<PreRuteosDetalle>();
            PresentacionesClasificacion = new HashSet<PresentacionesClasificacion>();
            ProductosCombospresentacionIdComboNavigation = new HashSet<ProductosCombos>();
            ProductosCombospresentacionIdDestinoNavigation = new HashSet<ProductosCombos>();
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

        public long presentacionId { get; set; }
        public string presentacionCodigo { get; set; }
        public string presentacionDescripcion { get; set; }
        public int presentacionNumUnidad { get; set; }
        public byte presentacionManejaTecnico { get; set; }
        public decimal? presentacionAncho { get; set; }
        public decimal? presentacionAlto { get; set; }
        public decimal? presentacionProfundidad { get; set; }
        public decimal? presentacionPesoBruto { get; set; }
        public decimal? presentacionPesoNeto { get; set; }
        public decimal? presentacionVolumen { get; set; }
        public short? presentacionOrden { get; set; }
        public byte presentacionEsUnidadDespacho { get; set; }
        public byte presentacionEstado { get; set; }
        public long? longitudEscalarId { get; set; }
        public long? pesoEscalarId { get; set; }
        public long? volumenEscalarId { get; set; }
        public long productoId { get; set; }
        public int? Estiba { get; set; }

        public virtual UnidadesEscalares longitudEscalar { get; set; }
        public virtual UnidadesEscalares pesoEscalar { get; set; }
        public virtual Productos producto { get; set; }
        public virtual UnidadesEscalares volumenEscalar { get; set; }
        public virtual ICollection<DespachosDetalle> DespachosDetalle { get; set; }
        public virtual ICollection<Identificaciones> Identificaciones { get; set; }
        public virtual ICollection<Inventarios> Inventarios { get; set; }
        public virtual ICollection<OrdenesEmpaque> OrdenesEmpaque { get; set; }
        public virtual ICollection<PackingDetalle> PackingDetalle { get; set; }
        public virtual ICollection<PedidosDetalle> PedidosDetalle { get; set; }
        public virtual ICollection<PreRuteosDetalle> PreRuteosDetalle { get; set; }
        public virtual ICollection<PresentacionesClasificacion> PresentacionesClasificacion { get; set; }
        public virtual ICollection<ProductosCombos> ProductosCombospresentacionIdComboNavigation { get; set; }
        public virtual ICollection<ProductosCombos> ProductosCombospresentacionIdDestinoNavigation { get; set; }
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
