using System.Collections.Generic;
using System.Threading.Tasks;
using com.Servibarras.ApplicationCore.BusinessLogic.Interfaces;
using com.ServiBarras.Infrastructure.ModelDTO;
using com.ServiBarras.WebAPI.State;
using Microsoft.AspNetCore.SignalR;

namespace com.ServiBarras.WebAPI.Hubs
{
    public class WmsHub : Hub
    {
        /// <summary>Room común al que se difunde el estado de reabastecimiento.</summary>
        public const string RoomReabastecimiento = "Room_Reabastecimiento";

        private readonly IReabastecimientoState _reabastecimientoState;
        private readonly IReabastecimientoBL _reabastecimientoBL;

        public WmsHub(
            IReabastecimientoState reabastecimientoState,
            IReabastecimientoBL reabastecimientoBL)
        {
            _reabastecimientoState = reabastecimientoState;
            _reabastecimientoBL = reabastecimientoBL;
        }

        // El cliente invoca esto después de conectar para unirse a su sala personal
        public async Task UnirseASala(long usuarioId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, $"Room_Operario_{usuarioId}");
        }

        /// <summary>
        /// Une la conexión al room de reabastecimiento, incrementa el contador y envía de
        /// inmediato la data SÓLO al llamador:
        ///   - Si ya hay un snapshot guardado (usuarios que entran a mitad de ciclo), se le envía
        ///     ese snapshot cacheado sin tocar la BD.
        ///   - Si aún no hay snapshot (primer usuario / room vacío tras arrancar), se dispara la
        ///     consulta al SP en el momento, se guarda el snapshot en el estado y se le envía.
        ///     Así el primer usuario recibe su información al instante, sin esperar al background.
        /// </summary>
        public async Task UnirseAReabastecimiento()
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, RoomReabastecimiento);

            // RegistrarConexion es idempotente: sólo incrementa si la conexión no estaba ya en el room.
            if (_reabastecimientoState.RegistrarConexion(Context.ConnectionId))
            {
                _reabastecimientoState.IncrementarConexion();
            }

            ReabastecimientoSnapshot snapshot = _reabastecimientoState.ObtenerSnapshot();
            if (snapshot == null)
            {
                // Primer usuario: no hay snapshot todavía → consultar ahora y guardarlo.
                // El BackgroundService, en su próximo ciclo, calculará el mismo hash y no
                // reenviará nada al grupo (evita duplicados).
                IReadOnlyList<ReabastecimientoItemDto> data =
                    await _reabastecimientoBL.ObtenerReabastecimientoAsync();
                string hash = ReabastecimientoHasher.Calcular(data);
                _reabastecimientoState.GuardarSnapshot(data, hash);
                snapshot = _reabastecimientoState.ObtenerSnapshot();
            }

            await Clients.Caller.SendAsync("ReabastecimientoActualizado", snapshot.Data);
        }

        /// <summary>Quita la conexión del room de reabastecimiento y decrementa el contador.</summary>
        public async Task SalirDeReabastecimiento()
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, RoomReabastecimiento);

            if (_reabastecimientoState.EliminarConexion(Context.ConnectionId))
            {
                _reabastecimientoState.DecrementarConexion();
            }
        }

        /// <summary>
        /// Si la conexión estaba en el room de reabastecimiento (p. ej. cerró el navegador sin
        /// llamar a SalirDeReabastecimiento), se decrementa el contador. Se rastrea la membresía
        /// por connectionId en el estado: es la opción más robusta porque EliminarConexion sólo
        /// devuelve true una vez, evitando decrementos duplicados y que el contador quede inflado.
        /// </summary>
        public override async Task OnDisconnectedAsync(System.Exception exception)
        {
            if (_reabastecimientoState.EliminarConexion(Context.ConnectionId))
            {
                _reabastecimientoState.DecrementarConexion();
            }

            await base.OnDisconnectedAsync(exception);
        }
    }
}
