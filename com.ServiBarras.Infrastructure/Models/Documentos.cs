using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class Documentos
    {
        public Documentos()
        {
            DocumentosDetalle = new HashSet<DocumentosDetalle>();
            OrdenesEmpaque = new HashSet<OrdenesEmpaque>();
        }

        public long documentoId { get; set; }
        public string documentoCodigo { get; set; }
        public string documentoNombre { get; set; }
        public string documentoSerial { get; set; }
        public int documentoContador { get; set; }
        public int documentoInicial { get; set; }
        public int documentoFinal { get; set; }
        public DateTime documentoVigenciaInicial { get; set; }
        public DateTime documentoVigenciaFinal { get; set; }
        public short documentoUltDetalle { get; set; }
        public long? ubicacionId { get; set; }
        public long? bodegaLogicaId { get; set; }
        public long titularId { get; set; }
        public long procesoId { get; set; }
        public long? bodegaLogicaComboId { get; set; }

        public virtual BodegasLogicas bodegaLogica { get; set; }
        public virtual BodegasLogicas bodegaLogicaCombo { get; set; }
        public virtual Titulares titular { get; set; }
        public virtual ICollection<DocumentosDetalle> DocumentosDetalle { get; set; }
        public virtual ICollection<OrdenesEmpaque> OrdenesEmpaque { get; set; }
    }
}
