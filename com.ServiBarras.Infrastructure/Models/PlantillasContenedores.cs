using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class PlantillasContenedores
    {
        public long plantillaContenedorAtributoId { get; set; }
        public long contenedorId { get; set; }

        public virtual Contenedores contenedor { get; set; }
        public virtual PlantillasContenedoresAtributos plantillaContenedorAtributo { get; set; }
    }
}
