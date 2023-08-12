using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class TiposAtributos
    {
        public TiposAtributos()
        {
            AtributosContenedores = new HashSet<AtributosContenedores>();
            AtributosLotes = new HashSet<AtributosLotes>();
            AtributosProductos = new HashSet<AtributosProductos>();
            AtributosPuntosOperaciones = new HashSet<AtributosPuntosOperaciones>();
        }

        public long tipoAtributoId { get; set; }
        public string tipoAtributoDescripcion { get; set; }

        public virtual ICollection<AtributosContenedores> AtributosContenedores { get; set; }
        public virtual ICollection<AtributosLotes> AtributosLotes { get; set; }
        public virtual ICollection<AtributosProductos> AtributosProductos { get; set; }
        public virtual ICollection<AtributosPuntosOperaciones> AtributosPuntosOperaciones { get; set; }
    }
}
