using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class EstacionesPerifericos
    {
        public long estacionId { get; set; }
        public long PerifericoId { get; set; }

        public virtual Perifericos Periferico { get; set; }
        public virtual Estaciones estacion { get; set; }
    }
}
