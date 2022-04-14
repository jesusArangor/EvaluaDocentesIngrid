using Modelo.Modelos;
using System.Collections.Generic;
using System.IO;

namespace Modelo.Interfaces
{
    public interface IDocenteData : IDataReader<Docente, int>
    {
        IEnumerable<Docente> Docentes(int docmento);

        List<DocenteTemporal> CargaTemporales(Stream datos, string extension, ref int idCarga);

        int AprobarCarga(int idCarga);
    }
}
