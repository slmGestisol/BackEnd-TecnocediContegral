using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class ValoresPlantillasLotes
    {
        public ValoresPlantillasLotes()
        {
            SaldosDetalle = new HashSet<SaldosDetalle>();
        }

        public long valorProductoLoteId { get; set; }
        public string valorplantillaLoteNombre { get; set; }
        public string valorplantillaLoteDescripcion { get; set; }
        public DateTime valorPlantillaLoteFechaProduccion { get; set; }
        public string valorPlantillaLoteCodigo { get; set; }
        public DateTime valorPLantillaLoteFechaVencimiento { get; set; }
        public long productoId { get; set; }
        public DateTime? FechaAjuste { get; set; }

        public virtual Productos producto { get; set; }
        public virtual ICollection<SaldosDetalle> SaldosDetalle { get; set; }
    }
}
