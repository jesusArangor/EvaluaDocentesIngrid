using Modelo.Modelos;
using System.Collections.Generic;

namespace Modelo.Interfaces
{
    public interface IDataBulkDocentes
    {
        int BulkDocentes(IEnumerable<DocenteTemporal> docentes);
    }
}
