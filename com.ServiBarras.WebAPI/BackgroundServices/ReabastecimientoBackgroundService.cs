using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using com.Servibarras.ApplicationCore.BusinessLogic.Interfaces;
using com.ServiBarras.Infrastructure.ModelDTO;
using com.ServiBarras.WebAPI.Hubs;
using com.ServiBarras.WebAPI.State;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace com.ServiBarras.WebAPI.BackgroundServices
{
    /// <summary>
    /// Servicio en background que consulta periódicamente sp_GET_ReabastecimientoData,
    /// detecta cambios por hash y notifica al room Room_Reabastecimiento vía SignalR.
    /// Optimizaciones:
    ///   - No consulta la BD si no hay conexiones activas al room.
    ///   - No reenvía datos si el hash no cambió respecto al último snapshot.
    /// </summary>
    public class ReabastecimientoBackgroundService : BackgroundService
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly IHubContext<WmsHub> _hubContext;
        private readonly IReabastecimientoState _state;
        private readonly ILogger<ReabastecimientoBackgroundService> _logger;
        private readonly TimeSpan _intervalo;

        private const int IntervaloPorDefectoSegundos = 300;

        public ReabastecimientoBackgroundService(
            IServiceScopeFactory scopeFactory,
            IHubContext<WmsHub> hubContext,
            IReabastecimientoState state,
            IConfiguration configuration,
            ILogger<ReabastecimientoBackgroundService> logger)
        {
            _scopeFactory = scopeFactory;
            _hubContext = hubContext;
            _state = state;
            _logger = logger;

            int segundos = configuration.GetValue<int>("Reabastecimiento:IntervaloSegundos", IntervaloPorDefectoSegundos);
            if (segundos <= 0)
            {
                segundos = IntervaloPorDefectoSegundos;
            }
            _intervalo = TimeSpan.FromSeconds(segundos);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    // Optimización: si nadie está escuchando el room, no se consulta la BD.
                    if (_state.ConexionesActivas > 0)
                    {
                        // El BL/DAL es Transient y este servicio es Singleton: se crea un scope propio.
                        using (IServiceScope scope = _scopeFactory.CreateScope())
                        {
                            IReabastecimientoBL reabastecimientoBL = scope.ServiceProvider
                                .GetRequiredService<IReabastecimientoBL>();

                            IReadOnlyList<ReabastecimientoItemDto> data =
                                await reabastecimientoBL.ObtenerReabastecimientoAsync();

                            string hash = ReabastecimientoHasher.Calcular(data);

                            // Sólo se notifica cuando los datos cambiaron respecto al último snapshot.
                            if (!string.Equals(hash, _state.UltimoHash, StringComparison.Ordinal))
                            {
                                _state.GuardarSnapshot(data, hash);

                                await _hubContext.Clients
                                    .Group(WmsHub.RoomReabastecimiento)
                                    .SendAsync("ReabastecimientoActualizado", data, stoppingToken);
                            }
                        }
                    }
                }
                catch (OperationCanceledException) when (stoppingToken.IsCancellationRequested)
                {
                    // Apagado normal del host.
                    break;
                }
                catch (Exception ex)
                {
                    // Una excepción (p. ej. fallo de BD) no debe matar el loop.
                    _logger.LogError(ex, "Error en el ciclo de ReabastecimientoBackgroundService.");
                }

                try
                {
                    // El Delay va al final: la primera consulta ocurre apenas arranca (si hay conexiones).
                    await Task.Delay(_intervalo, stoppingToken);
                }
                catch (OperationCanceledException)
                {
                    break;
                }
            }
        }
    }
}
