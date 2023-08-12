using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class ControlCerrarPuerta
    {
        public int id { get; set; }
        public int? puerta { get; set; }
        public int? ruteo { get; set; }
        public int? pedidoid { get; set; }
    }
}
