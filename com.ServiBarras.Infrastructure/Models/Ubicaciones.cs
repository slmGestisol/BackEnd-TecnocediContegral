using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class Ubicaciones
    {
        public Ubicaciones()
        {
            DespachosDetalle = new HashSet<DespachosDetalle>();
            Inventarios = new HashSet<Inventarios>();
            PackingDetalle = new HashSet<PackingDetalle>();
            PreRuteosDetalle = new HashSet<PreRuteosDetalle>();
            RuteosDetalle = new HashSet<RuteosDetalle>();
            SaldosDetalle = new HashSet<SaldosDetalle>();
            SaldosUbicaciones = new HashSet<SaldosUbicaciones>();
            TXPacking = new HashSet<TXPacking>();
            TXPicking = new HashSet<TXPicking>();
            TxCalidadUbicaciones = new HashSet<TxCalidadUbicaciones>();
            TxDespacho = new HashSet<TxDespacho>();
            TxDevolucion = new HashSet<TxDevolucion>();
            TxInventario = new HashSet<TxInventario>();
            TxReubicacion = new HashSet<TxReubicacion>();
            UbicacionesCambioAutomatico = new HashSet<UbicacionesCambioAutomatico>();
            UbicacionesProductos = new HashSet<UbicacionesProductos>();
        }

        public long ubicacionId { get; set; }
        public string ubicacionCodigo { get; set; }
        public string ubicacionEtiqueta { get; set; }
        public string ubicacionDescripcion { get; set; }
        public byte ubicacionEstado { get; set; }
        public long? ubicacionFisicaId { get; set; }
        public int? tipoUbicacionId { get; set; }
        public long? ubicacionPadreId { get; set; }
        public byte? ubicacionRuteoEstado { get; set; }
        public byte? ubicacionDisponible { get; set; }
        public string ubicacionColumna { get; set; }
        public long? estacionId { get; set; }
        public bool? ubicacionDespacho { get; set; }
        public long? novedadId { get; set; }
        public long? instalacionId { get; set; }
        public int? ubicacionSecuencia { get; set; }
        public bool? EstadoSecuencia { get; set; }

        public virtual Instalaciones instalacion { get; set; }
        public virtual TiposUbicaciones tipoUbicacion { get; set; }
        public virtual UbicacionesFisicas ubicacionFisica { get; set; }
        public virtual ICollection<DespachosDetalle> DespachosDetalle { get; set; }
        public virtual ICollection<Inventarios> Inventarios { get; set; }
        public virtual ICollection<PackingDetalle> PackingDetalle { get; set; }
        public virtual ICollection<PreRuteosDetalle> PreRuteosDetalle { get; set; }
        public virtual ICollection<RuteosDetalle> RuteosDetalle { get; set; }
        public virtual ICollection<SaldosDetalle> SaldosDetalle { get; set; }
        public virtual ICollection<SaldosUbicaciones> SaldosUbicaciones { get; set; }
        public virtual ICollection<TXPacking> TXPacking { get; set; }
        public virtual ICollection<TXPicking> TXPicking { get; set; }
        public virtual ICollection<TxCalidadUbicaciones> TxCalidadUbicaciones { get; set; }
        public virtual ICollection<TxDespacho> TxDespacho { get; set; }
        public virtual ICollection<TxDevolucion> TxDevolucion { get; set; }
        public virtual ICollection<TxInventario> TxInventario { get; set; }
        public virtual ICollection<TxReubicacion> TxReubicacion { get; set; }
        public virtual ICollection<UbicacionesCambioAutomatico> UbicacionesCambioAutomatico { get; set; }
        public virtual ICollection<UbicacionesProductos> UbicacionesProductos { get; set; }
    }
}
