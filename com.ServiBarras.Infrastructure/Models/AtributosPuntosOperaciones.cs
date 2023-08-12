using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class AtributosPuntosOperaciones
    {
        public long atrPuntosOperacionId { get; set; }
        public string atrPuntosOperacionDescripcion { get; set; }
        public byte atrPuntosOperacionEstado { get; set; }
        public string atrPuntosOperacionValor { get; set; }
        public long tipoAtributoId { get; set; }
        public long listaPuntoOperacionId { get; set; }

        public virtual ListasPuntosOperacion listaPuntoOperacion { get; set; }
        public virtual TiposAtributos tipoAtributo { get; set; }
    }
}
