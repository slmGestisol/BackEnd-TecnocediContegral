using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class Bodegas
    {
        public Bodegas()
        {
            Estaciones = new HashSet<Estaciones>();
            Saldos = new HashSet<Saldos>();
        }

        public long bodegaId { get; set; }
        public short bodegaEstado { get; set; }
        public long bodegaErpId { get; set; }

        [ForeignKey("bodegaErpId")]
        [InverseProperty("Bodegas")]
        public virtual BodegasERP bodegaErp { get; set; }
        [InverseProperty("bodega")]
        public virtual ICollection<Estaciones> Estaciones { get; set; }
        [InverseProperty("bodega")]
        public virtual ICollection<Saldos> Saldos { get; set; }
    }
}
