using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class TipoCoordenadas
    {
        public TipoCoordenadas()
        {
            Coordenadas = new HashSet<Coordenadas>();
        }

        public long tipoCoordenadaId { get; set; }
        [Required]
        [StringLength(100)]
        public string tipoCoordenadaDescripcion { get; set; }

        [InverseProperty("tipoCoordenadaNavigation")]
        public virtual ICollection<Coordenadas> Coordenadas { get; set; }
    }
}
