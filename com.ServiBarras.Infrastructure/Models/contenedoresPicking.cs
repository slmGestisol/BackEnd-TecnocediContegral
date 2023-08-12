using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class contenedoresPicking
    {
        public long ruteoId { get; set; }
        public long ruteoDetalleId { get; set; }
        public long contenedorId { get; set; }
        public long usuarioId { get; set; }

        public Guid? uniqueProcessId { get; set; }
        public bool? estado { get; set; }
    }
}
