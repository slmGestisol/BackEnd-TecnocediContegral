using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class Contenedores
    {
        public Contenedores()
        {
            InversecontenedorPadre = new HashSet<Contenedores>();
            PlantillasContenedores = new HashSet<PlantillasContenedores>();
            PreRuteosDetalle = new HashSet<PreRuteosDetalle>();
            ProductosContenedores = new HashSet<ProductosContenedores>();
            SaldosDetalle = new HashSet<SaldosDetalle>();
            TXPacking = new HashSet<TXPacking>();
            TXPicking = new HashSet<TXPicking>();
            TxDespacho = new HashSet<TxDespacho>();
            TxDevolucion = new HashSet<TxDevolucion>();
            TxOrdenEmpaque = new HashSet<TxOrdenEmpaque>();
            TxReubicacion = new HashSet<TxReubicacion>();
        }

        public long contenedorId { get; set; }
        public string contenedorCodigo { get; set; }
        public long? contenedorPadreId { get; set; }
        public long tipoContenedorId { get; set; }
        public int? contenedorEstibaConsecutivo { get; set; }
        public long? ultimaPresentacionId { get; set; }

        public virtual Contenedores contenedorPadre { get; set; }
        public virtual TiposContenedores tipoContenedor { get; set; }
        public virtual ICollection<Contenedores> InversecontenedorPadre { get; set; }
        public virtual ICollection<PlantillasContenedores> PlantillasContenedores { get; set; }
        public virtual ICollection<PreRuteosDetalle> PreRuteosDetalle { get; set; }
        public virtual ICollection<ProductosContenedores> ProductosContenedores { get; set; }
        public virtual ICollection<SaldosDetalle> SaldosDetalle { get; set; }
        public virtual ICollection<TXPacking> TXPacking { get; set; }
        public virtual ICollection<TXPicking> TXPicking { get; set; }
        public virtual ICollection<TxDespacho> TxDespacho { get; set; }
        public virtual ICollection<TxDevolucion> TxDevolucion { get; set; }
        public virtual ICollection<TxOrdenEmpaque> TxOrdenEmpaque { get; set; }
        public virtual ICollection<TxReubicacion> TxReubicacion { get; set; }
    }
}
