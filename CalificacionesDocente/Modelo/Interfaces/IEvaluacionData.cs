using Modelo.Modelos;
using System.Collections.Generic;
using System.IO;

namespace Modelo.Interfaces
{
    public interface IEvaluacionData : IDataReader<Evaluacion, int>
    {
        IEnumerable<Evaluacion> Evaluaciones(int idDocente, int idCurso);

        List<EvaluacionTemporal> CargaTemporales(Stream datos, string extension, ref int idCarga);

        int AprobarCarga(int idCarga);
    }
}
