using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class Roles
    {
        public long rolId { get; set; }
        public string roleDescripcion { get; set; }
        public short roleEstado { get; set; }
    }
}
