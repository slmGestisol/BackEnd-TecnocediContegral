using com.Servibarras.ApplicationCore.BusinessLogic;
using com.Servibarras.ApplicationCore.BusinessLogic.Clientes;
using com.Servibarras.ApplicationCore.BusinessLogic.Interfaces;
using com.ServiBarras.Infrastructure.DataAccess;
using com.ServiBarras.Infrastructure.DataAccess.Clientes;
using com.ServiBarras.Infrastructure.DataAccess.Interfaces;
using com.ServiBarras.Infrastructure.Models;
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



            #endregion

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddCors(c =>
            {
                c.AddPolicy("OpenAll", opciones =>
                opciones.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .WithHeaders("authorization", "accept", "content-type", "origin"));
            });
            services.AddSignalR();
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
            app.UseMvc();
        }
    }
}
