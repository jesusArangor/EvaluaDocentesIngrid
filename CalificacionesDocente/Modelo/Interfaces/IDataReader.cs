using System.Collections.Generic;

namespace Modelo.Interfaces
{
    public interface IDataReader<T, TId> where T : class
    {
        T Obtener(TId id);
        IEnumerable<T> Obtener();
    }
}
