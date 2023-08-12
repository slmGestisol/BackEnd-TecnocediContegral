using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class Estaciones
    {
        public Estaciones()
        {
            EstacionesPerifericos = new HashSet<EstacionesPerifericos>();
            OrdenesEmpaque = new HashSet<OrdenesEmpaque>();
        }

        public long estacionId { get; set; }
        public string estacionDescripcion { get; set; }
        public byte? estacionEstado { get; set; }
        public long? bodegaLogicaId { get; set; }
        public long? operacionId { get; set; }
        public long? tipoEstacionId { get; set; }

        public virtual BodegasLogicas bodegaLogica { get; set; }
        public virtual Operaciones operacion { get; set; }
        public virtual ICollection<EstacionesPerifericos> EstacionesPerifericos { get; set; }
        public virtual ICollection<OrdenesEmpaque> OrdenesEmpaque { get; set; }
    }
}
