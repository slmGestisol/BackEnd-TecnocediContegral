using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class Config_Purgas
    {
        public string f_tabla { get; set; }
        public int? f_dias { get; set; }
        public string f_sp { get; set; }
        public int? f_dias_delete { get; set; }
    }
}
