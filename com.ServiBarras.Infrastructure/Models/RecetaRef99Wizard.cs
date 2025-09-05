using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class RecetaRef99Wizard
    {
        public long RecetaRef99Id { get; set; }
        public long? usuarioId { get; set; }
        public DateTime? fechaCarga { get; set; }
    }
}
