﻿using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using com.ServiBarras.Infrastructure.Models;
using Newtonsoft.Json.Linq;

namespace com.Servibarras.ApplicationCore.BusinessLogic.Interfaces
{
    public interface IMaquinaBL
    {
        DataSet AsignarMaquinaUsuario(JObject parametrosRuteo);
        Task<List<Maquinas>> GetMaquinasAsync();
    }
}