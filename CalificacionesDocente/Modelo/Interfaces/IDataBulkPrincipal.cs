﻿using Modelo.Modelos;
using System.Collections.Generic;

namespace Modelo.Interfaces
{
    public interface IDataBulkPrincipal
    {
        int BulkDatos(IEnumerable<CargaTemporal> entidades);
    }
}