using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class AtributosContenedores
    {
        public long atributoContenedorId { get; set; }
        public string atributoContenedorDescripcion { get; set; }
        public byte atributoContenedorEstado { get; set; }
        public long tipoAtributoId { get; set; }
        public long plantillaContenedorAtributoId { get; set; }

        public virtual PlantillasContenedoresAtributos plantillaContenedorAtributo { get; set; }
        public virtual TiposAtributos tipoAtributo { get; set; }
    }
}
