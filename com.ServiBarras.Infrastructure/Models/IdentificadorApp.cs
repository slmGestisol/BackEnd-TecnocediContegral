using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class IdentificadorApp
    {
        public int IdentificadorAppId { get; set; }
        public string IdentificadorAppCodigo { get; set; }
        public string IdentificadorAppDescripcion { get; set; }
        public string IdentificadorAppFormato { get; set; }
    }
}
