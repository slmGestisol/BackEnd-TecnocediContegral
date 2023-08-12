using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class CriteriosPresentacion
    {
        public CriteriosPresentacion()
        {
            ClasificacionesPresentaciones = new HashSet<ClasificacionesPresentaciones>();
        }

        [Key]
        public long criterioPresentacionId { get; set; }
        [Required]
        [StringLength(100)]
        public string criterioPresentacionDescripcion { get; set; }
        public byte criterioPresentacionEstado { get; set; }
        public byte criterioProductoMultiple { get; set; }

        [InverseProperty("criteriosProducto")]
        public virtual ICollection<ClasificacionesPresentaciones> ClasificacionesPresentaciones { get; set; }
    }
}
