using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using com.ServiBarras.Infrastructure.DataAccess.Interfaces;
using com.ServiBarras.Infrastructure.ModelDTO;
using com.ServiBarras.Infrastructure.Models;
using com.ServiBarras.Shared.LogEvent;
using Microsoft.EntityFrameworkCore;

namespace com.ServiBarras.Infrastructure.DataAccess
{
    public class ProductoDAL : IProductoDAL
    {
        public TecnoCEDI_bdContext dbcontext;
        /// <summary>
        /// Constructor, se genera una instancia del contexto de la base de datos
        /// </summary>
        public ProductoDAL()
        {
            dbcontext = new TecnoCEDI_bdContext();
        }
        /// <summary>
        ///  Método que consulta los productos existente
        /// </summary>
        /// <returns></returns>
        public DataSet GetProductosAsync()
        {
            var dataSet = new DataSet();

            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();

                try
                {

                    using (var command = new SqlCommand("[dbo].[sp_GET_Productos]", connection))
                    {

                        command.CommandType = System.Data.CommandType.StoredProcedure;
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
        /// <summary>
        /// Método que consulta los productos existente por productoId
        /// </summary>
        /// <param name="productoId"></param>
        /// <returns></returns>
        public async Task<Productos> GetProductoAsync(long productoId)
        {
            var productos = await dbcontext.Productos.FindAsync(productoId);
            return productos;
        }
        /// <summary>
        /// Método que actualiza el producto seleccionado según el productoId
        /// </summary>
        /// <param name="productoId">productoId</param>
        /// <param name="producto"></param>
        /// <returns></returns>
        public async Task UpdateProductoAsync(long productoId, Productos producto)
        {
            if (productoId != producto.productoId)
            {

            }

            dbcontext.Entry(producto).State = EntityState.Modified;

            try
            {
                await dbcontext.SaveChangesAsync();
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (DbUpdateConcurrencyException ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
                if (!ProductoExists(productoId))
                {

                }
                else
                {
                    throw;
                }
            }


        }
        /// <summary>
        /// Método que inserta un producto en la tabla productos
        /// </summary>
        /// <param name="producto"></param>
        public async Task AddProducto(Productos producto)
        {
            try
            {
                dbcontext.Productos.Add(producto);
                await dbcontext.SaveChangesAsync();
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {

                throw;
            }


        }
        /// <summary>
        /// Método que elimina un producto seleccionado según el productoId 
        /// </summary>
        /// <param name="productoId"></param>
        public void DeleteProducto(long productoId)
        {
            var producto = dbcontext.Productos.Find(productoId);
            if (producto == null)
            {

            }

            dbcontext.Productos.Remove(producto);
            dbcontext.SaveChanges();


        }
        /// <summary>
        /// Método que valida si existe o no un producto
        /// </summary>
        /// <param name="productoId"></param>
        /// <returns></returns>
        public bool ProductoExists(long productoId)
        {
            return dbcontext.Productos.Any(e => e.productoId == productoId);
        }



        public async Task<List<DetalleProducto>> GetDetalleProductosAsync()
        {
            List<DetalleProducto> result = new List<DetalleProducto>();
            result = await (from p in dbcontext.Productos
                            join t in dbcontext.Titulares on p.titularId equals t.titularId
                            join o in dbcontext.Ordenantes on t.ordenanteId equals o.ordenanteId
                            join ue in dbcontext.UnidadesEscalares on p.unidadEscalarId equals ue.unidadEscalarId
                            join um in dbcontext.UnidadesManejo on p.unidadManejoId equals um.unidadManejoId
                            select new DetalleProducto
                            {
                                productoId = p.productoId,
                                productoCodigo = p.productoCodigo,
                                productoDescripcion = p.productoDescripcion,
                                ordenanteCodigo = o.ordenanteCodigo,
                                ordenanteDescripcion = o.ordenanteDescripcion,
                                titularId = t.titularId,
                                titularDescripcion = t.titularDescripcion,
                                unidadEscalarId = ue.unidadEscalarId,
                                unidadEscalarDescripcion = ue.unidadEscalarDescripcion,
                                productoCantidadEscalar = (decimal)p.productoCantidadEscalar,
                                unidadManejoId = um.unidadManejoId,
                                unidadManejoDescripcion = um.unidadManejoDescripcion,
                                productoCantidadManejo = p.productoCantidadManejo,
                                productoUnidadInventario = p.productoUnidadInventario
                            }).ToListAsync();


            return result;

        }

        public async Task<DetalleProducto> GetDetalleProductoByIdAsync(long productoId)
        {
            DetalleProducto result = new DetalleProducto();
            result = await (from p in dbcontext.Productos
                            join t in dbcontext.Titulares on p.titularId equals t.titularId
                            join o in dbcontext.Ordenantes on t.ordenanteId equals o.ordenanteId
                            join ue in dbcontext.UnidadesEscalares on p.unidadEscalarId equals ue.unidadEscalarId
                            join um in dbcontext.UnidadesManejo on p.unidadManejoId equals um.unidadManejoId
                            where p.productoId == productoId
                            select new DetalleProducto
                            {
                                productoId = p.productoId,
                                productoCodigo = p.productoCodigo,
                                productoDescripcion = p.productoDescripcion,
                                ordenanteCodigo = o.ordenanteCodigo,
                                ordenanteDescripcion = o.ordenanteDescripcion,
                                titularId = t.titularId,
                                titularDescripcion = t.titularDescripcion,
                                unidadEscalarId = ue.unidadEscalarId,
                                unidadEscalarDescripcion = ue.unidadEscalarDescripcion,
                                productoCantidadEscalar = (decimal)p.productoCantidadEscalar,
                                unidadManejoId = um.unidadManejoId,
                                unidadManejoDescripcion = um.unidadManejoDescripcion,
                                productoCantidadManejo = p.productoCantidadManejo,
                                productoUnidadInventario = p.productoUnidadInventario
                            }).FirstOrDefaultAsync();


            return result;
        }
    }
}