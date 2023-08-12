using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class Perifericos
    {
        public Perifericos()
        {
            EstacionesPerifericos = new HashSet<EstacionesPerifericos>();
        }

        public long PerifericoId { get; set; }
        public string PerifericoDescripcion { get; set; }
        public long tipoPerifericoId { get; set; }

        public virtual TiposPerifericos tipoPeriferico { get; set; }
        public virtual ICollection<EstacionesPerifericos> EstacionesPerifericos { get; set; }
    }
}
