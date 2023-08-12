using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class PuntosOperaciones
    {
        public PuntosOperaciones()
        {
            ContactosPuntosOperaciones = new HashSet<ContactosPuntosOperaciones>();
            Coordenadas = new HashSet<Coordenadas>();
            Grupos = new HashSet<Grupos>();
            OrdenesEmpaque = new HashSet<OrdenesEmpaque>();
            Pedidos = new HashSet<Pedidos>();
        }

        public long puntoOperacionId { get; set; }
        public string puntoOperacionCodigo { get; set; }
        public string puntoOperacionDescripcion { get; set; }
        public byte puntoOperacionEstado { get; set; }
        public long centroOperacionId { get; set; }
        public long custodioId { get; set; }
        public long ciudadId { get; set; }
        public long? listaPuntoOperacionId { get; set; }
        public string puntoOperacionDireccion { get; set; }

        public virtual CentrosOperaciones centroOperacion { get; set; }
        public virtual Ciudades ciudad { get; set; }
        public virtual Custodios custodio { get; set; }
        public virtual ListasPuntosOperacion listaPuntoOperacion { get; set; }
        public virtual ICollection<ContactosPuntosOperaciones> ContactosPuntosOperaciones { get; set; }
        public virtual ICollection<Coordenadas> Coordenadas { get; set; }
        public virtual ICollection<Grupos> Grupos { get; set; }
        public virtual ICollection<OrdenesEmpaque> OrdenesEmpaque { get; set; }
        public virtual ICollection<Pedidos> Pedidos { get; set; }
    }
}
