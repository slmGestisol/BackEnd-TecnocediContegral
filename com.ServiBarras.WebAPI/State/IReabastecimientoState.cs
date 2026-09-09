using System.Collections.Generic;
using com.ServiBarras.Infrastructure.ModelDTO;

namespace com.ServiBarras.WebAPI.State
{
    /// <summary>
    /// Estado compartido (singleton, thread-safe) del room de reabastecimiento.
    /// Mantiene el contador de conexiones activas y el último snapshot de datos + hash.
    /// </summary>
    public interface IReabastecimientoState
    {
        /// <summary>Cantidad de conexiones actualmente unidas al room de reabastecimiento.</summary>
        int ConexionesActivas { get; }

        /// <summary>Incrementa el contador de conexiones (Interlocked).</summary>
        void IncrementarConexion();

        /// <summary>Decrementa el contador de conexiones sin bajar nunca de 0 (Interlocked).</summary>
        void DecrementarConexion();

        /// <summary>
        /// Registra el connectionId como miembro del room. Devuelve true si no estaba
        /// registrado previamente (para saber cuándo incrementar el contador de forma idempotente).
        /// </summary>
        bool RegistrarConexion(string connectionId);

        /// <summary>
        /// Elimina el connectionId del room. Devuelve true si efectivamente estaba registrado
        /// (para saber cuándo decrementar el contador y evitar decrementos duplicados).
        /// </summary>
        bool EliminarConexion(string connectionId);

        /// <summary>Último hash calculado sobre el snapshot, usado para detectar cambios.</summary>
        string UltimoHash { get; }

        /// <summary>Guarda de forma atómica el último snapshot de datos junto con su hash.</summary>
        void GuardarSnapshot(IReadOnlyList<ReabastecimientoItemDto> data, string hash);

        /// <summary>Devuelve el último snapshot guardado (data + hash), o null si aún no hay ninguno.</summary>
        ReabastecimientoSnapshot ObtenerSnapshot();
    }
}
