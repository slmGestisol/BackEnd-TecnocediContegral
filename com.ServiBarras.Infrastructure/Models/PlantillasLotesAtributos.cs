using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class PlantillasLotesAtributos
    {
        public long plantillaLoteId { get; set; }
        public long atributoLoteId { get; set; }

        public virtual AtributosLotes atributoLote { get; set; }
        public virtual PlantillasLotes plantillaLote { get; set; }
    }
}
