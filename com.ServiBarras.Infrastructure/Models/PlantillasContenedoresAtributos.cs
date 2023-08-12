using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class PlantillasContenedoresAtributos
    {
        public PlantillasContenedoresAtributos()
        {
            AtributosContenedores = new HashSet<AtributosContenedores>();
            PlantillasContenedores = new HashSet<PlantillasContenedores>();
        }

        public long plantillaContenedorAtributoId { get; set; }
        public string plantillaContenedorAtributoDescripcion { get; set; }
        public byte plantillaContenedorAtributoEstado { get; set; }

        public virtual ICollection<AtributosContenedores> AtributosContenedores { get; set; }
        public virtual ICollection<PlantillasContenedores> PlantillasContenedores { get; set; }
    }
}
