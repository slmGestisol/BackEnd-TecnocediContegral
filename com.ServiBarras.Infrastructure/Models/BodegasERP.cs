using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class BodegasERP
    {
        public BodegasERP()
        {
            BodegasLogicas = new HashSet<BodegasLogicas>();
        }

        public long bodegaErpId { get; set; }
        public byte bodegaErpEstado { get; set; }
        public string bodegaERPCodigo { get; set; }
        public string bodegaERPDescripcion { get; set; }

        public virtual ICollection<BodegasLogicas> BodegasLogicas { get; set; }
    }
}
