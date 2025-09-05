using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class Revision_preruteo
    {
        public long id { get; set; }
        public long? usuarioId { get; set; }
        public Guid? uniqueProcessId { get; set; }
        public long? instalacionId { get; set; }
        public long? SoloEstibasCompletas { get; set; }
        public DateTime? fecha { get; set; }
        public string resultado { get; set; }
        public DateTime? fechaFinalizacionTrasaccion { get; set; }
    }
}
