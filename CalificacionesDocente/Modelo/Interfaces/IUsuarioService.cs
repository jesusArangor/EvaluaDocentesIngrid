using Modelo.Modelos;
using System.Collections.Generic;

namespace Modelo.Interfaces
{
    public interface IUsuarioService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        IEnumerable<Usuario> GetAll();
        Usuario GetById(int id);
    }
}
