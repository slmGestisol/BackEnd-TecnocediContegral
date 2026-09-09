using com.Servibarras.ApplicationCore.BusinessLogic;
using com.Servibarras.ApplicationCore.BusinessLogic.BodegaLogica;
using com.Servibarras.ApplicationCore.BusinessLogic.Clientes;
using com.Servibarras.ApplicationCore.BusinessLogic.Interfaces;
using com.ServiBarras.Infrastructure.DataAccess;
using com.ServiBarras.Infrastructure.DataAccess.BodegaLogica;
using com.ServiBarras.Infrastructure.DataAccess.Clientes;
using com.ServiBarras.Infrastructure.DataAccess.Interfaces;
using com.ServiBarras.Infrastructure.DataAccess.MonitorOperario;
using com.Servibarras.ApplicationCore.BusinessLogic.MonitorOperario;
using com.Servibarras.ApplicationCore.BusinessLogic.Reabastecimiento;
using com.ServiBarras.Infrastructure.DataAccess.Dashboard;
using com.Servibarras.ApplicationCore.BusinessLogic.Dashboard;
using com.ServiBarras.Infrastructure.DataAccess.Reabastecimiento;
using com.ServiBarras.Infrastructure.DataAccess.ConfigReabastecimiento;
using com.Servibarras.ApplicationCore.BusinessLogic.ConfigReabastecimiento;
using com.ServiBarras.Infrastructure.DataAccess.UbicacionLista;
using com.Servibarras.ApplicationCore.BusinessLogic.UbicacionLista;
using com.ServiBarras.Infrastructure.Models;
using com.ServiBarras.WebAPI.BackgroundServices;
using com.ServiBarras.WebAPI.Filters;
using com.ServiBarras.WebAPI.Hubs;
using com.ServiBarras.WebAPI.State;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace com.ServiBarras.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            #region DAL_Services
            services.AddTransient<ICalidadDAL, CalidadDAL>();
            services.AddTransient<ICustodioDAL, CustodioDAL>();
            services.AddTransient<IOrdenanteDAL, OrdenanteDAL>();
            services.AddTransient<IUnidadEscalarDAL, UnidadEscalarDAL>();
            services.AddTransient<IUnidadManejoDAL, UnidadManejoDAL>();
            services.AddTransient<IProcesoDAL, ProcesoDAL>();
            services.AddTransient<ITitularDAL, TitularDAL>();
            services.AddTransient<IContenedorDAL, ContenedorDAL>();
            services.AddTransient<IDespachoDAL, DespachoDAL>();
            services.AddTransient<IEstacionDAL, EstacionDAL>();
            services.AddTransient<ICiudadDAL, CiudadDAL>();
            services.AddTransient<IEstadoDAL, EstadoDAL>();
            services.AddTransient<IPaisDAL, PaisDAL>();
            services.AddTransient<IGrupoDAL, GrupoDAL>();
            services.AddTransient<INovedadDAL, NovedadDAL>();
            services.AddTransient<IOrdenEmpaqueDAL, OrdenEmpaqueDAL>();
            services.AddTransient<IPickingDAL, PickingDAL>();
            services.AddTransient<IPackingDAL, PackingDAL>();
            services.AddTransient<IRuteoDAL, RuteoDAL>();
            services.AddTransient<ISaldoDAL, SaldoDAL>();
            services.AddTransient<IPedidoDAL, PedidoDAL>();
            services.AddTransient<IMaquinaDAL, MaquinaDAL>();
            services.AddTransient<IUsuarioDAL, UsuarioDAL>();
            services.AddTransient<IUbicacionDAL, UbicacionDAL>();
            services.AddTransient<IUbicacionListaDAL, UbicacionListaDAL>();
            services.AddTransient<ICentroOperacionDAL, CentroOperacionDAL>();
            services.AddTransient<ICrossDockingDAL, CrossDockingDAL>();
            services.AddTransient<IPreRuteoDAL, PreRuteoDAL>();
            services.AddTransient<ICriterioProductoDAL, CriterioProductoDAL>();
            services.AddTransient<IProcesoDevolucionDAL, ProcesoDevolucionDAL>();
            services.AddTransient<IProductoDAL, ProductoDAL>();
            services.AddTransient<IProductoLotesDAL, ProductoLotesDAL>();
            services.AddTransient<IProductoAtributoDAL, ProductoAtributoDAL>();
            services.AddTransient<IClasificacionProductoDAL, ClasificacionProductoDAL>();
            services.AddTransient<ITiposIdentificacionDAL, TiposIdentificacionDAL>();
            services.AddTransient<ITipoContenedorDAL, TipoContenedorDAL>();
            services.AddTransient<ITipoAtributoDAL, TipoAtributoDAL>();
            services.AddTransient<IClasificacionAtributoProductoDAL, ClasificacionAtributoProductoDAL>();
            services.AddTransient<ICentroGestionDAL, CentroGestionDAL>();
            services.AddTransient<IClientesDAL, ClientesDAL>();
            services.AddTransient<IConfiguracionVerificacionDAL, ConfiguracionVerificacionDAL>();
            services.AddTransient<IRFIDDAL, RFIDDAL>();
            services.AddTransient<ICoronaExtrasDAL, CoronaExtrasDAL>();
            services.AddTransient<IImpresionDAL, ImpresionDAL>();
            services.AddTransient<IRecepcionDAL, RecepcionDAL>();
            services.AddTransient<IBodegaLogicaDAL, BodegaLogicaDAL>();
            services.AddTransient<ILoteDAL, LoteDAL>();
            services.AddTransient<IMonitorOperarioDAL, MonitorOperarioDAL>();
            services.AddTransient<IDashboardDAL, DashboardDAL>();
            services.AddTransient<IProductoNoConformeDAL, ProductoNoConformeDAL>();
            services.AddTransient<IReabastecimientoDAL, ReabastecimientoDAL>();
            services.AddTransient<IConfigReabastecimientoDAL, ConfigReabastecimientoDAL>();




            #endregion

            #region BL_Services
            services.AddTransient<ICalidadBL, CalidadBL>();
            services.AddTransient<ICustodioBL, CustodioBL>();
            services.AddTransient<IOrdenanteBL, OrdenanteBL>();
            services.AddTransient<IUnidadEscalarBL, UnidadEscalarBL>();
            services.AddTransient<IUnidadManejoBL, UnidadManejoBL>();
            services.AddTransient<IProcesoBL, ProcesoBL>();
            services.AddTransient<ITitularBL, TitularBL>();
            services.AddTransient<IContenedorBL, ContenedorBL>();
            services.AddTransient<IDespachoBL, DespachoBL>();
            services.AddTransient<IEstacionBL, EstacionBL>();
            services.AddTransient<ICiudadBL, CiudadBL>();
            services.AddTransient<IEstadoBL, EstadoBL>();
            services.AddTransient<IPaisBL, PaisBL>();
            services.AddTransient<IGrupoBL, GrupoBL>();
            services.AddTransient<INovedadBL, NovedadBL>();
            services.AddTransient<IOrdenEmpaqueBL, OrdenEmpaqueBL>();
            services.AddTransient<IPickingBL, PickingBL>();
            services.AddTransient<IPackingBL, PackingBL>();
            services.AddTransient<IRuteoBL, RuteoBL>();
            services.AddTransient<ISaldoBL, SaldoBL>();
            services.AddTransient<IPedidoBL, PedidoBL>();
            services.AddTransient<IMaquinaBL, MaquinaBL>();
            services.AddTransient<IUsuarioBL, UsuarioBL>();
            services.AddTransient<IUbicacionBL, UbicacionBL>();
            services.AddTransient<IUbicacionListaBL, UbicacionListaBL>();
            services.AddTransient<ICentroOperacionBL, CentroOperacionBL>();
            services.AddTransient<ICrossDockingBL, CrossDockingBL>();
            services.AddTransient<IPreRuteoBL, PreRuteoBL>();
            services.AddTransient<ICriterioProductoBL, CriterioProductoBL>();
            services.AddTransient<IProcesoDevolucionBL, ProcesoDevolucionBL>();
            services.AddTransient<IProductoBL, ProductoBL>();
            services.AddTransient<IProductoLoteBL, ProductoLoteBL>();
            services.AddTransient<IProductoAtributoBL, ProductoAtributoBL>();
            services.AddTransient<IClasificacionProductoBL, ClasificacionProductoBL>();
            services.AddTransient<ITipoIdentificacionBL, TipoIdentificacionBL>();
            services.AddTransient<ITipoContenedorBL, TipoContenedorBL>();
            services.AddTransient<ITipoAtributoBL, TipoAtributoBL>();            
            services.AddTransient<IClasificacionAtributoProductoBL, ClasificacionAtributoProductoBL>();
            services.AddTransient<ICentroGestionBL, CentroGestionBL>();
            services.AddTransient<IClientesBL, ClientesBL>();
            services.AddTransient<IConfiguracionVerificacionBL, ConfiguracionVerificacionBL>();
            services.AddTransient<IRFIDBL, RFIDBL>();
            services.AddTransient<ICoronaExtrasBL, CoronaExtrasBL>();
            services.AddTransient<IImpresionBL, ImpresionBL>();
            services.AddTransient<IRecepcionBL, RecepcionBL>();
            services.AddTransient<IBodegaLogicaBL, BodegaLogicaBL>();
            services.AddTransient<ILoteBL, LoteBL>();
            services.AddTransient<IMonitorOperarioBL, MonitorOperarioBL>();
            services.AddTransient<IDashboardBL, DashboardBL>();
            services.AddTransient<IProductoNoConformeBL, ProductoNoConformeBL>();
            services.AddTransient<IReabastecimientoBL, ReabastecimientoBL>();
            services.AddTransient<IConfigReabastecimientoBL, ConfigReabastecimientoBL>();
            services.AddScoped<NotificarActualizacionWmsAttribute>();




            #endregion

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddCors(c =>
            {
                c.AddPolicy("OpenAll", opciones =>
                opciones.WithOrigins(
                            "http://localhost:8080",
                            "http://localhost:4200",
                            "http://10.252.0.116:8083",
                            "http://10.252.0.116:8081",
                            "http://10.252.0.141:8084",
                            "null")
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials());
            });
            // EnableDetailedErrors: TEMPORAL para diagnóstico — muestra el mensaje real de la
            // excepción al cliente. Quitar (o dejar solo en Development) una vez resuelto.
            services.AddSignalR(options => options.EnableDetailedErrors = true);

            #region Reabastecimiento
            // Estado compartido del room (contador de conexiones + último snapshot/hash).
            services.AddSingleton<IReabastecimientoState, ReabastecimientoState>();
            // Servicio en background que consulta el SP y difunde cambios por SignalR.
            services.AddHostedService<ReabastecimientoBackgroundService>();
            #endregion

            services.AddDbContext<TecnoCEDI_bdContext>(options => options.UseSqlServer(Configuration.GetConnectionString("TecnoCEDIEntities")));
            services.AddMvc(option => option.EnableEndpointRouting = false);
            services.AddMvc().AddJsonOptions(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }


            app.Use(async (context, next) =>
            {
                context.Response.Headers.Add("X-Content-Type-Options", "nosniff");
                await next();
            });
           
            app.UseCors("OpenAll");
            //  app.UseHttpsRedirection();
            app.UseSignalR(routes =>
            {
                routes.MapHub<WmsHub>("/hubs/wms");
            });
            app.UseMvc();
        }
    }
}
