using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class PLANO
    {
        public int ID { get; set; }
        public long? InstalacionIdOrigen { get; set; }
        public long? UbicacionIdOrigen { get; set; }
        public long? InstalacionIdDestino { get; set; }
        public long? UbicacionIdDestino { get; set; }
        public int? UsuarioId { get; set; }
        public DateTime? Fecha { get; set; }
    }
}
