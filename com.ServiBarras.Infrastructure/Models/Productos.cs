using System;
using System.Collections.Generic;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class Productos
    {
        public Productos()
        {
            OrdenesEmpaque = new HashSet<OrdenesEmpaque>();
            PedidosDetalle = new HashSet<PedidosDetalle>();
            PlantillasProductos = new HashSet<PlantillasProductos>();
            Presentaciones = new HashSet<Presentaciones>();
            ProductosAtributos = new HashSet<ProductosAtributos>();
            ProductosClasificaciones = new HashSet<ProductosClasificaciones>();
            ProductosCombosproductoIdComboNavigation = new HashSet<ProductosCombos>();
            ProductosCombosproductoIdDestinoNavigation = new HashSet<ProductosCombos>();
            ProductosContenedores = new HashSet<ProductosContenedores>();
            ProductosLotes = new HashSet<ProductosLotes>();
            Reglas = new HashSet<Reglas>();
            UbicacionesProductos = new HashSet<UbicacionesProductos>();
            ValoresPlantillasLotes = new HashSet<ValoresPlantillasLotes>();
        }

        public long productoId { get; set; }
        public string productoCodigo { get; set; }
        public string productoDescripcion { get; set; }
        public int productoCantidadManejo { get; set; }
        public decimal? productoCantidadEscalar { get; set; }
        public byte? productoUnidadInventario { get; set; }
        public byte productoManejaLote { get; set; }
        public byte productoEstado { get; set; }
        public string productoCodigoAlternativo { get; set; }
        public byte? productoManejaDimension { get; set; }
        public long? titularId { get; set; }
        public long? unidadManejoId { get; set; }
        public long? unidadEscalarId { get; set; }
        public short productoTipo { get; set; }

        public virtual Titulares titular { get; set; }
        public virtual UnidadesEscalares unidadEscalar { get; set; }
        public virtual UnidadesManejo unidadManejo { get; set; }
        public virtual Saldos Saldos { get; set; }
        public virtual ICollection<OrdenesEmpaque> OrdenesEmpaque { get; set; }
        public virtual ICollection<PedidosDetalle> PedidosDetalle { get; set; }
        public virtual ICollection<PlantillasProductos> PlantillasProductos { get; set; }
        public virtual ICollection<Presentaciones> Presentaciones { get; set; }
        public virtual ICollection<ProductosAtributos> ProductosAtributos { get; set; }
        public virtual ICollection<ProductosClasificaciones> ProductosClasificaciones { get; set; }
        public virtual ICollection<ProductosCombos> ProductosCombosproductoIdComboNavigation { get; set; }
        public virtual ICollection<ProductosCombos> ProductosCombosproductoIdDestinoNavigation { get; set; }
        public virtual ICollection<ProductosContenedores> ProductosContenedores { get; set; }
        public virtual ICollection<ProductosLotes> ProductosLotes { get; set; }
        public virtual ICollection<Reglas> Reglas { get; set; }
        public virtual ICollection<UbicacionesProductos> UbicacionesProductos { get; set; }
        public virtual ICollection<ValoresPlantillasLotes> ValoresPlantillasLotes { get; set; }
    }
}
