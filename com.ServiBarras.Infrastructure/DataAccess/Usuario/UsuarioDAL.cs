
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using com.ServiBarras.Infrastructure.DataAccess.Interfaces;
using com.ServiBarras.Infrastructure.Models;
using com.ServiBarras.Shared.LogEvent;
using com.ServiBarras.Shared.ModelDTO;
using Microsoft.EntityFrameworkCore;

namespace com.ServiBarras.Infrastructure.DataAccess
{
    public class UsuarioDAL : IUsuarioDAL
    {
        public TecnoCEDI_bdContext dbcontext;

        public UsuarioDAL()
        {
            dbcontext = new TecnoCEDI_bdContext();
        }


        public async Task<Usuarios> GetUsuarioAsync(long usuarioId)
        {
            try
            {
                return await dbcontext.Usuarios.Where(x => x.usuarioId == usuarioId).FirstOrDefaultAsync();
            }
            catch (System.Exception ex)
            {
                LogEvent log = new LogEvent();
                log.LogWrite(ex.Message);

                return null;
            }
        }

        public bool UsuarioExists(long usuarioId)
        {
            return dbcontext.Usuarios.Any(e => e.usuarioId == usuarioId);
        }

      
        public async Task<Usuarios> GetUsuarioLoginAsync(UsuarioDTO usuario)
        {
            try
            {
                Usuarios usuarioItem = new Usuarios();
                Ubicaciones ubicacionItem = new Ubicaciones();

                usuarioItem = await dbcontext.Usuarios.Where(x => x.usuarioUser.ToUpper() == usuario.usuarioUser.ToUpper() && x.usuarioPassword.ToUpper() == usuario.usuarioPassword.ToUpper()).FirstOrDefaultAsync();

                if (usuarioItem != null) { 
                    ubicacionItem = await dbcontext.Ubicaciones.Where(x => x.ubicacionCodigo.ToUpper() == usuarioItem.usuarioIdentificacion).FirstOrDefaultAsync();

                    ubicacionItem.instalacionId = usuario.instalacionId;

                    usuarioItem.instalacionId = usuario.instalacionId;

                    dbcontext.SaveChanges();
                }

                if (usuarioItem == null) usuarioItem = new Usuarios();


                return usuarioItem;
            }
            catch (System.Exception ex)
            {
                LogEvent log = new LogEvent();
                log.LogWrite(ex.Message);
                return null;
            }
        }

        public DataSet getPermisosByUsuarioId(long usuarioId)
        {
            var dataSet = new DataSet();
            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                try
                {

                    using (var command = new SqlCommand("[dbo].[sp_GET_PermisosByUsuarioId]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@usuarioId", usuarioId);
                        command.CommandTimeout = 0;
                        var adapter = new SqlDataAdapter(command);
                        adapter.Fill(dataSet);

                    }
                    return dataSet;
                }
                catch (System.Exception ex)
                {
                    LogEvent log = new LogEvent();
                    log.LogWrite(ex.Message);

                    return null;
                }

                finally
                {
                    connection.Close();
                }
            }
        }



    }
}
