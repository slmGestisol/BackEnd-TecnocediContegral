﻿using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using com.ServiBarras.Infrastructure.Models;

namespace com.ServiBarras.Infrastructure.DataAccess.Interfaces
{
    public interface IRFIDDAL
    {
        DataSet GetPortalRFIDContenedores(long idPortal,long despachoConsecutivo,string inicioCaptura);
    }
}