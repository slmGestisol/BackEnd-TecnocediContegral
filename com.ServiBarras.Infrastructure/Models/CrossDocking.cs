using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class CrossDocking
    {
        public long crossDockingId { get; set; }
        public long? ruteoId { get; set; }
        public long? bahiaId { get; set; }
        public long? presentacionId { get; set; }
        public decimal? cantidadSolicitada { get; set; }
        public decimal? cantidadPreparada { get; set; }
        public decimal? cantidadRestante { get; set; }
        public byte? estado { get; set; }
    }
}
