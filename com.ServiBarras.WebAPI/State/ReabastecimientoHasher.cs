using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using com.ServiBarras.Infrastructure.ModelDTO;
using Newtonsoft.Json;

namespace com.ServiBarras.WebAPI.State
{
    /// <summary>
    /// Calcula el hash de la data de reabastecimiento. Se usa tanto en el BackgroundService
    /// como en el Hub (cuando el primer usuario dispara la consulta) para mantener consistente
    /// el snapshot/hash guardado en el estado y evitar reenvíos duplicados.
    /// Usa Newtonsoft.Json (serializador ya presente; System.Text.Json no existe en netcoreapp2.2).
    /// </summary>
    public static class ReabastecimientoHasher
    {
        public static string Calcular(IReadOnlyList<ReabastecimientoItemDto> data)
        {
            string json = JsonConvert.SerializeObject(data);
            using (var sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(json));
                var sb = new StringBuilder(bytes.Length * 2);
                foreach (byte b in bytes)
                {
                    sb.Append(b.ToString("x2"));
                }
                return sb.ToString();
            }
        }
    }
}
