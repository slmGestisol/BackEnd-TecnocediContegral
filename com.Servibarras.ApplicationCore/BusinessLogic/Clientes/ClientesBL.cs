using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using com.Servibarras.ApplicationCore.BusinessLogic.Interfaces;
using com.ServiBarras.Infrastructure.DataAccess.Interfaces;
using com.ServiBarras.Infrastructure.Models;
using com.ServiBarras.Shared.ModelDTO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace com.Servibarras.ApplicationCore.BusinessLogic.Clientes
{
    public class ClientesBL: IClientesBL
    {
        private readonly IClientesDAL _clienteDAL;

        public ClientesBL(IClientesDAL clienteDAL)
        {
            this._clienteDAL = clienteDAL;
        }

        public DataSet SetIntegrarClientes()
        {
            return this._clienteDAL.SetIntegrarClientes();
        }
    }
}
