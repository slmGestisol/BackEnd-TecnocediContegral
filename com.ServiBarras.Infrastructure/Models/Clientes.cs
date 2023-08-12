using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class Clientes
    {
        public long clienteId { get; set; }
        public string clienteCodigo { get; set; }
        public string clienteNombre { get; set; }
        public long titularId { get; set; }
        public string clienteDireccion { get; set; }
        public long ciudadId { get; set; }
        public string clienteTelefono { get; set; }
        public string clienteCodigoEAN { get; set; }

        public virtual Titulares titular { get; set; }
    }
}
