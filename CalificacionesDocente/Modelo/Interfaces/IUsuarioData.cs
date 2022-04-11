using Modelo.Modelos;

namespace Modelo.Interfaces
{
    public interface IUsuarioData : IDataReader<Usuario, int>
    {
        Usuario Autenticar(string correo, string password);
        Usuario ObtenerxLogin(string correo);
    }
}
