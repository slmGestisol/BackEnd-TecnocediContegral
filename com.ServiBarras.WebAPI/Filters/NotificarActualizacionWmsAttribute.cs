using System;
using System.Reflection;
using System.Threading.Tasks;
using com.Servibarras.ApplicationCore.BusinessLogic.Interfaces;
using com.ServiBarras.WebAPI.Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Linq;

namespace com.ServiBarras.WebAPI.Filters
{
    public class NotificarActualizacionWmsAttribute : Attribute, IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(
            ActionExecutingContext context,
            ActionExecutionDelegate next)
        {
            // 1. Ejecutar la acción primero
            ActionExecutedContext executedContext = await next();

            // 2. Solo continuar si la respuesta fue exitosa (HTTP 200/2xx)
            if (!(executedContext.Result is JsonResult jsonResult)) return;
            int? statusCode = jsonResult.StatusCode;
            if (!statusCode.HasValue || statusCode.Value < 200 || statusCode.Value >= 300) return;

            // 3. Extraer usuarioId del body (JObject primero, luego reflexión en DTOs tipados)
            long? usuarioId = ExtraerUsuarioId(context);
            if (!usuarioId.HasValue || usuarioId.Value <= 0) return;

            // 4. Capturar IServiceScopeFactory ANTES del Task.Run (HttpContext puede morir)
            IServiceScopeFactory scopeFactory = context.HttpContext.RequestServices
                .GetRequiredService<IServiceScopeFactory>();

            long usuarioIdCapturado = usuarioId.Value;

            // 5. FIRE-AND-FORGET: NO se awaita este Task
            _ = Task.Run(async () =>
            {
                try
                {
                    using (IServiceScope scope = scopeFactory.CreateScope())
                    {
                        IHubContext<WmsHub> hubContext = scope.ServiceProvider
                            .GetRequiredService<IHubContext<WmsHub>>();

                        IMonitorOperarioBL monitorBL = scope.ServiceProvider
                            .GetRequiredService<IMonitorOperarioBL>();

                        // Obtener data actualizada del usuario desde ApplicationCore
                        //var usuario = await monitorBL.GetInformacionOperarioAsync(usuarioIdCapturado);

                        // Enviar notificación a la sala personal del operario
                        await hubContext.Clients
                            .Group($"Room_Operario_{usuarioIdCapturado}")
                            .SendAsync("RefrescarPantalla");
                    }
                }
                catch (Exception)
                {
                    // Silenciar: no debe crashear el servidor
                    // Producción: registrar aquí con el sistema de logging de TecnoCEDI
                }
            });

            // 6. Retorna inmediatamente — el 200 OK ya fue enviado al cliente
        }

        private static long? ExtraerUsuarioId(ActionExecutingContext context)
        {
            foreach (object argumento in context.ActionArguments.Values)
            {
                if (argumento == null) continue;

                // Caso 1: JObject (patrón dominante en este proyecto)
                if (argumento is JObject jObject)
                {
                    JToken token = jObject["usuarioId"];
                    if (token != null && long.TryParse(token.ToString(), out long idJObj))
                        return idJObj;
                    continue;
                }

                // Caso 2: JArray — no tiene usuarioId, ignorar
                if (argumento is JArray) continue;

                // Caso 3: DTO tipado con propiedad usuarioId (reflexión)
                PropertyInfo prop = argumento.GetType().GetProperty(
                    "usuarioId",
                    BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);

                if (prop != null)
                {
                    object valor = prop.GetValue(argumento);
                    if (valor != null && long.TryParse(valor.ToString(), out long idDto))
                        return idDto;
                }
            }
            return null;
        }
    }
}
