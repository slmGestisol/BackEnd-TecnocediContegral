using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class AtributosLotes
    {
        public AtributosLotes()
        {
            PlantillasLotesAtributos = new HashSet<PlantillasLotesAtributos>();
        }

        public long atributoLoteId { get; set; }
        public string atributoLoteDescripcion { get; set; }
        public string atributoLoteValorDefecto { get; set; }
        public byte atributoLoteEstado { get; set; }
        public long tipoAtributoId { get; set; }

        public virtual TiposAtributos tipoAtributo { get; set; }
        public virtual ICollection<PlantillasLotesAtributos> PlantillasLotesAtributos { get; set; }
    }
}
