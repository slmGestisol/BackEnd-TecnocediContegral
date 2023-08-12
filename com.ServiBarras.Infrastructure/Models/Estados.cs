using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class Estados
    {
        public Estados()
        {
            Ciudades = new HashSet<Ciudades>();
        }

        public long estadoId { get; set; }
        public string estadoCodigo { get; set; }
        public string estadoCodigoDANE { get; set; }
        public string estadoNombre { get; set; }
        public long paisId { get; set; }

        public virtual Paises pais { get; set; }
        public virtual ICollection<Ciudades> Ciudades { get; set; }
    }
}
