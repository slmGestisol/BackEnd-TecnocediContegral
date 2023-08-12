using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class Identificaciones
    {
        public Identificaciones()
        {
            TXPacking = new HashSet<TXPacking>();
            TXPicking = new HashSet<TXPicking>();
            TxCalidadUbicaciones = new HashSet<TxCalidadUbicaciones>();
            TxDespacho = new HashSet<TxDespacho>();
            TxDevolucion = new HashSet<TxDevolucion>();
            TxInventario = new HashSet<TxInventario>();
            TxReubicacion = new HashSet<TxReubicacion>();
        }

        public long identificacionId { get; set; }
        public string identificacionCodigo { get; set; }
        public byte identificacionEstado { get; set; }
        public long presentacionId { get; set; }
        public long tipoIdentificacionId { get; set; }

        public virtual Presentaciones presentacion { get; set; }
        public virtual TiposIdentificaciones tipoIdentificacion { get; set; }
        public virtual ICollection<TXPacking> TXPacking { get; set; }
        public virtual ICollection<TXPicking> TXPicking { get; set; }
        public virtual ICollection<TxCalidadUbicaciones> TxCalidadUbicaciones { get; set; }
        public virtual ICollection<TxDespacho> TxDespacho { get; set; }
        public virtual ICollection<TxDevolucion> TxDevolucion { get; set; }
        public virtual ICollection<TxInventario> TxInventario { get; set; }
        public virtual ICollection<TxReubicacion> TxReubicacion { get; set; }
    }
}
