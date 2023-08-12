using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class Titulares
    {
        public Titulares()
        {
            Clientes = new HashSet<Clientes>();
            Documentos = new HashSet<Documentos>();
            Productos = new HashSet<Productos>();
        }

        public long titularId { get; set; }
        public string titularDescripcion { get; set; }
        public string titularCodigo { get; set; }
        public long ordenanteId { get; set; }

        public virtual Ordenantes ordenante { get; set; }
        public virtual ICollection<Clientes> Clientes { get; set; }
        public virtual ICollection<Documentos> Documentos { get; set; }
        public virtual ICollection<Productos> Productos { get; set; }
    }
}
