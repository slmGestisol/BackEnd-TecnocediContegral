using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace com.ServiBarras.Infrastructure.Models
{
    public partial class TecnoCEDI_bdContext : DbContext
    {
        public TecnoCEDI_bdContext()
        {
        }

        public TecnoCEDI_bdContext(DbContextOptions<TecnoCEDI_bdContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AtributosContenedores> AtributosContenedores { get; set; }
        public virtual DbSet<AtributosLotes> AtributosLotes { get; set; }
        public virtual DbSet<AtributosProductos> AtributosProductos { get; set; }
        public virtual DbSet<AtributosPuntosOperaciones> AtributosPuntosOperaciones { get; set; }
        public virtual DbSet<BodegasERP> BodegasERP { get; set; }
        public virtual DbSet<BodegasLogicas> BodegasLogicas { get; set; }
        public virtual DbSet<CentrosGestion> CentrosGestion { get; set; }
        public virtual DbSet<CentrosOperaciones> CentrosOperaciones { get; set; }
        public virtual DbSet<Ciudades> Ciudades { get; set; }
        public virtual DbSet<ClasificacionesAtributosProductos> ClasificacionesAtributosProductos { get; set; }
        public virtual DbSet<ClasificacionesPlantillasProductos> ClasificacionesPlantillasProductos { get; set; }
        public virtual DbSet<ClasificacionesPresentaciones> ClasificacionesPresentaciones { get; set; }
        public virtual DbSet<ClasificacionesProductos> ClasificacionesProductos { get; set; }
        public virtual DbSet<Clientes> Clientes { get; set; }
        public virtual DbSet<ConfiguracionVerificacion> ConfiguracionVerificacion { get; set; }
        public virtual DbSet<Contactos> Contactos { get; set; }
        public virtual DbSet<ContactosPuntosOperaciones> ContactosPuntosOperaciones { get; set; }
        public virtual DbSet<Contenedores> Contenedores { get; set; }
        public virtual DbSet<ContenedoresSinSaldo> ContenedoresSinSaldo { get; set; }
        public virtual DbSet<ControlCerrarPuerta> ControlCerrarPuerta { get; set; }
        public virtual DbSet<Coordenadas> Coordenadas { get; set; }
        public virtual DbSet<CriteriosPresentaciones> CriteriosPresentaciones { get; set; }
        public virtual DbSet<CriteriosProductos> CriteriosProductos { get; set; }
        public virtual DbSet<CrossDocking> CrossDocking { get; set; }
        public virtual DbSet<Custodios> Custodios { get; set; }
        public virtual DbSet<Despachos> Despachos { get; set; }
        public virtual DbSet<DespachosDetalle> DespachosDetalle { get; set; }
        public virtual DbSet<DespachosPoquitos> DespachosPoquitos { get; set; }
        public virtual DbSet<DetalleUnidadesEscalares> DetalleUnidadesEscalares { get; set; }
        public virtual DbSet<Devoluciones> Devoluciones { get; set; }
        public virtual DbSet<Documentos> Documentos { get; set; }
        public virtual DbSet<DocumentosDetalle> DocumentosDetalle { get; set; }
        public virtual DbSet<Estaciones> Estaciones { get; set; }
        public virtual DbSet<EstacionesPerifericos> EstacionesPerifericos { get; set; }
        public virtual DbSet<Estados> Estados { get; set; }
        public virtual DbSet<Grupos> Grupos { get; set; }
        public virtual DbSet<GruposListas> GruposListas { get; set; }
        public virtual DbSet<HistoricosPlantillas> HistoricosPlantillas { get; set; }
        public virtual DbSet<Identificaciones> Identificaciones { get; set; }
        public virtual DbSet<IdentificadorApp> IdentificadorApp { get; set; }
        public virtual DbSet<InformeRuteosINFO1> InformeRuteosINFO1 { get; set; }
        public virtual DbSet<Instalaciones> Instalaciones { get; set; }
        public virtual DbSet<Inventarios> Inventarios { get; set; }
        public virtual DbSet<ListasPuntosOperacion> ListasPuntosOperacion { get; set; }
        public virtual DbSet<Maquinas> Maquinas { get; set; }
        public virtual DbSet<Motivos> Motivos { get; set; }
        public virtual DbSet<Novedades> Novedades { get; set; }
        public virtual DbSet<NovedadesAcciones> NovedadesAcciones { get; set; }
        public virtual DbSet<Operaciones> Operaciones { get; set; }
        public virtual DbSet<Ordenantes> Ordenantes { get; set; }
        public virtual DbSet<OrdenesEmpaque> OrdenesEmpaque { get; set; }
        public virtual DbSet<PLANO> PLANO { get; set; }
        public virtual DbSet<Packing> Packing { get; set; }
        public virtual DbSet<PackingDetalle> PackingDetalle { get; set; }
        public virtual DbSet<Paises> Paises { get; set; }
        public virtual DbSet<Pedidos> Pedidos { get; set; }
        public virtual DbSet<PedidosDetalle> PedidosDetalle { get; set; }
        public virtual DbSet<PedidosPreRuteo> PedidosPreRuteo { get; set; }
        public virtual DbSet<Perifericos> Perifericos { get; set; }
        public virtual DbSet<PickingControl> PickingControl { get; set; }
        public virtual DbSet<PlantillasContenedores> PlantillasContenedores { get; set; }
        public virtual DbSet<PlantillasContenedoresAtributos> PlantillasContenedoresAtributos { get; set; }
        public virtual DbSet<PlantillasLotes> PlantillasLotes { get; set; }
        public virtual DbSet<PlantillasLotesAtributos> PlantillasLotesAtributos { get; set; }
        public virtual DbSet<PlantillasProductos> PlantillasProductos { get; set; }
        public virtual DbSet<PlantillasProductosAtributos> PlantillasProductosAtributos { get; set; }
        public virtual DbSet<PreRuteos> PreRuteos { get; set; }
        public virtual DbSet<PreRuteosDetalle> PreRuteosDetalle { get; set; }
        public virtual DbSet<PreRuteosPedidos> PreRuteosPedidos { get; set; }
        public virtual DbSet<Presentaciones> Presentaciones { get; set; }
        public virtual DbSet<PresentacionesClasificacion> PresentacionesClasificacion { get; set; }
        public virtual DbSet<Procesos> Procesos { get; set; }
        public virtual DbSet<Productos> Productos { get; set; }
        public virtual DbSet<ProductosAtributos> ProductosAtributos { get; set; }
        public virtual DbSet<ProductosClasificaciones> ProductosClasificaciones { get; set; }
        public virtual DbSet<ProductosCombos> ProductosCombos { get; set; }
        public virtual DbSet<ProductosContenedores> ProductosContenedores { get; set; }
        public virtual DbSet<ProductosLotes> ProductosLotes { get; set; }
        public virtual DbSet<ProductosSustituciones> ProductosSustituciones { get; set; }
        public virtual DbSet<PuntosEnvio> PuntosEnvio { get; set; }
        public virtual DbSet<PuntosOperaciones> PuntosOperaciones { get; set; }
        public virtual DbSet<REVISIONIMPRESION> REVISIONIMPRESION { get; set; }
        public virtual DbSet<RFIDTag> RFIDTag { get; set; }
        public virtual DbSet<Reglas> Reglas { get; set; }
        public virtual DbSet<Revision_Modulo> Revision_Modulo { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<RutasGrupos> RutasGrupos { get; set; }
        public virtual DbSet<RutasUbicaciones> RutasUbicaciones { get; set; }
        public virtual DbSet<Ruteos> Ruteos { get; set; }
        public virtual DbSet<RuteosDetalle> RuteosDetalle { get; set; }
        public virtual DbSet<RuteosPedidos> RuteosPedidos { get; set; }
        public virtual DbSet<Saldos> Saldos { get; set; }
        public virtual DbSet<SaldosDetalle> SaldosDetalle { get; set; }
        public virtual DbSet<SaldosUbicaciones> SaldosUbicaciones { get; set; }
        public virtual DbSet<Siesa_OrdenEmpaque_Auditoria> Siesa_OrdenEmpaque_Auditoria { get; set; }
        public virtual DbSet<Sucursales> Sucursales { get; set; }
        public virtual DbSet<TABLAREVISION> TABLAREVISION { get; set; }
        public virtual DbSet<TXPacking> TXPacking { get; set; }
        public virtual DbSet<TXPicking> TXPicking { get; set; }
        public virtual DbSet<TiposAtributos> TiposAtributos { get; set; }
        public virtual DbSet<TiposContenedores> TiposContenedores { get; set; }
        public virtual DbSet<TiposCoordenadas> TiposCoordenadas { get; set; }
        public virtual DbSet<TiposEstaciones> TiposEstaciones { get; set; }
        public virtual DbSet<TiposIdentificaciones> TiposIdentificaciones { get; set; }
        public virtual DbSet<TiposPerifericos> TiposPerifericos { get; set; }
        public virtual DbSet<TiposUbicaciones> TiposUbicaciones { get; set; }
        public virtual DbSet<Titulares> Titulares { get; set; }
        public virtual DbSet<TxCalidadUbicaciones> TxCalidadUbicaciones { get; set; }
        public virtual DbSet<TxDespacho> TxDespacho { get; set; }
        public virtual DbSet<TxDevolucion> TxDevolucion { get; set; }
        public virtual DbSet<TxInventario> TxInventario { get; set; }
        public virtual DbSet<TxOrdenEmpaque> TxOrdenEmpaque { get; set; }
        public virtual DbSet<TxReubicacion> TxReubicacion { get; set; }
        public virtual DbSet<Ubicaciones> Ubicaciones { get; set; }
        public virtual DbSet<UbicacionesCambioAutomatico> UbicacionesCambioAutomatico { get; set; }
        public virtual DbSet<UbicacionesFisicas> UbicacionesFisicas { get; set; }
        public virtual DbSet<UbicacionesProductos> UbicacionesProductos { get; set; }
        public virtual DbSet<UbicacionesSugeridoModulos> UbicacionesSugeridoModulos { get; set; }
        public virtual DbSet<UnidadesEscalares> UnidadesEscalares { get; set; }
        public virtual DbSet<UnidadesManejo> UnidadesManejo { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }
        public virtual DbSet<UsuariosEstaciones> UsuariosEstaciones { get; set; }
        public virtual DbSet<UsuariosRoles> UsuariosRoles { get; set; }
        public virtual DbSet<ValoresPlantillasLotes> ValoresPlantillasLotes { get; set; }
        public virtual DbSet<ValoresProductosLotes> ValoresProductosLotes { get; set; }
        public virtual DbSet<pedidoOrden> pedidoOrden { get; set; }
        public virtual DbSet<revisionCierre> revisionCierre { get; set; }
        public virtual DbSet<revisonpoquitos> revisonpoquitos { get; set; }

        // Unable to generate entity type for table 'dbo.ContenedorEliminar27_05_20'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Copia_Contenedores_27_05_20'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.PresentacionesListas'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.PresentacionesListasDetalle'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.contenedoresPicking'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.cont'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.TXReemplazoContenedor'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.ProductosListas'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.ProductosListasDetalle'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.REVISIONPICKING'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.RuteosPedidosDetalleEstado'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.PuntosEnviosListas'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.PuntosEnviosListasDetalle'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.contenedorEliminar20_07_20'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.CONTENEDORESCOPIA20_07_20'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.PuntosOperacionesListas'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.PuntosOperacionesListasDetalle'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.ReglaCaducidad'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.OrdenEmpaqueEvaluacion'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.txrevisionTxdespacho'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.txdespachocopia'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.revisiontpacking'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.revisiontpicking'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.ControlBorrarSaldoIntegracionCabeza'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.RuteosUbicacionesOrden'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.revisiontxreubicacion'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.RespaldoContenedores'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.HIS_TxDespacho_25_06_2020'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.DocumentosDetalleTipo'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.ReservaCambioTx'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.DocumentosGruposListas'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.DocumentosListas'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.DocumentosPresentacionesListas'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.ContenedoresConSaldo'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.TiposNovedades'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.DocumentosProductosListas'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.DocumentosPuntosEnvioListas'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.DocumentosPuntosOperaciones'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.DocumentosPuntosOperacionesListas'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.copia_UbicacionesProductos'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.DocumentosReglas'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.TxReubicacionAnt_30_03_20'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.copia_UbicacionesSugeridoModulos'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.DocumentosRutas'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.TxReubicacionInsert'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.DocumentosSeries'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.DocumentosUbicacionesListas'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.DocumentosUbicacionesLogicasListas'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.RutaPicking'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.DocumentosUsuariosListas'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.contenedorId_Eliminar'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.copia_contenedores_16_06_20'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.copia_rutapicking'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.His_TxReubicacion_280620'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.UbicacionesListas'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.His_TxOrdenEmpaque_280620'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.UbicacionesListasDetalle'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.His_TXPicking_280620'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.UbicacionesLogicasListas'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.His_TXPacking_280620'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.UbicacionesLogicasListasDetalle'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.copia_ruta'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.His_TxDespacho_280620'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.contenedoreliminar_280620'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.copia_contenedores_280620'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Usuario'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.UsuarioGrupo'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.estacionLote'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.revisiondespacho'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.UsuariosListas'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.contenedorEliminar230820'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.UsuariosListasDetalle'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.copiaContenedores_230820'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.prueb'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.revisarContenedoresEliminado'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Lote'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                var configurationBuilder = new ConfigurationBuilder();
                var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
                configurationBuilder.AddJsonFile(path, false);

                var root = configurationBuilder.Build();
                var _connectionString = root.GetConnectionString("TecnoCEDIEntities");


                optionsBuilder.UseSqlServer(_connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<AtributosContenedores>(entity =>
            {
                entity.HasKey(e => e.atributoContenedorId);

                entity.Property(e => e.atributoContenedorDescripcion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.atributoContenedorEstado).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.plantillaContenedorAtributo)
                    .WithMany(p => p.AtributosContenedores)
                    .HasForeignKey(d => d.plantillaContenedorAtributoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AtributosContenedores_PlantillasContenedoresAtributos");

                entity.HasOne(d => d.tipoAtributo)
                    .WithMany(p => p.AtributosContenedores)
                    .HasForeignKey(d => d.tipoAtributoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AtributosContenedores_TiposAtributos");
            });

            modelBuilder.Entity<AtributosLotes>(entity =>
            {
                entity.HasKey(e => e.atributoLoteId);

                entity.Property(e => e.atributoLoteDescripcion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.atributoLoteValorDefecto)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.tipoAtributo)
                    .WithMany(p => p.AtributosLotes)
                    .HasForeignKey(d => d.tipoAtributoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AtributosLotes_TiposAtributos");
            });

            modelBuilder.Entity<AtributosProductos>(entity =>
            {
                entity.HasKey(e => e.atributoProductoId);

                entity.Property(e => e.atributoProductoDescripcion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.plantillaProductoAtributo)
                    .WithMany(p => p.AtributosProductos)
                    .HasForeignKey(d => d.plantillaProductoAtributoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AtributosProductos_PlantillasProductosAtributos");

                entity.HasOne(d => d.tipoAtributo)
                    .WithMany(p => p.AtributosProductos)
                    .HasForeignKey(d => d.tipoAtributoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AtributosProductos_TiposAtributos");
            });

            modelBuilder.Entity<AtributosPuntosOperaciones>(entity =>
            {
                entity.HasKey(e => e.atrPuntosOperacionId)
                    .HasName("PK_AtributoPuntosOperacion");

                entity.Property(e => e.atrPuntosOperacionDescripcion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.atrPuntosOperacionValor)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.listaPuntoOperacion)
                    .WithMany(p => p.AtributosPuntosOperaciones)
                    .HasForeignKey(d => d.listaPuntoOperacionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AtributoPuntosOperacion_ListasPuntosOperacion");

                entity.HasOne(d => d.tipoAtributo)
                    .WithMany(p => p.AtributosPuntosOperaciones)
                    .HasForeignKey(d => d.tipoAtributoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AtributoPuntosOperacion_TiposAtributos");
            });

            modelBuilder.Entity<BodegasERP>(entity =>
            {
                entity.HasKey(e => e.bodegaErpId)
                    .HasName("PK_BodegaERP");

                entity.Property(e => e.bodegaERPCodigo)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.bodegaERPDescripcion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BodegasLogicas>(entity =>
            {
                entity.HasKey(e => e.bodegaLogicaId)
                    .HasName("PK_BodegaLogica");

                entity.Property(e => e.bodegaLogicaCodigo)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.bodegaLogicaDescripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.bodegaErp)
                    .WithMany(p => p.BodegasLogicas)
                    .HasForeignKey(d => d.bodegaErpId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BodegasLogicas_BodegasERP");
            });

            modelBuilder.Entity<CentrosGestion>(entity =>
            {
                entity.HasKey(e => e.centroGestionId);

                entity.Property(e => e.centroGestionCodigo)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.centroGestionDescripcion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.ordenante)
                    .WithMany(p => p.CentrosGestion)
                    .HasForeignKey(d => d.ordenanteId)
                    .HasConstraintName("FK_CentrosGestion_Ordenantes");
            });

            modelBuilder.Entity<CentrosOperaciones>(entity =>
            {
                entity.HasKey(e => e.centroOperacionId)
                    .HasName("PK_CentrosOperacion");

                entity.Property(e => e.centroOperacionCodigo)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.centroOperacionDescripcion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.ordenante)
                    .WithMany(p => p.CentrosOperaciones)
                    .HasForeignKey(d => d.ordenanteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CentrosOperacion_Ordenantes");
            });

            modelBuilder.Entity<Ciudades>(entity =>
            {
                entity.HasKey(e => e.ciudadId);

                entity.Property(e => e.ciudadCodigo)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ciudadCodigoDANE)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ciudadNombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.estado)
                    .WithMany(p => p.Ciudades)
                    .HasForeignKey(d => d.estadoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ciudades_Estados");
            });

            modelBuilder.Entity<ClasificacionesAtributosProductos>(entity =>
            {
                entity.HasKey(e => new { e.clasificacionId, e.atributoProductoId });

                entity.HasOne(d => d.atributoProducto)
                    .WithMany(p => p.ClasificacionesAtributosProductos)
                    .HasForeignKey(d => d.atributoProductoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClasificacionesAtributosProductos_AtributosProductos");

                entity.HasOne(d => d.clasificacion)
                    .WithMany(p => p.ClasificacionesAtributosProductos)
                    .HasForeignKey(d => d.clasificacionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClasificacionesAtributosProductos_ClasificacionesProducto");
            });

            modelBuilder.Entity<ClasificacionesPlantillasProductos>(entity =>
            {
                entity.HasKey(e => new { e.clasificacionId, e.plantillaProductoId });

                entity.HasOne(d => d.clasificacion)
                    .WithMany(p => p.ClasificacionesPlantillasProductos)
                    .HasForeignKey(d => d.clasificacionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClasificacionesPlantillasProductos_ClasificacionesProducto");

                entity.HasOne(d => d.plantillaProducto)
                    .WithMany(p => p.ClasificacionesPlantillasProductos)
                    .HasForeignKey(d => d.plantillaProductoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClasificacionesPlantillasProductos_PlantillasProductosAtributos");
            });

            modelBuilder.Entity<ClasificacionesPresentaciones>(entity =>
            {
                entity.HasKey(e => e.clasificacionPresentacionId)
                    .HasName("PK_ClasificacionesPresentacion");

                entity.Property(e => e.clasificacionPresentacionDescripcion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.criterioProducto)
                    .WithMany(p => p.ClasificacionesPresentaciones)
                    .HasForeignKey(d => d.criterioProductoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClasificacionesPresentacion_CriteriosPresentacion");
            });

            modelBuilder.Entity<ClasificacionesProductos>(entity =>
            {
                entity.HasKey(e => e.clasificacionProductoId)
                    .HasName("PK_ClasificacionesProducto");

                entity.Property(e => e.clasificacionProductoDescripcion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.clasificacionProductoEstado).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.criterioProducto)
                    .WithMany(p => p.ClasificacionesProductos)
                    .HasForeignKey(d => d.criterioProductoId)
                    .HasConstraintName("FK_ClasificacionesProducto_CriteriosProductos");
            });

            modelBuilder.Entity<Clientes>(entity =>
            {
                entity.HasKey(e => e.clienteId)
                    .HasName("PK__Cliente__71ABD08748A308A5");

                entity.Property(e => e.clienteCodigo)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.clienteCodigoEAN)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.clienteDireccion)
                    .IsRequired()
                    .HasMaxLength(1024)
                    .IsUnicode(false);

                entity.Property(e => e.clienteNombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.clienteTelefono)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.titular)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.titularId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cliente_Titulares");
            });

            modelBuilder.Entity<ConfiguracionVerificacion>(entity =>
            {
                entity.Property(e => e.configuracionVerificacionCodigo)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.configuracionVerificacionDescripcion)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.configuracionVerificacionPassword)
                    .HasMaxLength(6)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Contactos>(entity =>
            {
                entity.HasKey(e => e.contactoId);
            });

            modelBuilder.Entity<ContactosPuntosOperaciones>(entity =>
            {
                entity.HasKey(e => new { e.contactoId, e.puntoOperacionId })
                    .HasName("PK_ContactosPuntosOperacion");

                entity.HasOne(d => d.contacto)
                    .WithMany(p => p.ContactosPuntosOperaciones)
                    .HasForeignKey(d => d.contactoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ContactosPuntosOperacion_Contactos");

                entity.HasOne(d => d.puntoOperacion)
                    .WithMany(p => p.ContactosPuntosOperaciones)
                    .HasForeignKey(d => d.puntoOperacionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ContactosPuntosOperacion_PuntosOperacion");
            });

            modelBuilder.Entity<Contenedores>(entity =>
            {
                entity.HasKey(e => e.contenedorId);

                entity.HasIndex(e => e.contenedorCodigo)
                    .HasName("<Name of Missing Index, sysname,>");

                entity.Property(e => e.contenedorId).ValueGeneratedNever();

                entity.Property(e => e.contenedorCodigo)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.contenedorPadre)
                    .WithMany(p => p.InversecontenedorPadre)
                    .HasForeignKey(d => d.contenedorPadreId)
                    .HasConstraintName("FK_Contenedores_Contenedores");

                entity.HasOne(d => d.tipoContenedor)
                    .WithMany(p => p.Contenedores)
                    .HasForeignKey(d => d.tipoContenedorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Contenedores_TiposContenedores");
            });

            modelBuilder.Entity<ContenedoresSinSaldo>(entity =>
            {
                entity.HasKey(e => e.contenedorId)
                    .HasName("PK__Contened__2FA199D719FCB289");

                entity.HasIndex(e => e.Borrar)
                    .HasName("CSSBorrar");

                entity.Property(e => e.contenedorId).ValueGeneratedNever();

                entity.Property(e => e.Borrar)
                    .HasMaxLength(1)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Coordenadas>(entity =>
            {
                entity.HasKey(e => e.coordenadaId);

                entity.HasOne(d => d.coordenadaPadre)
                    .WithMany(p => p.InversecoordenadaPadre)
                    .HasForeignKey(d => d.coordenadaPadreId)
                    .HasConstraintName("FK_Coordenadas_Coordenadas");

                entity.HasOne(d => d.puntoOperacion)
                    .WithMany(p => p.Coordenadas)
                    .HasForeignKey(d => d.puntoOperacionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Coordenadas_PuntosOperacion");

                entity.HasOne(d => d.tipoCoordenadaNavigation)
                    .WithMany(p => p.Coordenadas)
                    .HasForeignKey(d => d.tipoCoordenada)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Coordenadas_TipoCoordenada");
            });

            modelBuilder.Entity<CriteriosPresentaciones>(entity =>
            {
                entity.HasKey(e => e.criterioPresentacionId)
                    .HasName("PK_CriteriosPresentacion");

                entity.Property(e => e.criterioPresentacionDescripcion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CriteriosProductos>(entity =>
            {
                entity.HasKey(e => e.criterioProductoId);

                entity.Property(e => e.criterioProductoDescripcion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.criterioProductoEstado).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<CrossDocking>(entity =>
            {
                entity.Property(e => e.cantidadPreparada).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.cantidadRestante).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.cantidadSolicitada).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<Custodios>(entity =>
            {
                entity.HasKey(e => e.custodioId);

                entity.Property(e => e.custodioCodigo)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.custodioDescripcion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.ordenante)
                    .WithMany(p => p.Custodios)
                    .HasForeignKey(d => d.ordenanteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Custodios_Ordenantes");
            });

            modelBuilder.Entity<Despachos>(entity =>
            {
                entity.HasKey(e => e.despachoId);

                entity.Property(e => e.despachoFecha)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.HasOne(d => d.usuario)
                    .WithMany(p => p.Despachos)
                    .HasForeignKey(d => d.usuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Despachos_Usuarios");
            });

            modelBuilder.Entity<DespachosDetalle>(entity =>
            {
                entity.HasKey(e => e.despachoDetalleId);

                entity.HasIndex(e => e.despachoEstado)
                    .HasName("ix_DespachosDetalle_DespachoEstado");

                entity.HasIndex(e => e.despachoId)
                    .HasName("ix_DespachosDetalle_despachoId");

                entity.HasIndex(e => e.pedidoDetalleId)
                    .HasName("ix_DespachosDetalle_pedidoDetalleId");

                entity.HasIndex(e => e.pedidoId)
                    .HasName("NonClusteredIndex-20200207-145017");

                entity.HasIndex(e => e.presentacionId)
                    .HasName("ix_DespachosDetalle_presentacionId");

                entity.HasIndex(e => e.ruteoDetalleId)
                    .HasName("ix_DespachosDetalle_ruteoDetalleId");

                entity.HasIndex(e => e.ruteoId)
                    .HasName("ix_DespachosDetalle_ruteoId");

                entity.HasIndex(e => e.ubicacionActualId)
                    .HasName("ix_DespachosDetalle_ubicacionActualId");

                entity.HasIndex(e => e.ubicacionId)
                    .HasName("ix_DespachosDetalle_ubicacionId");

                entity.HasIndex(e => e.usuarioId)
                    .HasName("ix_DespachosDetalle_usuarioId");

                entity.Property(e => e.despachoDetalleCantDespachada)
                    .HasColumnType("decimal(17, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.despachoDetalleCantNovedad).HasColumnType("decimal(17, 2)");

                entity.Property(e => e.despachoDetalleCantPreparada).HasColumnType("decimal(17, 2)");

                entity.Property(e => e.despachoDetalleCantSolicitada).HasColumnType("decimal(17, 2)");

                entity.Property(e => e.despachoDetalleCantTotal)
                    .HasColumnType("decimal(17, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.despachoDetalleFechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.despachoDetalleFechaModificacion).HasColumnType("datetime");

                entity.Property(e => e.usuarioIdEstado).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.despacho)
                    .WithMany(p => p.DespachosDetalle)
                    .HasForeignKey(d => d.despachoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DespachosDetalle_despachos");

                entity.HasOne(d => d.novedad)
                    .WithMany(p => p.DespachosDetalle)
                    .HasForeignKey(d => d.novedadId)
                    .HasConstraintName("FK_DespachosDetalle_Novedades");

                entity.HasOne(d => d.pedido)
                    .WithMany(p => p.DespachosDetalle)
                    .HasForeignKey(d => d.pedidoId)
                    .HasConstraintName("FK_despachoDetalle_Pedidos");

                entity.HasOne(d => d.presentacion)
                    .WithMany(p => p.DespachosDetalle)
                    .HasForeignKey(d => d.presentacionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_despachoDetalle_Presentaciones");

                entity.HasOne(d => d.ruteoDetalle)
                    .WithMany(p => p.DespachosDetalle)
                    .HasForeignKey(d => d.ruteoDetalleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_despachoDetalle_RuteosDetalle");

                entity.HasOne(d => d.ruteo)
                    .WithMany(p => p.DespachosDetalle)
                    .HasForeignKey(d => d.ruteoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_despachoDetalle_Ruteos");

                entity.HasOne(d => d.ubicacion)
                    .WithMany(p => p.DespachosDetalle)
                    .HasForeignKey(d => d.ubicacionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_despachoDetalle_Ubicaciones");

                entity.HasOne(d => d.usuarioIdDespachoNavigation)
                    .WithMany(p => p.DespachosDetalle)
                    .HasForeignKey(d => d.usuarioIdDespacho)
                    .HasConstraintName("FK_DespachosDetalle_Usuarios");
            });

            modelBuilder.Entity<DespachosPoquitos>(entity =>
            {
                entity.HasKey(e => e.DespachoPoquitosId)
                    .HasName("PK__Despacho__40B5E8CF5820A4B0");

                entity.Property(e => e.CantidadDespachada).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.CantidadPedido).HasColumnType("decimal(18, 4)");
            });

            modelBuilder.Entity<DetalleUnidadesEscalares>(entity =>
            {
                entity.HasKey(e => e.detalleUnidadEscalarId);

                entity.Property(e => e.detalleUnidadEscalarCantidad).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.detalleUnidadEscalarCodigo)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.detalleUnidadEscalarDescripcion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.unidadEscalar)
                    .WithMany(p => p.DetalleUnidadesEscalares)
                    .HasForeignKey(d => d.unidadEscalarId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DetalleUnidadesEscalares_UnidadesEscalares");
            });

            modelBuilder.Entity<Devoluciones>(entity =>
            {
                entity.HasKey(e => e.devolucionId)
                    .HasName("PK__Devoluci__1A2AB24890C21713");

                entity.Property(e => e.cantidadEntrada).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.cantidadSalida).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.proceso)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Documentos>(entity =>
            {
                entity.HasKey(e => e.documentoId);

                entity.Property(e => e.documentoCodigo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.documentoNombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.documentoSerial)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.documentoVigenciaFinal).HasColumnType("datetime");

                entity.Property(e => e.documentoVigenciaInicial).HasColumnType("datetime");

                entity.HasOne(d => d.bodegaLogicaCombo)
                    .WithMany(p => p.DocumentosbodegaLogicaCombo)
                    .HasForeignKey(d => d.bodegaLogicaComboId)
                    .HasConstraintName("FK_Documentos_BodegasLogicas1");

                entity.HasOne(d => d.bodegaLogica)
                    .WithMany(p => p.DocumentosbodegaLogica)
                    .HasForeignKey(d => d.bodegaLogicaId)
                    .HasConstraintName("FK_Documentos_BodegasLogicas");

                entity.HasOne(d => d.titular)
                    .WithMany(p => p.Documentos)
                    .HasForeignKey(d => d.titularId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Documentos_Titulares");
            });

            modelBuilder.Entity<DocumentosDetalle>(entity =>
            {
                entity.HasKey(e => e.documentoDetalleId);

                entity.Property(e => e.documentoDetalleCodigo)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.documentoDetalleMetodo)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.documentoDetalleNombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.documento)
                    .WithMany(p => p.DocumentosDetalle)
                    .HasForeignKey(d => d.documentoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DocumentosDetalle_Documentos");
            });

            modelBuilder.Entity<Estaciones>(entity =>
            {
                entity.HasKey(e => e.estacionId);

                entity.Property(e => e.estacionDescripcion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.bodegaLogica)
                    .WithMany(p => p.Estaciones)
                    .HasForeignKey(d => d.bodegaLogicaId)
                    .HasConstraintName("FK_Estaciones_BodegasLogicas");

                entity.HasOne(d => d.operacion)
                    .WithMany(p => p.Estaciones)
                    .HasForeignKey(d => d.operacionId)
                    .HasConstraintName("FK_Estaciones_Operaciones");
            });

            modelBuilder.Entity<EstacionesPerifericos>(entity =>
            {
                entity.HasKey(e => new { e.estacionId, e.PerifericoId });

                entity.HasOne(d => d.Periferico)
                    .WithMany(p => p.EstacionesPerifericos)
                    .HasForeignKey(d => d.PerifericoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EstacionesPerifericos_Perifericos");

                entity.HasOne(d => d.estacion)
                    .WithMany(p => p.EstacionesPerifericos)
                    .HasForeignKey(d => d.estacionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EstacionesPerifericos_Estaciones");
            });

            modelBuilder.Entity<Estados>(entity =>
            {
                entity.HasKey(e => e.estadoId);

                entity.Property(e => e.estadoCodigo)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.estadoCodigoDANE)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.estadoNombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.pais)
                    .WithMany(p => p.Estados)
                    .HasForeignKey(d => d.paisId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Estados_Paises");
            });

            modelBuilder.Entity<Grupos>(entity =>
            {
                entity.HasKey(e => e.grupoId);

                entity.Property(e => e.grupoId).ValueGeneratedNever();

                entity.Property(e => e.grupoCodigo)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.grupoNombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.puntoOperacion)
                    .WithMany(p => p.Grupos)
                    .HasForeignKey(d => d.puntoOperacionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Grupos_Grupos");
            });

            modelBuilder.Entity<GruposListas>(entity =>
            {
                entity.HasKey(e => e.grupoListaId);

                entity.Property(e => e.grupoListaId).ValueGeneratedNever();

                entity.Property(e => e.grupoListaCodigo)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.grupoListaNombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<HistoricosPlantillas>(entity =>
            {
                entity.HasKey(e => e.historicoPlantillaId);

                entity.Property(e => e.historicoPlantillaFechaModificacion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.historicoPlantillaNombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.historicoPlantillaUsuario)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.historicoPlantillaValorActual)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.historicoPlantillaValorAnterior)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Identificaciones>(entity =>
            {
                entity.HasKey(e => e.identificacionId);

                entity.Property(e => e.identificacionCodigo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("((100))");

                entity.HasOne(d => d.presentacion)
                    .WithMany(p => p.Identificaciones)
                    .HasForeignKey(d => d.presentacionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Identificaciones_Presentaciones");

                entity.HasOne(d => d.tipoIdentificacion)
                    .WithMany(p => p.Identificaciones)
                    .HasForeignKey(d => d.tipoIdentificacionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Identificaciones_TiposIdentificacion");
            });

            modelBuilder.Entity<IdentificadorApp>(entity =>
            {
                entity.Property(e => e.IdentificadorAppCodigo)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.IdentificadorAppDescripcion)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.IdentificadorAppFormato)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<InformeRuteosINFO1>(entity =>
            {
                entity.HasKey(e => e.ruteoINFOID)
                    .HasName("PK__InformeR__5D53E35E7DEF4D15");

                entity.Property(e => e.bahiaDescripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.pedidoProcesado)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ruteoFecha).HasColumnType("datetime");

                entity.Property(e => e.ruteoPedidoEstado)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ruteoPedidoFechaCierre).HasColumnType("datetime");

                entity.Property(e => e.ruteoPedidoFechaCreacion).HasColumnType("datetime");
            });

            modelBuilder.Entity<Instalaciones>(entity =>
            {
                entity.HasKey(e => e.instalacionId)
                    .HasName("PK_Instaciones");

                entity.Property(e => e.instalacionId).ValueGeneratedNever();

                entity.Property(e => e.instalacionCodigo)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.instalacionDescripcion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Inventarios>(entity =>
            {
                entity.HasKey(e => e.InventarioId);

                entity.Property(e => e.InventarioFecha)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.HasOne(d => d.presentacion)
                    .WithMany(p => p.Inventarios)
                    .HasForeignKey(d => d.presentacionId)
                    .HasConstraintName("FK_Inventarios_Presentaciones");

                entity.HasOne(d => d.ubicacion)
                    .WithMany(p => p.Inventarios)
                    .HasForeignKey(d => d.ubicacionId)
                    .HasConstraintName("FK_Inventarios_Ubicaciones");

                entity.HasOne(d => d.usuario)
                    .WithMany(p => p.Inventarios)
                    .HasForeignKey(d => d.usuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Inventarios_Usuarios");
            });

            modelBuilder.Entity<ListasPuntosOperacion>(entity =>
            {
                entity.HasKey(e => e.listaPuntoOperacionId);

                entity.Property(e => e.listaPuntoOperacionDescripcion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Maquinas>(entity =>
            {
                entity.HasKey(e => e.maquinaId);

                entity.HasIndex(e => e.maquinaIP)
                    .HasName("UQ__Maquinas__A76D4B2122D2EB43")
                    .IsUnique();

                entity.Property(e => e.maquinaCodigo)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.maquinaIP)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Motivos>(entity =>
            {
                entity.HasKey(e => e.motivoId);

                entity.Property(e => e.motivoCodigo)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.motivoDescripcion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Novedades>(entity =>
            {
                entity.HasKey(e => e.novedadId);

                entity.Property(e => e.novedadAfectaSaldo)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.novedadCodigo)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.novedadDescripcion)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.novedadNombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.proceso)
                    .WithMany(p => p.Novedades)
                    .HasForeignKey(d => d.procesoId)
                    .HasConstraintName("FK_Novedades_Procesos");
            });

            modelBuilder.Entity<NovedadesAcciones>(entity =>
            {
                entity.HasKey(e => e.novedadAccionId);

                entity.Property(e => e.novedadAccion)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.novedadAccionCodigo)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.novedadAccionNombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Operaciones>(entity =>
            {
                entity.HasKey(e => e.operacionId);

                entity.Property(e => e.operacionDescripcion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Ordenantes>(entity =>
            {
                entity.HasKey(e => e.ordenanteId);

                entity.Property(e => e.ordenanteCodigo)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ordenanteDescripcion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<OrdenesEmpaque>(entity =>
            {
                entity.HasKey(e => e.ordenEmpaqueId)
                    .HasName("PK__OrdenesEmpaque__73DF11DEB0420F27");

                entity.Property(e => e.ordenEmpaqueClientePreferente)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ordenEmpaqueFechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.ordenEmpaqueFechaFinalizacion).HasColumnType("datetime");

                entity.Property(e => e.ordenEmpaqueFechaNovedad).HasColumnType("datetime");

                entity.HasOne(d => d.documento)
                    .WithMany(p => p.OrdenesEmpaque)
                    .HasForeignKey(d => d.documentoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrdenesEmpaque_Documentos");

                entity.HasOne(d => d.estacion)
                    .WithMany(p => p.OrdenesEmpaque)
                    .HasForeignKey(d => d.estacionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrdenesEmpaque_Estaciones");

                entity.HasOne(d => d.novedad)
                    .WithMany(p => p.OrdenesEmpaque)
                    .HasForeignKey(d => d.novedadId)
                    .HasConstraintName("FK_OrdenesEmpaque_Novedades");

                entity.HasOne(d => d.presentacion)
                    .WithMany(p => p.OrdenesEmpaque)
                    .HasForeignKey(d => d.presentacionId)
                    .HasConstraintName("FK_OrdenesEmpaque_Presentaciones");

                entity.HasOne(d => d.producto)
                    .WithMany(p => p.OrdenesEmpaque)
                    .HasForeignKey(d => d.productoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrdenesEmpaque_Productos");

                entity.HasOne(d => d.puntoOperacion)
                    .WithMany(p => p.OrdenesEmpaque)
                    .HasForeignKey(d => d.puntoOperacionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrdenesEmpaque_PuntosOperaciones");

                entity.HasOne(d => d.usuario)
                    .WithMany(p => p.OrdenesEmpaque)
                    .HasForeignKey(d => d.usuarioId)
                    .HasConstraintName("FK_OrdenesEmpaque_Usuarios");
            });

            modelBuilder.Entity<PLANO>(entity =>
            {
                entity.Property(e => e.Fecha).HasColumnType("datetime");
            });

            modelBuilder.Entity<Packing>(entity =>
            {
                entity.Property(e => e.packingFecha)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.HasOne(d => d.usuario)
                    .WithMany(p => p.Packing)
                    .HasForeignKey(d => d.usuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Packing_Usuarios");
            });

            modelBuilder.Entity<PackingDetalle>(entity =>
            {
                entity.HasIndex(e => e.packingEstado)
                    .HasName("ix_packingDetalle_packingEstado");

                entity.HasIndex(e => e.packingId)
                    .HasName("ix_packingDetalle_packingId");

                entity.HasIndex(e => e.pedidoDetalleId)
                    .HasName("ix_packingDetalle_pedidoDetalleId");

                entity.HasIndex(e => e.pedidoId)
                    .HasName("ix_packingDetalle_pedidoId");

                entity.HasIndex(e => e.presentacionId)
                    .HasName("ix_packingDetalle_presentacionId");

                entity.HasIndex(e => e.ruteoDetalleId)
                    .HasName("ix_packingDetalle_ruteoDetalleId");

                entity.HasIndex(e => e.ruteoId)
                    .HasName("ix_packingDetalle_ruteoId");

                entity.HasIndex(e => e.ubicacionBahiaId)
                    .HasName("ix_packingDetalle_ubicacionBahiaId");

                entity.HasIndex(e => e.ubicacionMedioId)
                    .HasName("ix_packingDetalle_ubicacionMedioId");

                entity.HasIndex(e => e.usuarioId)
                    .HasName("ix_packingDetalle_usuarioId");

                entity.Property(e => e.packingDetalleCantNovedad).HasColumnType("decimal(17, 2)");

                entity.Property(e => e.packingDetalleCantPreparada).HasColumnType("decimal(17, 2)");

                entity.Property(e => e.packingDetalleCantSolicitada).HasColumnType("decimal(17, 2)");

                entity.Property(e => e.packingDetalleCantTotal)
                    .HasColumnType("decimal(17, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.packingDetalleFechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.packingDetalleFechaModificacion).HasColumnType("datetime");

                entity.HasOne(d => d.novedad)
                    .WithMany(p => p.PackingDetalle)
                    .HasForeignKey(d => d.novedadId)
                    .HasConstraintName("FK_PackingDetalle_Novedades");

                entity.HasOne(d => d.packing)
                    .WithMany(p => p.PackingDetalle)
                    .HasForeignKey(d => d.packingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PackingDetalle_Packing");

                entity.HasOne(d => d.pedido)
                    .WithMany(p => p.PackingDetalle)
                    .HasForeignKey(d => d.pedidoId)
                    .HasConstraintName("FK_PackingDetalle_Pedidos");

                entity.HasOne(d => d.presentacion)
                    .WithMany(p => p.PackingDetalle)
                    .HasForeignKey(d => d.presentacionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PackingDetalle_Presentaciones");

                entity.HasOne(d => d.ruteoDetalle)
                    .WithMany(p => p.PackingDetalle)
                    .HasForeignKey(d => d.ruteoDetalleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PackingDetalle_RuteosDetalle");

                entity.HasOne(d => d.ruteo)
                    .WithMany(p => p.PackingDetalle)
                    .HasForeignKey(d => d.ruteoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PackingDetalle_Ruteos");

                entity.HasOne(d => d.ubicacionMedio)
                    .WithMany(p => p.PackingDetalle)
                    .HasForeignKey(d => d.ubicacionMedioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PackingDetalle_Ubicaciones");
            });

            modelBuilder.Entity<Paises>(entity =>
            {
                entity.HasKey(e => e.paisId);

                entity.Property(e => e.paisCodigo)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.paisCodigoDANE)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.paisNombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Pedidos>(entity =>
            {
                entity.HasKey(e => e.pedidoId)
                    .HasName("PK__Pedido__09BA14307B3C60ED");

                entity.Property(e => e.pedidoConsecutivoERP)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.pedidoDocumentoERP)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.pedidoFecha).HasColumnType("datetime");

                entity.Property(e => e.pedidoFechaCarga).HasColumnType("datetime");

                entity.Property(e => e.pedidoFechaEntrega).HasColumnType("datetime");

                entity.Property(e => e.pedidoFechaMalla).HasColumnType("datetime");

                entity.Property(e => e.pedidoFuente)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.pedidoObservacion)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.puntoOperacion)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.puntoOperacionId)
                    .HasConstraintName("FK_Pedidos_PuntosOperaciones");

                entity.HasOne(d => d.sucursal)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.sucursalId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pedido_Sucursal");
            });

            modelBuilder.Entity<PedidosDetalle>(entity =>
            {
                entity.HasKey(e => new { e.pedidoId, e.pedidoDetalleId })
                    .HasName("PK__PedidoDe__289B42F40F046596");

                entity.Property(e => e.pedidoDetalleCantidad).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.pedidoDetalleFecha).HasColumnType("datetime");

                entity.HasOne(d => d.pedido)
                    .WithMany(p => p.PedidosDetalle)
                    .HasForeignKey(d => d.pedidoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PedidoDetalle_Pedido");

                entity.HasOne(d => d.presentacion)
                    .WithMany(p => p.PedidosDetalle)
                    .HasForeignKey(d => d.presentacionId)
                    .HasConstraintName("FK_PedidosDetalle_Presentaciones");

                entity.HasOne(d => d.producto)
                    .WithMany(p => p.PedidosDetalle)
                    .HasForeignKey(d => d.productoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PedidosDetalle_Productos");

                entity.HasOne(d => d.puntoEnvio)
                    .WithMany(p => p.PedidosDetalle)
                    .HasForeignKey(d => d.puntoEnvioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PedidoDetalle_PuntoEnvio1");
            });

            modelBuilder.Entity<PedidosPreRuteo>(entity =>
            {
                entity.HasKey(e => new { e.pedidoId, e.UserNameId });

                entity.Property(e => e.Estado).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<Perifericos>(entity =>
            {
                entity.HasKey(e => e.PerifericoId);

                entity.Property(e => e.PerifericoDescripcion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.tipoPeriferico)
                    .WithMany(p => p.Perifericos)
                    .HasForeignKey(d => d.tipoPerifericoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Perifericos_TiposPeriferico");
            });

            modelBuilder.Entity<PickingControl>(entity =>
            {
                entity.HasKey(e => e.controlId)
                    .HasName("PK__PickingC__6306E63B2D10FD37");

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.contenedorTag)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ubicacionTag)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PlantillasContenedores>(entity =>
            {
                entity.HasKey(e => new { e.plantillaContenedorAtributoId, e.contenedorId });

                entity.HasOne(d => d.contenedor)
                    .WithMany(p => p.PlantillasContenedores)
                    .HasForeignKey(d => d.contenedorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PlantillasContenedores_Contenedores");

                entity.HasOne(d => d.plantillaContenedorAtributo)
                    .WithMany(p => p.PlantillasContenedores)
                    .HasForeignKey(d => d.plantillaContenedorAtributoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PlantillasContenedores_PlantillasContenedoresAtributos");
            });

            modelBuilder.Entity<PlantillasContenedoresAtributos>(entity =>
            {
                entity.HasKey(e => e.plantillaContenedorAtributoId);

                entity.Property(e => e.plantillaContenedorAtributoDescripcion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PlantillasLotes>(entity =>
            {
                entity.HasKey(e => e.plantillaLoteId);

                entity.Property(e => e.plantillaLoteDescripcion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PlantillasLotesAtributos>(entity =>
            {
                entity.HasKey(e => new { e.plantillaLoteId, e.atributoLoteId });

                entity.HasOne(d => d.atributoLote)
                    .WithMany(p => p.PlantillasLotesAtributos)
                    .HasForeignKey(d => d.atributoLoteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PlantillasLotesAtributos_AtributosLotes");

                entity.HasOne(d => d.plantillaLote)
                    .WithMany(p => p.PlantillasLotesAtributos)
                    .HasForeignKey(d => d.plantillaLoteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PlantillasLotesAtributos_PlantillasLotes");
            });

            modelBuilder.Entity<PlantillasProductos>(entity =>
            {
                entity.HasKey(e => e.plantillaProductoId);

                entity.HasOne(d => d.plantillaProductoAtributo)
                    .WithMany(p => p.PlantillasProductos)
                    .HasForeignKey(d => d.plantillaProductoAtributoId)
                    .HasConstraintName("FK_PlantillasProductos_PlantillasProductosAtributos");

                entity.HasOne(d => d.producto)
                    .WithMany(p => p.PlantillasProductos)
                    .HasForeignKey(d => d.productoId)
                    .HasConstraintName("FK_PlantillasProductos_Productos");
            });

            modelBuilder.Entity<PlantillasProductosAtributos>(entity =>
            {
                entity.HasKey(e => e.plantillaProductoAtributoId);

                entity.Property(e => e.plantillaProductoAtributoDescripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.plantillaProductoAtributoEstado).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<PreRuteos>(entity =>
            {
                entity.HasKey(e => e.preRuteoId)
                    .HasName("PK__PreRuteo__CD4C7BE719217ACB");

                entity.Property(e => e.preRuteoFecha).HasColumnType("datetime");

                entity.Property(e => e.preRuteoUsuario)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PreRuteosDetalle>(entity =>
            {
                entity.HasKey(e => new { e.preRuteoId, e.preRuteoDetalleId })
                    .HasName("PK__PreRuteo__D1D2DE1862E57593");

                entity.Property(e => e.preRuteoDetalleId).ValueGeneratedOnAdd();

                entity.Property(e => e.preRuteoDetalleCantNovedad).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.preRuteoDetalleCantRequerida).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.preRuteoDetalleCantidad).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.preRuteoDetalleFechaModificacion).HasColumnType("datetime");

                entity.HasOne(d => d.bodegaLogica)
                    .WithMany(p => p.PreRuteosDetalle)
                    .HasForeignKey(d => d.bodegaLogicaId)
                    .HasConstraintName("FK_PreRuteosDetalle_BodegasLogicas");

                entity.HasOne(d => d.contenedor)
                    .WithMany(p => p.PreRuteosDetalle)
                    .HasForeignKey(d => d.contenedorId)
                    .HasConstraintName("FK_PreRuteoDetalle_Coordenadas");

                entity.HasOne(d => d.preRuteo)
                    .WithMany(p => p.PreRuteosDetalle)
                    .HasForeignKey(d => d.preRuteoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PreRuteoDetalle_PreRuteo");

                entity.HasOne(d => d.presentacion)
                    .WithMany(p => p.PreRuteosDetalle)
                    .HasForeignKey(d => d.presentacionId)
                    .HasConstraintName("FK_PreRuteoDetalle_Presentaciones");

                entity.HasOne(d => d.saldoUbicacion)
                    .WithMany(p => p.PreRuteosDetalle)
                    .HasForeignKey(d => d.saldoUbicacionId)
                    .HasConstraintName("FK_PreRuteosDetalle_SaldosUbicaciones");

                entity.HasOne(d => d.ubicacion)
                    .WithMany(p => p.PreRuteosDetalle)
                    .HasForeignKey(d => d.ubicacionId)
                    .HasConstraintName("FK_PreRuteoDetalle_Ubicaciones");
            });

            modelBuilder.Entity<PreRuteosPedidos>(entity =>
            {
                entity.HasKey(e => new { e.preRuteoId, e.pedidoId });

                entity.HasOne(d => d.pedido)
                    .WithMany(p => p.PreRuteosPedidos)
                    .HasForeignKey(d => d.pedidoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PreRuteosPedidos_Pedidos");

                entity.HasOne(d => d.preRuteo)
                    .WithMany(p => p.PreRuteosPedidos)
                    .HasForeignKey(d => d.preRuteoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PreRuteosPedidos_PreRuteos");
            });

            modelBuilder.Entity<Presentaciones>(entity =>
            {
                entity.HasKey(e => e.presentacionId);

                entity.Property(e => e.presentacionAlto)
                    .HasColumnType("decimal(18, 4)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.presentacionAncho)
                    .HasColumnType("decimal(18, 4)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.presentacionCodigo)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.presentacionDescripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.presentacionOrden).HasDefaultValueSql("((0))");

                entity.Property(e => e.presentacionPesoBruto)
                    .HasColumnType("decimal(18, 4)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.presentacionPesoNeto)
                    .HasColumnType("decimal(18, 4)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.presentacionProfundidad)
                    .HasColumnType("decimal(18, 4)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.presentacionVolumen)
                    .HasColumnType("decimal(18, 4)")
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.longitudEscalar)
                    .WithMany(p => p.PresentacioneslongitudEscalar)
                    .HasForeignKey(d => d.longitudEscalarId)
                    .HasConstraintName("FK_Presentaciones_UnidadesEscalares");

                entity.HasOne(d => d.pesoEscalar)
                    .WithMany(p => p.PresentacionespesoEscalar)
                    .HasForeignKey(d => d.pesoEscalarId)
                    .HasConstraintName("FK_Presentaciones_pesoEscalar");

                entity.HasOne(d => d.producto)
                    .WithMany(p => p.Presentaciones)
                    .HasForeignKey(d => d.productoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Presentaciones_Productos");

                entity.HasOne(d => d.volumenEscalar)
                    .WithMany(p => p.PresentacionesvolumenEscalar)
                    .HasForeignKey(d => d.volumenEscalarId)
                    .HasConstraintName("FK_Presentaciones_VolumenUnidadesEscalares");
            });

            modelBuilder.Entity<PresentacionesClasificacion>(entity =>
            {
                entity.HasKey(e => new { e.clasificacionPresentacionId, e.presentacionId });

                entity.HasOne(d => d.clasificacionPresentacion)
                    .WithMany(p => p.PresentacionesClasificacion)
                    .HasForeignKey(d => d.clasificacionPresentacionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PresentacionesClasificacion_ClasificacionesPresentacion");

                entity.HasOne(d => d.presentacion)
                    .WithMany(p => p.PresentacionesClasificacion)
                    .HasForeignKey(d => d.presentacionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PresentacionesClasificacion_Presentaciones");
            });

            modelBuilder.Entity<Procesos>(entity =>
            {
                entity.HasKey(e => e.ProcesoId)
                    .HasName("PK__Procesos__1C00FFD03A438185");

                entity.Property(e => e.ProcesoCodigo)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ProcesoNombre)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Productos>(entity =>
            {
                entity.HasKey(e => e.productoId)
                    .HasName("PK_productos");

                entity.Property(e => e.productoCantidadEscalar)
                    .HasColumnType("decimal(18, 4)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.productoCodigo)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.productoCodigoAlternativo)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.productoDescripcion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.productoManejaLote).HasDefaultValueSql("((1))");

                entity.Property(e => e.productoUnidadInventario).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.titular)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.titularId)
                    .HasConstraintName("FK_Productos_Productos");

                entity.HasOne(d => d.unidadEscalar)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.unidadEscalarId)
                    .HasConstraintName("FK_Productos_UnidadesEscalares");

                entity.HasOne(d => d.unidadManejo)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.unidadManejoId)
                    .HasConstraintName("FK_Productos_UnidadesManejo");
            });

            modelBuilder.Entity<ProductosAtributos>(entity =>
            {
                entity.HasKey(e => new { e.productoId, e.productoPlantillaId });

                entity.Property(e => e.productoAtributoValor)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.producto)
                    .WithMany(p => p.ProductosAtributos)
                    .HasForeignKey(d => d.productoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductosAtributos_Productos");

                entity.HasOne(d => d.productoPlantilla)
                    .WithMany(p => p.ProductosAtributos)
                    .HasForeignKey(d => d.productoPlantillaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductosAtributos_PlantillasProductos");
            });

            modelBuilder.Entity<ProductosClasificaciones>(entity =>
            {
                entity.HasKey(e => new { e.productoId, e.clasificacionId });

                entity.HasOne(d => d.clasificacion)
                    .WithMany(p => p.ProductosClasificaciones)
                    .HasForeignKey(d => d.clasificacionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductosClasificaciones_ClasificacionesProducto");

                entity.HasOne(d => d.producto)
                    .WithMany(p => p.ProductosClasificaciones)
                    .HasForeignKey(d => d.productoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductosClasificaciones_Productos");
            });

            modelBuilder.Entity<ProductosCombos>(entity =>
            {
                entity.HasKey(e => new { e.productoIdCombo, e.presentacionIdDestino, e.presentacionIdCombo, e.productoIdDestino })
                    .HasName("PK__Producto__10F77F0761D524CF");

                entity.Property(e => e.productoComboCantidad).HasColumnType("decimal(18, 4)");

                entity.HasOne(d => d.presentacionIdComboNavigation)
                    .WithMany(p => p.ProductosCombospresentacionIdComboNavigation)
                    .HasForeignKey(d => d.presentacionIdCombo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductoCombo_Presentaciones");

                entity.HasOne(d => d.presentacionIdDestinoNavigation)
                    .WithMany(p => p.ProductosCombospresentacionIdDestinoNavigation)
                    .HasForeignKey(d => d.presentacionIdDestino)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductoCombo_Presentaciones1");

                entity.HasOne(d => d.productoIdComboNavigation)
                    .WithMany(p => p.ProductosCombosproductoIdComboNavigation)
                    .HasForeignKey(d => d.productoIdCombo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductoCombo_Productos1");

                entity.HasOne(d => d.productoIdDestinoNavigation)
                    .WithMany(p => p.ProductosCombosproductoIdDestinoNavigation)
                    .HasForeignKey(d => d.productoIdDestino)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductoCombo_Productos");
            });

            modelBuilder.Entity<ProductosContenedores>(entity =>
            {
                entity.HasKey(e => new { e.productoId, e.contenedorId });

                entity.HasOne(d => d.contenedor)
                    .WithMany(p => p.ProductosContenedores)
                    .HasForeignKey(d => d.contenedorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductosContenedores_Contenedores");

                entity.HasOne(d => d.producto)
                    .WithMany(p => p.ProductosContenedores)
                    .HasForeignKey(d => d.productoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductosContenedores_Productos");
            });

            modelBuilder.Entity<ProductosLotes>(entity =>
            {
                entity.HasKey(e => e.productoLoteId);

                entity.HasOne(d => d.plantillaLote)
                    .WithMany(p => p.ProductosLotes)
                    .HasForeignKey(d => d.plantillaLoteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductosLotes_PlantillasLotes");

                entity.HasOne(d => d.producto)
                    .WithMany(p => p.ProductosLotes)
                    .HasForeignKey(d => d.productoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductosLotes_Productos");
            });

            modelBuilder.Entity<ProductosSustituciones>(entity =>
            {
                entity.HasKey(e => e.productoSustitucionId)
                    .HasName("PK__Producto__AF219F0C369F1C9F");

                entity.Property(e => e.productoSustitucionCantidad).HasColumnType("decimal(18, 4)");
            });

            modelBuilder.Entity<PuntosEnvio>(entity =>
            {
                entity.HasKey(e => e.puntoEnvioId)
                    .HasName("PK__PuntoEnv__405A4C37D05CF31A");

                entity.Property(e => e.puntoEnvioCodigo)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.puntoEnvioCodigoEAN)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.puntoEnvioDireccion)
                    .IsRequired()
                    .HasMaxLength(1024)
                    .IsUnicode(false);

                entity.Property(e => e.puntoEnvioNombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.puntoEnvioTelefono)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.ciudad)
                    .WithMany(p => p.PuntosEnvio)
                    .HasForeignKey(d => d.ciudadId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PuntoEnvio_Ciudades");

                entity.HasOne(d => d.sucursal)
                    .WithMany(p => p.PuntosEnvio)
                    .HasForeignKey(d => d.sucursalId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PuntoEnvio_Sucursal");
            });

            modelBuilder.Entity<PuntosOperaciones>(entity =>
            {
                entity.HasKey(e => e.puntoOperacionId)
                    .HasName("PK_PuntosOperacion");

                entity.Property(e => e.puntoOperacionCodigo)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.puntoOperacionDescripcion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.puntoOperacionDireccion)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.centroOperacion)
                    .WithMany(p => p.PuntosOperaciones)
                    .HasForeignKey(d => d.centroOperacionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PuntosOperacion_CentrosOperacion");

                entity.HasOne(d => d.ciudad)
                    .WithMany(p => p.PuntosOperaciones)
                    .HasForeignKey(d => d.ciudadId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PuntosOperacion_Ciudades");

                entity.HasOne(d => d.custodio)
                    .WithMany(p => p.PuntosOperaciones)
                    .HasForeignKey(d => d.custodioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PuntosOperacion_Custodios");

                entity.HasOne(d => d.listaPuntoOperacion)
                    .WithMany(p => p.PuntosOperaciones)
                    .HasForeignKey(d => d.listaPuntoOperacionId)
                    .HasConstraintName("FK_PuntosOperacion_ListasPuntosOperacion");
            });

            modelBuilder.Entity<REVISIONIMPRESION>(entity =>
            {
                entity.Property(e => e.FECHA).HasColumnType("datetime");

                entity.Property(e => e.MENSAJE).IsUnicode(false);
            });

            modelBuilder.Entity<RFIDTag>(entity =>
            {
                entity.Property(e => e.RFIDTagId)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.GETDATE)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.RFIDTagAntena).HasMaxLength(50);

                entity.Property(e => e.RFIDTagContador)
                    .HasColumnType("numeric(18, 0)")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.RFIDTagEPC).HasMaxLength(50);

                entity.Property(e => e.RFIDTagEPCNueva).HasMaxLength(50);

                entity.Property(e => e.RFIDTagFecha).HasColumnType("datetime");

                entity.Property(e => e.RFIDTagInicioEvento).HasMaxLength(50);

                entity.Property(e => e.RFIDTagMaquina).HasMaxLength(50);

                entity.Property(e => e.RFIDTagRSSI).HasMaxLength(50);

                entity.Property(e => e.RFIDTagReader).HasMaxLength(50);

                entity.Property(e => e.RFIDTagTagEvento).HasMaxLength(50);

                entity.Property(e => e.RFIDTagTipo_EPC).HasMaxLength(50);
            });

            modelBuilder.Entity<Reglas>(entity =>
            {
                entity.HasKey(e => e.ReglaId);

                entity.HasOne(d => d.Producto)
                    .WithMany(p => p.Reglas)
                    .HasForeignKey(d => d.ProductoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reglas_Productos");

                entity.HasOne(d => d.PuntoEnvio)
                    .WithMany(p => p.Reglas)
                    .HasForeignKey(d => d.PuntoEnvioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reglas_PuntosEnvio");
            });

            modelBuilder.Entity<Revision_Modulo>(entity =>
            {
                entity.Property(e => e.fecha).HasColumnType("datetime");
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.HasKey(e => e.roleId);

                entity.Property(e => e.roleDescripcion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RutasGrupos>(entity =>
            {
                entity.HasKey(e => new { e.rutaId, e.GrupoId });
            });

            modelBuilder.Entity<RutasUbicaciones>(entity =>
            {
                entity.HasKey(e => e.rutaUbicacionId);
            });

            modelBuilder.Entity<Ruteos>(entity =>
            {
                entity.HasKey(e => e.ruteoId)
                    .HasName("PK__Ruteo__CD4C7BE719217ACB");

                entity.Property(e => e.ruteoId).ValueGeneratedNever();

                entity.Property(e => e.ruteoFecha).HasColumnType("datetime");

                entity.Property(e => e.ruteoUsuario)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RuteosDetalle>(entity =>
            {
                entity.HasKey(e => e.ruteoDetalleId);

                entity.HasIndex(e => e.bodegaLogicaId)
                    .HasName("ix_ruteosDetalle_bodegaLogicaId");

                entity.HasIndex(e => e.presentacionId)
                    .HasName("ix_ruteosDetalle_presentacionId");

                entity.HasIndex(e => e.ruteoDetalleEstado)
                    .HasName("ix_ruteosDetalle_ruteoDetalleEstado");

                entity.HasIndex(e => e.ruteoId)
                    .HasName("ix_ruteosDetalle_ruteoId");

                entity.HasIndex(e => e.ubicacionId)
                    .HasName("ix_ruteosDetalle_ubicacionId");

                entity.Property(e => e.Transaccion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ruteoDetalleCantNovedad).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.ruteoDetalleCantRequerida).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.ruteoDetalleCantidad).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.ruteoDetalleFechaCierreRuteo).HasColumnType("datetime");

                entity.HasOne(d => d.bodegaLogica)
                    .WithMany(p => p.RuteosDetalle)
                    .HasForeignKey(d => d.bodegaLogicaId)
                    .HasConstraintName("FK_RuteosDetalle_BodegasLogicas");

                entity.HasOne(d => d.contenedor)
                    .WithMany(p => p.RuteosDetalle)
                    .HasForeignKey(d => d.contenedorId)
                    .HasConstraintName("FK_RuteosDetalle_Coordenadas");

                entity.HasOne(d => d.presentacion)
                    .WithMany(p => p.RuteosDetalle)
                    .HasForeignKey(d => d.presentacionId)
                    .HasConstraintName("FK_RuteosDetalle_Presentaciones");

                entity.HasOne(d => d.ruteo)
                    .WithMany(p => p.RuteosDetalle)
                    .HasForeignKey(d => d.ruteoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RuteosDetalle_ruteo");

                entity.HasOne(d => d.ubicacion)
                    .WithMany(p => p.RuteosDetalle)
                    .HasForeignKey(d => d.ubicacionId)
                    .HasConstraintName("FK_RuteosDetalle_Ubicaciones");
            });

            modelBuilder.Entity<RuteosPedidos>(entity =>
            {
                entity.HasKey(e => new { e.ruteoId, e.pedidoId });

                entity.Property(e => e.ruteoPedidoFechaCIerre).HasColumnType("datetime");

                entity.Property(e => e.ruteoPedidoFechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.HasOne(d => d.pedido)
                    .WithMany(p => p.RuteosPedidos)
                    .HasForeignKey(d => d.pedidoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RuteosPedidos_Pedidos");

                entity.HasOne(d => d.ruteo)
                    .WithMany(p => p.RuteosPedidos)
                    .HasForeignKey(d => d.ruteoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RuteosPedidos_Ruteos");
            });

            modelBuilder.Entity<Saldos>(entity =>
            {
                entity.HasKey(e => e.saldoId);

                entity.HasIndex(e => e.productoId)
                    .HasName("UQ__Saldos__69E6E1554902C7A3")
                    .IsUnique();

                entity.Property(e => e.saldoComprometidoEscalar)
                    .HasColumnType("decimal(18, 4)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.saldoComprometidoManejo)
                    .HasColumnType("decimal(18, 4)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.saldoDisponibleEscalar)
                    .HasColumnType("decimal(18, 4)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.saldoDisponibleManejo)
                    .HasColumnType("decimal(18, 4)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.saldoInmovilizadoEscalar)
                    .HasColumnType("decimal(18, 4)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.saldoInmovilizadoManejo)
                    .HasColumnType("decimal(18, 4)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.saldoRealEscalar)
                    .HasColumnType("decimal(18, 4)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.saldoRealManejo)
                    .HasColumnType("decimal(18, 4)")
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.producto)
                    .WithOne(p => p.Saldos)
                    .HasForeignKey<Saldos>(d => d.productoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Saldos_Productos");
            });

            modelBuilder.Entity<SaldosDetalle>(entity =>
            {
                entity.HasKey(e => e.saldoDetalleId);

                entity.HasIndex(e => e.contenedorId)
                    .HasName("ix_SaldosDetalle_contenedorId");

                entity.HasIndex(e => e.ubicacionId)
                    .HasName("ix_SaldosDetalle_ubicacionId");

                entity.HasIndex(e => new { e.ubicacionId, e.saldoDetalleRealManejo })
                    .HasName("ix_saldosDetalle_ubicacionId_saldoDetalleRealManejo");

                entity.HasIndex(e => new { e.presentacionId, e.valorProductoLoteId, e.bodegaLogicaId, e.saldoDetalleRealManejo, e.saldoDetalleComprometidoManejo, e.ubicacionId })
                    .HasName("ix_SaldosDetalle_ubicacionId_Extend");

                entity.HasIndex(e => new { e.saldoId, e.presentacionId, e.valorProductoLoteId, e.ubicacionId, e.saldoDetalleComprometidoManejo, e.saldoDetalleRealManejo })
                    .HasName("<Name of Missing Index, sysname,>");

                entity.Property(e => e.saldoDetalleComprometidoEscalar)
                    .HasColumnType("decimal(18, 4)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.saldoDetalleComprometidoManejo)
                    .HasColumnType("decimal(18, 4)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.saldoDetalleDisponibleEscalar)
                    .HasColumnType("decimal(18, 4)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.saldoDetalleDisponibleManejo)
                    .HasColumnType("decimal(18, 4)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.saldoDetalleInmovilizadoEscalar)
                    .HasColumnType("decimal(18, 4)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.saldoDetalleInmovilizadoManejo)
                    .HasColumnType("decimal(18, 4)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.saldoDetalleRealEscalar)
                    .HasColumnType("decimal(18, 4)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.saldoDetalleRealManejo)
                    .HasColumnType("decimal(18, 4)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.updatesSecuencia).IsUnicode(false);

                entity.HasOne(d => d.bodegaLogica)
                    .WithMany(p => p.SaldosDetalle)
                    .HasForeignKey(d => d.bodegaLogicaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SaldosDetalle_BodegasLogicas");

                entity.HasOne(d => d.contenedor)
                    .WithMany(p => p.SaldosDetalle)
                    .HasForeignKey(d => d.contenedorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SaldosDetalle_Contenedores");

                entity.HasOne(d => d.presentacion)
                    .WithMany(p => p.SaldosDetalle)
                    .HasForeignKey(d => d.presentacionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SaldosDetalle_Presentaciones");

                entity.HasOne(d => d.saldo)
                    .WithMany(p => p.SaldosDetalle)
                    .HasForeignKey(d => d.saldoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SaldosDetalle_Saldos");

                entity.HasOne(d => d.ubicacion)
                    .WithMany(p => p.SaldosDetalle)
                    .HasForeignKey(d => d.ubicacionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SaldosDetalle_Ubicaciones");

                entity.HasOne(d => d.valorProductoLote)
                    .WithMany(p => p.SaldosDetalle)
                    .HasForeignKey(d => d.valorProductoLoteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SaldosDetalle_ValoresPlantillasLotes");
            });

            modelBuilder.Entity<SaldosUbicaciones>(entity =>
            {
                entity.HasKey(e => e.saldoUbicacionId);

                entity.Property(e => e.saldoUbicacionComprometidoEscalar)
                    .HasColumnType("decimal(18, 4)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.saldoUbicacionComprometidoManejo)
                    .HasColumnType("decimal(18, 4)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.saldoUbicacionDisponibleEscalar)
                    .HasColumnType("decimal(18, 4)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.saldoUbicacionDisponibleManejo)
                    .HasColumnType("decimal(18, 4)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.saldoUbicacionInmovilizadoEscalar)
                    .HasColumnType("decimal(18, 4)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.saldoUbicacionInmovilizadoManejo)
                    .HasColumnType("decimal(18, 4)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.saldoUbicacionRealEscalar)
                    .HasColumnType("decimal(18, 4)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.saldoUbicacionRealManejo)
                    .HasColumnType("decimal(18, 4)")
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.saldo)
                    .WithMany(p => p.SaldosUbicaciones)
                    .HasForeignKey(d => d.saldoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SaldosUbicaciones_Saldos");

                entity.HasOne(d => d.ubicacion)
                    .WithMany(p => p.SaldosUbicaciones)
                    .HasForeignKey(d => d.ubicacionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SaldosUbicaciones_Ubicaciones");
            });

            modelBuilder.Entity<Siesa_OrdenEmpaque_Auditoria>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.ArchivoNombre)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Error_Auditoria).IsUnicode(false);

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.UbicacionId).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ordenEmpaqueId).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.presentacionId).HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<Sucursales>(entity =>
            {
                entity.HasKey(e => e.sucursalId)
                    .HasName("PK__Sucursal__6CB482E1CE9CA881");

                entity.Property(e => e.sucursalCodigo)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.sucursalCodigoEAN)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.sucursalDireccion)
                    .IsRequired()
                    .HasMaxLength(1024)
                    .IsUnicode(false);

                entity.Property(e => e.sucursalNombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.sucursalTelefono)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.ciudad)
                    .WithMany(p => p.Sucursales)
                    .HasForeignKey(d => d.ciudadId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sucursal_Ciudades1");
            });

            modelBuilder.Entity<TABLAREVISION>(entity =>
            {
                entity.Property(e => e.FECHA).HasColumnType("datetime");

                entity.Property(e => e.RESULTADO).IsUnicode(false);

                entity.Property(e => e.ubicacionCodigoCambio)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TXPacking>(entity =>
            {
                entity.Property(e => e.continuidadActivada).HasDefaultValueSql("((0))");

                entity.Property(e => e.tXPackingRealEscalar)
                    .HasColumnType("decimal(18, 4)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.tXPackingRealManejo)
                    .HasColumnType("decimal(18, 4)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.txPackingFechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.txPackingFechaModificacion).HasColumnType("datetime");

                entity.HasOne(d => d.bodegaLogica)
                    .WithMany(p => p.TXPacking)
                    .HasForeignKey(d => d.bodegaLogicaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tXPacking_BodegasLogicas");

                entity.HasOne(d => d.contenedor)
                    .WithMany(p => p.TXPacking)
                    .HasForeignKey(d => d.contenedorId)
                    .HasConstraintName("FK_tXPacking_Contenedores");

                entity.HasOne(d => d.identificacion)
                    .WithMany(p => p.TXPacking)
                    .HasForeignKey(d => d.identificacionId)
                    .HasConstraintName("FK_tXPacking_Identificaciones");

                entity.HasOne(d => d.novedad)
                    .WithMany(p => p.TXPacking)
                    .HasForeignKey(d => d.novedadId)
                    .HasConstraintName("FK_tXPacking_Novedades");

                entity.HasOne(d => d.presentacion)
                    .WithMany(p => p.TXPacking)
                    .HasForeignKey(d => d.presentacionId)
                    .HasConstraintName("FK_tXPacking_Presentaciones");

                entity.HasOne(d => d.ubicacion)
                    .WithMany(p => p.TXPacking)
                    .HasForeignKey(d => d.ubicacionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tXPacking_Ubicaciones");
            });

            modelBuilder.Entity<TXPicking>(entity =>
            {
                entity.Property(e => e.continuidadActivada).HasDefaultValueSql("((0))");

                entity.Property(e => e.tXPickingRealEscalar)
                    .HasColumnType("decimal(18, 4)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.tXPickingRealManejo)
                    .HasColumnType("decimal(18, 4)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.txPickingFechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.txPickingFechaModificacion).HasColumnType("datetime");

                entity.HasOne(d => d.bodegaLogica)
                    .WithMany(p => p.TXPicking)
                    .HasForeignKey(d => d.bodegaLogicaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TXPicking_BodegasLogicas");

                entity.HasOne(d => d.contenedor)
                    .WithMany(p => p.TXPicking)
                    .HasForeignKey(d => d.contenedorId)
                    .HasConstraintName("FK_TXPicking_Contenedores");

                entity.HasOne(d => d.identificacion)
                    .WithMany(p => p.TXPicking)
                    .HasForeignKey(d => d.identificacionId)
                    .HasConstraintName("FK_TXPicking_Identificaciones");

                entity.HasOne(d => d.novedad)
                    .WithMany(p => p.TXPicking)
                    .HasForeignKey(d => d.novedadId)
                    .HasConstraintName("FK_TXPicking_Novedades");

                entity.HasOne(d => d.presentacion)
                    .WithMany(p => p.TXPicking)
                    .HasForeignKey(d => d.presentacionId)
                    .HasConstraintName("FK_TXPicking_Presentaciones");

                entity.HasOne(d => d.ubicacion)
                    .WithMany(p => p.TXPicking)
                    .HasForeignKey(d => d.ubicacionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TXPicking_Ubicaciones");
            });

            modelBuilder.Entity<TiposAtributos>(entity =>
            {
                entity.HasKey(e => e.tipoAtributoId);

                entity.Property(e => e.tipoAtributoDescripcion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TiposContenedores>(entity =>
            {
                entity.HasKey(e => e.tipoContenedorId);

                entity.Property(e => e.tipoContenedorAlto)
                    .HasColumnType("decimal(18, 4)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.tipoContenedorAncho)
                    .HasColumnType("decimal(18, 4)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.tipoContenedorCodigo)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.tipoContenedorDescripcion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.tipoContenedorPeso)
                    .HasColumnType("decimal(18, 4)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.tipoContenedorProfundidad)
                    .HasColumnType("decimal(18, 4)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.tipoContenedorVolumen)
                    .HasColumnType("decimal(18, 4)")
                    .HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<TiposCoordenadas>(entity =>
            {
                entity.HasKey(e => e.tipoCoordenadaId)
                    .HasName("PK_TipoCoordenada");

                entity.Property(e => e.tipoCoordenadaDescripcion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TiposEstaciones>(entity =>
            {
                entity.HasKey(e => e.tipoEstacionId);

                entity.Property(e => e.TipoEstacionDescripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.tipoEstacionCodigo)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TiposIdentificaciones>(entity =>
            {
                entity.HasKey(e => e.tipoIdentificacionId)
                    .HasName("PK_TiposIdentificacion");

                entity.Property(e => e.tipoIdentificacionCodigo)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.tipoIdentificacionDescripcion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TiposPerifericos>(entity =>
            {
                entity.HasKey(e => e.tipoPerifericoId)
                    .HasName("PK_TiposPeriferico");

                entity.Property(e => e.tipoPerifericoDescripcion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TiposUbicaciones>(entity =>
            {
                entity.HasKey(e => e.tipoUbicacionId);

                entity.Property(e => e.tipoUbicacionCodigo)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.tipoUbicacionDescripcion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Titulares>(entity =>
            {
                entity.HasKey(e => e.titularId)
                    .HasName("PK_Titular");

                entity.Property(e => e.titularCodigo)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.titularDescripcion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.ordenante)
                    .WithMany(p => p.Titulares)
                    .HasForeignKey(d => d.ordenanteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Titular_Ordenantes");
            });

            modelBuilder.Entity<TxCalidadUbicaciones>(entity =>
            {
                entity.HasKey(e => e.TxCalidadUbicacionId)
                    .HasName("PK_TxCalidadUbicacion");

                entity.Property(e => e.TxCalidadUbicacionFechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.TxCalidadUbicacionFechaModificacion).HasColumnType("datetime");

                entity.Property(e => e.TxCalidadUbicacionSUMRealEscalar).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.TxCalidadUbicacionSUMRealManejo).HasColumnType("decimal(18, 4)");

                entity.HasOne(d => d.bodegaLogica)
                    .WithMany(p => p.TxCalidadUbicaciones)
                    .HasForeignKey(d => d.bodegaLogicaId)
                    .HasConstraintName("FK_TxCalidadUbicacion_BodegasLogicas");

                entity.HasOne(d => d.identificacion)
                    .WithMany(p => p.TxCalidadUbicaciones)
                    .HasForeignKey(d => d.identificacionId)
                    .HasConstraintName("FK_TxCalidadUbicacion_Identificaciones");

                entity.HasOne(d => d.novedad)
                    .WithMany(p => p.TxCalidadUbicaciones)
                    .HasForeignKey(d => d.novedadId)
                    .HasConstraintName("FK_TxCalidadUbicacion_Novedades");

                entity.HasOne(d => d.presentacion)
                    .WithMany(p => p.TxCalidadUbicaciones)
                    .HasForeignKey(d => d.presentacionId)
                    .HasConstraintName("FK_TxCalidadUbicacion_Presentaciones");

                entity.HasOne(d => d.ubicacion)
                    .WithMany(p => p.TxCalidadUbicaciones)
                    .HasForeignKey(d => d.ubicacionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TxCalidadUbicacion_Ubicaciones");
            });

            modelBuilder.Entity<TxDespacho>(entity =>
            {
                entity.Property(e => e.continuidadActivada).HasDefaultValueSql("((0))");

                entity.Property(e => e.txDespachoFechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.txDespachoFechaModificacion).HasColumnType("datetime");

                entity.Property(e => e.txDespachoRealEscalar)
                    .HasColumnType("decimal(18, 4)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.txDespachoRealManejo)
                    .HasColumnType("decimal(18, 4)")
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.bodegaLogica)
                    .WithMany(p => p.TxDespacho)
                    .HasForeignKey(d => d.bodegaLogicaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TxDespacho_BodegasLogicas");

                entity.HasOne(d => d.contenedor)
                    .WithMany(p => p.TxDespacho)
                    .HasForeignKey(d => d.contenedorId)
                    .HasConstraintName("FK_TxDespacho_Contenedores");

                entity.HasOne(d => d.identificacion)
                    .WithMany(p => p.TxDespacho)
                    .HasForeignKey(d => d.identificacionId)
                    .HasConstraintName("FK_TxDespacho_Identificaciones");

                entity.HasOne(d => d.novedad)
                    .WithMany(p => p.TxDespacho)
                    .HasForeignKey(d => d.novedadId)
                    .HasConstraintName("FK_TxDespacho_Novedades");

                entity.HasOne(d => d.presentacion)
                    .WithMany(p => p.TxDespacho)
                    .HasForeignKey(d => d.presentacionId)
                    .HasConstraintName("FK_TxDespacho_Presentaciones");

                entity.HasOne(d => d.ubicacion)
                    .WithMany(p => p.TxDespacho)
                    .HasForeignKey(d => d.ubicacionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TxDespacho_Ubicaciones");
            });

            modelBuilder.Entity<TxDevolucion>(entity =>
            {
                entity.Property(e => e.TxDevolucionFechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.TxDevolucionFechaModificacion).HasColumnType("datetime");

                entity.Property(e => e.TxDevolucionRealEscalar).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.TxDevolucionRealManejo).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.proceso)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.bodegaLogica)
                    .WithMany(p => p.TxDevolucion)
                    .HasForeignKey(d => d.bodegaLogicaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TxDevolucion_BodegasLogicas");

                entity.HasOne(d => d.contenedor)
                    .WithMany(p => p.TxDevolucion)
                    .HasForeignKey(d => d.contenedorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TxDevolucion_ContenedorId");

                entity.HasOne(d => d.identificacion)
                    .WithMany(p => p.TxDevolucion)
                    .HasForeignKey(d => d.identificacionId)
                    .HasConstraintName("FK_TxDevolucion_Identificaciones");

                entity.HasOne(d => d.novedad)
                    .WithMany(p => p.TxDevolucion)
                    .HasForeignKey(d => d.novedadId)
                    .HasConstraintName("FK_TxDevolucion_Novedades");

                entity.HasOne(d => d.presentacion)
                    .WithMany(p => p.TxDevolucion)
                    .HasForeignKey(d => d.presentacionId)
                    .HasConstraintName("FK_TxDevolucion_Presentaciones");

                entity.HasOne(d => d.ubicacion)
                    .WithMany(p => p.TxDevolucion)
                    .HasForeignKey(d => d.ubicacionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TxDevolucion_Ubicaciones");
            });

            modelBuilder.Entity<TxInventario>(entity =>
            {
                entity.Property(e => e.txInventarioFechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.txInventarioFechaModificacion).HasColumnType("datetime");

                entity.Property(e => e.txInventarioRealEscalar)
                    .HasColumnType("decimal(18, 4)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.txInventarioRealManejo)
                    .HasColumnType("decimal(18, 4)")
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.bodegaLogica)
                    .WithMany(p => p.TxInventario)
                    .HasForeignKey(d => d.bodegaLogicaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_txInventario_BodegasLogicas");

                entity.HasOne(d => d.identificacion)
                    .WithMany(p => p.TxInventario)
                    .HasForeignKey(d => d.identificacionId)
                    .HasConstraintName("FK_txInventario_Identificaciones");

                entity.HasOne(d => d.presentacion)
                    .WithMany(p => p.TxInventario)
                    .HasForeignKey(d => d.presentacionId)
                    .HasConstraintName("FK_txInventario_Presentaciones");

                entity.HasOne(d => d.ubicacion)
                    .WithMany(p => p.TxInventario)
                    .HasForeignKey(d => d.ubicacionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_txInventario_Ubicaciones");
            });

            modelBuilder.Entity<TxOrdenEmpaque>(entity =>
            {
                entity.HasIndex(e => e.contenedorId)
                    .HasName("ix_TxOrdenEmpaque_contenedorId");

                entity.HasIndex(e => e.ordenEmpaqueId)
                    .HasName("ix_TxOrdenEmpaque_ordenEmpaqueId");

                entity.HasIndex(e => e.presentacionId)
                    .HasName("ix_TxOrdenEmpaque_presentacionId");

                entity.HasIndex(e => e.ubicacionId)
                    .HasName("ix_TxOrdenEmpaque_ubicacionId");

                entity.Property(e => e.txOrdenEmpaqueFechaCierre).HasColumnType("datetime");

                entity.Property(e => e.txOrdenEmpaqueFechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.txOrdenEmpaqueFechaModificacion).HasColumnType("datetime");

                entity.Property(e => e.txOrdenEmpaquePlano)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.txOrdenEmpaqueRealEscalar)
                    .HasColumnType("decimal(18, 4)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.txOrdenEmpaqueRealManejo)
                    .HasColumnType("decimal(18, 4)")
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.contenedor)
                    .WithMany(p => p.TxOrdenEmpaque)
                    .HasForeignKey(d => d.contenedorId)
                    .HasConstraintName("FK_txOrdenEmpaque_Contenedores");
            });

            modelBuilder.Entity<TxReubicacion>(entity =>
            {
                entity.HasIndex(e => new { e.txReubicacionId, e.contenedorId, e.saldoDetalleId, e.txReubicacionConcepto, e.saldoId })
                    .HasName("<Name of Missing Index, sysname,>");

                entity.Property(e => e.txReubicacionBarcode).HasDefaultValueSql("((0))");

                entity.Property(e => e.txReubicacionFechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.txReubicacionFechaModificacion).HasColumnType("datetime");

                entity.Property(e => e.txReubicacionRealEscalar)
                    .HasColumnType("decimal(18, 4)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.txReubicacionRealManejo)
                    .HasColumnType("decimal(18, 4)")
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.bodegaLogica)
                    .WithMany(p => p.TxReubicacion)
                    .HasForeignKey(d => d.bodegaLogicaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TxReubicacion_BodegasLogicas");

                entity.HasOne(d => d.contenedor)
                    .WithMany(p => p.TxReubicacion)
                    .HasForeignKey(d => d.contenedorId)
                    .HasConstraintName("FK_TxReubicacion_Contenedores");

                entity.HasOne(d => d.identificacion)
                    .WithMany(p => p.TxReubicacion)
                    .HasForeignKey(d => d.identificacionId)
                    .HasConstraintName("FK_TxReubicacion_Identificaciones");

                entity.HasOne(d => d.novedad)
                    .WithMany(p => p.TxReubicacion)
                    .HasForeignKey(d => d.novedadId)
                    .HasConstraintName("FK_TxReubicacion_Novedades");

                entity.HasOne(d => d.presentacion)
                    .WithMany(p => p.TxReubicacion)
                    .HasForeignKey(d => d.presentacionId)
                    .HasConstraintName("FK_TxReubicacion_Presentaciones");

                entity.HasOne(d => d.ubicacion)
                    .WithMany(p => p.TxReubicacion)
                    .HasForeignKey(d => d.ubicacionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TxReubicacion_Ubicaciones");
            });

            modelBuilder.Entity<Ubicaciones>(entity =>
            {
                entity.HasKey(e => e.ubicacionId);

                entity.HasIndex(e => e.ubicacionCodigo)
                    .HasName("ix_Ubicaciones_ubicacionCodigo");

                entity.HasIndex(e => e.ubicacionPadreId)
                    .HasName("ix_Ubicaciones_ubicacionPadreId");

                entity.Property(e => e.ubicacionCodigo)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ubicacionColumna)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ubicacionDescripcion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ubicacionDespacho).HasDefaultValueSql("((0))");

                entity.Property(e => e.ubicacionDisponible).HasDefaultValueSql("((0))");

                entity.Property(e => e.ubicacionEtiqueta)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ubicacionRuteoEstado).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.instalacion)
                    .WithMany(p => p.Ubicaciones)
                    .HasForeignKey(d => d.instalacionId)
                    .HasConstraintName("FK_Ubicaciones_Instalaciones");

                entity.HasOne(d => d.tipoUbicacion)
                    .WithMany(p => p.Ubicaciones)
                    .HasForeignKey(d => d.tipoUbicacionId)
                    .HasConstraintName("FK_Ubicaciones_TiposUbicaciones");

                entity.HasOne(d => d.ubicacionFisica)
                    .WithMany(p => p.Ubicaciones)
                    .HasForeignKey(d => d.ubicacionFisicaId)
                    .HasConstraintName("FK_Ubicaciones_UbicacionesFisicas");
            });

            modelBuilder.Entity<UbicacionesCambioAutomatico>(entity =>
            {
                entity.HasKey(e => e.ubicacionCambioAutomaticoId);

                entity.HasOne(d => d.ubicacion)
                    .WithMany(p => p.UbicacionesCambioAutomatico)
                    .HasForeignKey(d => d.ubicacionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UbicacionesCambioAutomatico_Ubicaciones");
            });

            modelBuilder.Entity<UbicacionesFisicas>(entity =>
            {
                entity.HasKey(e => e.ubicacionFisicaId);

                entity.Property(e => e.ubicacionFisicaCoordenada)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.coordenada)
                    .WithMany(p => p.UbicacionesFisicas)
                    .HasForeignKey(d => d.coordenadaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UbicacionesFisicas_Coordenadas");
            });

            modelBuilder.Entity<UbicacionesProductos>(entity =>
            {
                entity.HasKey(e => e.ubicacionProductoId);

                entity.HasOne(d => d.producto)
                    .WithMany(p => p.UbicacionesProductos)
                    .HasForeignKey(d => d.productoId)
                    .HasConstraintName("FK_UbicacionesProductos_Productos");

                entity.HasOne(d => d.ubicacion)
                    .WithMany(p => p.UbicacionesProductos)
                    .HasForeignKey(d => d.ubicacionId)
                    .HasConstraintName("FK_UbicacionesProductos_Ubicaciones");
            });

            modelBuilder.Entity<UbicacionesSugeridoModulos>(entity =>
            {
                entity.HasKey(e => e.ubicacionModuloId)
                    .HasName("PK__Ubicacio__51A7AF48EBBF9561");

                entity.Property(e => e.ubicacionModuloCodigo)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UnidadesEscalares>(entity =>
            {
                entity.HasKey(e => e.unidadEscalarId);

                entity.Property(e => e.unidadEscalarCantidad).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.unidadEscalarCodigo)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.unidadEscalarDescripcion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UnidadesManejo>(entity =>
            {
                entity.HasKey(e => e.unidadManejoId)
                    .HasName("PK_unidades_manejo");

                entity.Property(e => e.unidadManejoCodigo)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.unidadManejoDescripcion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.usuarioId)
                    .HasName("PK_usuarios");

                entity.Property(e => e.usuarioApellido)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.usuarioIdentificacion)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.usuarioNombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.usuarioPassword)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.usuarioTerminal).HasMaxLength(1);

                entity.Property(e => e.usuarioUser)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UsuariosEstaciones>(entity =>
            {
                entity.HasKey(e => new { e.usuarioId, e.estacionId });

                entity.HasOne(d => d.usuario)
                    .WithMany(p => p.UsuariosEstaciones)
                    .HasForeignKey(d => d.usuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UsuariosEstaciones_Usuarios");
            });

            modelBuilder.Entity<UsuariosRoles>(entity =>
            {
                entity.HasKey(e => new { e.usuarioId, e.roleId });

                entity.HasOne(d => d.role)
                    .WithMany(p => p.UsuariosRoles)
                    .HasForeignKey(d => d.roleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UsuariosRoles_Roles");

                entity.HasOne(d => d.usuario)
                    .WithMany(p => p.UsuariosRoles)
                    .HasForeignKey(d => d.usuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UsuariosRoles_Usuarios");
            });

            modelBuilder.Entity<ValoresPlantillasLotes>(entity =>
            {
                entity.HasKey(e => e.valorProductoLoteId);

                entity.Property(e => e.FechaAjuste).HasColumnType("datetime");

                entity.Property(e => e.valorPLantillaLoteFechaVencimiento).HasColumnType("datetime");

                entity.Property(e => e.valorPlantillaLoteCodigo)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.valorPlantillaLoteFechaProduccion).HasColumnType("datetime");

                entity.Property(e => e.valorplantillaLoteDescripcion)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.valorplantillaLoteNombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.producto)
                    .WithMany(p => p.ValoresPlantillasLotes)
                    .HasForeignKey(d => d.productoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ValoresPlantillasLotes_Productos");
            });

            modelBuilder.Entity<ValoresProductosLotes>(entity =>
            {
                entity.HasKey(e => e.valorProductoLoteId);

                entity.Property(e => e.valorProductoLoteDescripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.valorProductoLoteFecha)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");
            });

            modelBuilder.Entity<revisionCierre>(entity =>
            {
                entity.Property(e => e.estadoEstibaUbicacion)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.fecha).HasColumnType("datetime");

                entity.Property(e => e.resultado).IsUnicode(false);
            });

            modelBuilder.Entity<revisonpoquitos>(entity =>
            {
                entity.Property(e => e.Resultado).IsUnicode(false);

                entity.Property(e => e.fecha).HasColumnType("datetime");
            });
        }
    }
}
