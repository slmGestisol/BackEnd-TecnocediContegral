using System;

namespace com.ServiBarras.Infrastructure.ModelDTO
{
    public class PedidosPreRuteoDTO
    {
        public long pedidoId { get; set; }

        public long usuarioId { get; set; }
        public Guid? uniqueProcessId { get; set; }
        public bool? Estado { get; set; }
        public bool? Secuencial { get; set; }
        public Guid? SecuencialUniqueProcessId { get; set; }

    }

    public class PedidosConfiguracionOrdenDTO
    {
        public long id { get; set; }
        public long ruteoId { get; set; }
        public long productoId { get; set; }
        public long orden { get; set; }
        public long usuarioId { get; set; }
        public long prioridad { get; set; }


    }

    public class PedidosDetalleCrossDockingDTO
    {
        public long crossDockingExcluirRuteoId { get; set; }

        public long PedidoId { get; set; }
        public long PresentacionId { get; set; }
        public long UsuarioId { get; set; }
        public DateTime? CrossDockingExcluirRuteoFecha { get; set; }
        public bool estado { get; set; }

    }
}
