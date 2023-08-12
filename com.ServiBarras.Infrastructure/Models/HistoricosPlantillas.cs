using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class HistoricosPlantillas
    {
        public long historicoPlantillaId { get; set; }
        public string historicoPlantillaNombre { get; set; }
        public string historicoPlantillaValorActual { get; set; }
        public string historicoPlantillaValorAnterior { get; set; }
        public string historicoPlantillaUsuario { get; set; }
        public string historicoPlantillaFechaModificacion { get; set; }
        public long productoId { get; set; }
        public long productoPlantillaId { get; set; }
    }
}
