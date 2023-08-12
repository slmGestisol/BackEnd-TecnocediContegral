using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class RFIDTag
    {
        public decimal RFIDTagId { get; set; }
        public decimal? RFIDTagContador { get; set; }
        public string RFIDTagTipo_EPC { get; set; }
        public string RFIDTagEPC { get; set; }
        public string RFIDTagAntena { get; set; }
        public string RFIDTagReader { get; set; }
        public DateTime? RFIDTagFecha { get; set; }
        public string RFIDTagInicioEvento { get; set; }
        public string RFIDTagTagEvento { get; set; }
        public string RFIDTagRSSI { get; set; }
        public string RFIDTagMaquina { get; set; }
        public string RFIDTagEPCNueva { get; set; }
        public DateTime? GETDATE { get; set; }
    }
}
