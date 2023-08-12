using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class Motivos
    {
        public long motivoId { get; set; }
        public string motivoDescripcion { get; set; }
        public byte[] motivoCodigo { get; set; }
    }
}
