using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class TiposPerifericos
    {
        public TiposPerifericos()
        {
            Perifericos = new HashSet<Perifericos>();
        }

        public long tipoPerifericoId { get; set; }
        public string tipoPerifericoDescripcion { get; set; }
        public short tipoPerifericoEstado { get; set; }

        public virtual ICollection<Perifericos> Perifericos { get; set; }
    }
}
