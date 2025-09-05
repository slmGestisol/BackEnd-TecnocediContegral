using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class ARC_Contenedores
    {
        public long contenedorId { get; set; }
        public string contenedorCodigo { get; set; }
        public long? contenedorPadreId { get; set; }
        public long tipoContenedorId { get; set; }
        public int? contenedorEstibaConsecutivo { get; set; }
        public long? ultimaPresentacionId { get; set; }
    }
}
