namespace Modelo.Interfaces
{
    public interface IDataLink<T, TId> : IDataReader<T, TId> where T : class
    {
        int Insertar(T entidad);
        int Eliminar(T entidad);
    }
}
