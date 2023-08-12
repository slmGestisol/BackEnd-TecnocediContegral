using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class Novedades
    {
        public Novedades()
        {
            DespachosDetalle = new HashSet<DespachosDetalle>();
            OrdenesEmpaque = new HashSet<OrdenesEmpaque>();
            PackingDetalle = new HashSet<PackingDetalle>();
            TXPacking = new HashSet<TXPacking>();
            TXPicking = new HashSet<TXPicking>();
            TxCalidadUbicaciones = new HashSet<TxCalidadUbicaciones>();
            TxDespacho = new HashSet<TxDespacho>();
            TxDevolucion = new HashSet<TxDevolucion>();
            TxReubicacion = new HashSet<TxReubicacion>();
        }

        public long novedadId { get; set; }
        public string novedadDescripcion { get; set; }
        public string novedadCodigo { get; set; }
        public string novedadNombre { get; set; }
        public string novedadAfectaSaldo { get; set; }
        public long? documentoId { get; set; }
        public long? novedadAccionId { get; set; }
        public byte? tipoNovedadId { get; set; }
        public int? procesoId { get; set; }

        public virtual Procesos proceso { get; set; }
        public virtual ICollection<DespachosDetalle> DespachosDetalle { get; set; }
        public virtual ICollection<OrdenesEmpaque> OrdenesEmpaque { get; set; }
        public virtual ICollection<PackingDetalle> PackingDetalle { get; set; }
        public virtual ICollection<TXPacking> TXPacking { get; set; }
        public virtual ICollection<TXPicking> TXPicking { get; set; }
        public virtual ICollection<TxCalidadUbicaciones> TxCalidadUbicaciones { get; set; }
        public virtual ICollection<TxDespacho> TxDespacho { get; set; }
        public virtual ICollection<TxDevolucion> TxDevolucion { get; set; }
        public virtual ICollection<TxReubicacion> TxReubicacion { get; set; }
    }
}
