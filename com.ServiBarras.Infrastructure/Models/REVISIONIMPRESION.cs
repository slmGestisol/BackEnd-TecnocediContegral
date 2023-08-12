using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class REVISIONIMPRESION
    {
        public int ID { get; set; }
        public int? ORDENEMPAQUE { get; set; }
        public DateTime? FECHA { get; set; }
        public int? ESTACION { get; set; }
        public int? CantidadEtiquetas { get; set; }
        public string MENSAJE { get; set; }
    }
}
