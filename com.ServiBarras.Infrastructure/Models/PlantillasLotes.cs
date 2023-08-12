using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class PlantillasLotes
    {
        public PlantillasLotes()
        {
            PlantillasLotesAtributos = new HashSet<PlantillasLotesAtributos>();
            ProductosLotes = new HashSet<ProductosLotes>();
        }

        public long plantillaLoteId { get; set; }
        public string plantillaLoteDescripcion { get; set; }

        public virtual ICollection<PlantillasLotesAtributos> PlantillasLotesAtributos { get; set; }
        public virtual ICollection<ProductosLotes> ProductosLotes { get; set; }
    }
}
