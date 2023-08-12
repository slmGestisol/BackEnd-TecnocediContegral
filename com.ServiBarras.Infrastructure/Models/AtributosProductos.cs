using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class AtributosProductos
    {
        public AtributosProductos()
        {
            ClasificacionesAtributosProductos = new HashSet<ClasificacionesAtributosProductos>();
        }

        public long atributoProductoId { get; set; }
        public string atributoProductoDescripcion { get; set; }
        public byte atributoProductoEstado { get; set; }
        public long tipoAtributoId { get; set; }
        public long plantillaProductoAtributoId { get; set; }

        public virtual PlantillasProductosAtributos plantillaProductoAtributo { get; set; }
        public virtual TiposAtributos tipoAtributo { get; set; }
        public virtual ICollection<ClasificacionesAtributosProductos> ClasificacionesAtributosProductos { get; set; }
    }
}
