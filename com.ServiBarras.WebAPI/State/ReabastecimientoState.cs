using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using com.ServiBarras.Infrastructure.ModelDTO;

namespace com.ServiBarras.WebAPI.State
{
    /// <summary>
    /// Implementación singleton y thread-safe de <see cref="IReabastecimientoState"/>.
    /// El contador usa Interlocked; el snapshot se reemplaza por una referencia inmutable
    /// (asignación atómica), por lo que los lectores nunca ven un estado parcial.
    /// </summary>
    public class ReabastecimientoState : IReabastecimientoState
    {
        private int _conexionesActivas;

        // Rastrea los connectionId unidos al room para poder manejar de forma robusta las
        // desconexiones abruptas (OnDisconnectedAsync) sin decrementar el contador dos veces
        // ni dejarlo inflado. ConcurrentDictionary se usa como conjunto thread-safe.
        private readonly ConcurrentDictionary<string, byte> _conexiones =
            new ConcurrentDictionary<string, byte>();

        // Referencia inmutable al último snapshot; se reemplaza atómicamente en GuardarSnapshot.
        private volatile ReabastecimientoSnapshot _snapshot;

        public int ConexionesActivas => Volatile.Read(ref _conexionesActivas);

        public string UltimoHash => _snapshot?.Hash;

        public void IncrementarConexion()
        {
            Interlocked.Increment(ref _conexionesActivas);
        }

        public void DecrementarConexion()
        {
            // Decremento seguro que nunca baja de 0 (patrón compare-and-swap).
            int original;
            do
            {
                original = Volatile.Read(ref _conexionesActivas);
                if (original == 0)
                {
                    return;
                }
            }
            while (Interlocked.CompareExchange(ref _conexionesActivas, original - 1, original) != original);
        }

        public bool RegistrarConexion(string connectionId)
        {
            return _conexiones.TryAdd(connectionId, 0);
        }

        public bool EliminarConexion(string connectionId)
        {
            return _conexiones.TryRemove(connectionId, out _);
        }

        public void GuardarSnapshot(IReadOnlyList<ReabastecimientoItemDto> data, string hash)
        {
            // Reemplazo atómico de la referencia: los lectores obtienen el snapshot viejo o el
            // nuevo completo, nunca uno a medio construir.
            _snapshot = new ReabastecimientoSnapshot(data, hash);
        }

        public ReabastecimientoSnapshot ObtenerSnapshot()
        {
            return _snapshot;
        }
    }
}
