using System.Collections.Generic;
using com.ServiBarras.Infrastructure.ModelDTO;

namespace com.ServiBarras.WebAPI.State
{
    /// <summary>
    /// Snapshot inmutable de la última data de reabastecimiento notificada y su hash asociado.
    /// </summary>
    public class ReabastecimientoSnapshot
    {
        public ReabastecimientoSnapshot(IReadOnlyList<ReabastecimientoItemDto> data, string hash)
        {
            Data = data;
            Hash = hash;
        }

        public IReadOnlyList<ReabastecimientoItemDto> Data { get; }

        public string Hash { get; }
    }
}
