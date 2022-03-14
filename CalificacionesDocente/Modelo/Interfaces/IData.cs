using System;

namespace Modelo.Interfaces
{
    public interface IData<T, TId> : IDataLink<T, TId>
    {
        int Actualizar(T entidad);
    }
}
