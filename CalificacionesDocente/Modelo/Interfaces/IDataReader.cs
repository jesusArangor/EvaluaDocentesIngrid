using System.Collections.Generic;

namespace Modelo.Interfaces
{
    public interface IDataReader<T, TId>
    {
        T Obtener(TId id);
        IEnumerable<T> Obtener();
    }
}
