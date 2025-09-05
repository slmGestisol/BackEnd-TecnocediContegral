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

}

