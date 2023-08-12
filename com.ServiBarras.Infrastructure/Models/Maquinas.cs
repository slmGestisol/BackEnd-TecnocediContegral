using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class Maquinas
    {
        public long maquinaId { get; set; }
        public string maquinaCodigo { get; set; }
        public string maquinaIP { get; set; }
        public byte maquinaEstado { get; set; }
    }
}
