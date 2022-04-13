using Modelo.Modelos;
using System.Collections.Generic;

namespace Modelo.Interfaces
{
    public interface IEvaluacionData : IDataReader<Evaluacion, int> {
        IEnumerable<Evaluacion> evaluaciones(int idDocente, int idCurso);
    }
}
