using System;

namespace Modelo.Interfaces
{
    public interface IData<T, TId> : IDataLink<T, TId> where T : class
    {
        int Actualizar(T entidad);
    }
}
