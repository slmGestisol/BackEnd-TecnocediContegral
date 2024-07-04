using System;
using System.Collections.Generic;
using System.Text;

namespace com.ServiBarras.Shared.ModelDTO
{
    public class UsuarioDTO
    {
        public long? usuarioId { get; set; }
        public string usuarioUser { get; set; }
        public string usuarioPassword { get; set; }
        public long instalacionId { get; set; }

    }
    public class UsuarioGuardarDTO
    {
        public string usuarioUser { get; set; }
        public string usuarioNombre { get; set; }
        public string usuarioApellido { get; set; }
        public string usuarioIdentificacion { get; set; }
        public string usuarioPassword { get; set; }

        public int rolId { get; set; }


    }
}
