using System;
using System.Collections.Generic;
using System.Text;

namespace com.ServiBarras.Shared.ModelDTO
{
   public class OrdenEmpaqueDTO
    {

        public long? ubicacionId { get; set; }
        public string ubicacionCodigo { get; set; }
        public string estadoEstibaUbicacion { get; set; }
        public long? contenedorId { get; set; }
        public string contenedorCodigo { get; set; }
        public string proceso { get; set; }

        public long? usuarioId { get; set; }

        public long? estacionId { get; set; }

        public long? ordenEmpaqueId { get; set; }

        public long? presentacionId { get; set; }


    }

    public class generarOrdenEmpaqueDTO
    {

        public long usuarioId { get; set; }
        public long productoId { get; set; }
        public string tipoEvalacion { get; set; }
        public string fechaFinalizacion { get; set; }
        public long? NUnidades { get; set; }
        public long? estacionId { get; set; }
        public string loteCodigo { get; set; }
        public string tipo { get; set; }
        public string docExterno { get; set; }
        
    }

    public class generarOrdenEmpaqueExternaDTO
    {

        public long usuarioId { get; set; }
        public string tipoDoc { get; set; }
        public long? estacionId { get; set; }
        public string documentoERP { get; set; }

    }

    public class cambioFechaLoteOrdenEmpaqueDTO
    {

        public long ordenEmpaqueId { get; set; }
        public string fecha { get; set; }

    }

    public class cambioEstadioEstacionLoteDTO
    {
        public long estacionId { get; set; }
        public Boolean valor { get; set; }

    }

    public class cerrarRecpcecionDTO
    {
        public string estibaCodigo { get; set; }
        public long cantidad { get; set; }
        public long ubicacionId { get; set; }
        public long ordenEmpaqueId { get; set; }
        public string loteCodigo { get; set; }
        public string LoteFechaVencimiento { get; set; }
        public long usuarioId { get; set; }
    }

    public class cerrarEstibaRecepcionCalidadDTO
    {

        public long ordenEmpaqueId { get; set; }
        public decimal cantidad { get; set; }
        public long? usuarioId { get; set; }
        public string loteCodigo { get; set; }
        public string productoCodigoValidacion { get; set; }
        public string estadoCalidad { get; set; }

    }
}
