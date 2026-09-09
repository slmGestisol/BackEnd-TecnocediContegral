using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace com.ServiBarras.Shared.ModelDTO
{

    public class recepcionProcesarDTO
    {

        [JsonProperty("recepcionId")]
        public long recepcionId { get; set; }
        public long usuarioId { get; set; }
        public long UbicacionIdDestino { get; set; }
        public string documentoCodigo { get; set; }
        public List<recepcionContenedoreDTO> contenedoresRecepcion { get; set; }

    }
    public class recepcionContenedoreDTO
    {

        [JsonProperty("contenedorId")]
        public long contenedorId { get; set; }



    }
    public class recepcionCerrarDTO
    {

        [JsonProperty("recepcionId")]
        public long recepcionId { get; set; }
        public long usuarioId { get; set; }

    }
    public class ProcesarCerrarUbicacionDTO
    {

        [JsonProperty("recepcionId")]
        public long recepcionId { get; set; }
        public long usuarioId { get; set; }
        public long UbicacionId { get; set; }
        public long impresoraId { get; set; }

    }

    public class EliminarContenedorRecepcionDTO
    {

        [JsonProperty("recepcionId")]
        public long recepcionId { get; set; }
        public long usuarioId { get; set; }
        public long contenedorId { get; set; }
        public long ubicacionId { get; set; }

    }

}

