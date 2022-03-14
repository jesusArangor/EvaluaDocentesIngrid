namespace Modelo.Interfaces
{
    public interface IDataLink<T, TId> : IDataReader<T, TId>
    {
        int Insertar(T entidad);
        int Eliminar(T entidad);
    }
}
