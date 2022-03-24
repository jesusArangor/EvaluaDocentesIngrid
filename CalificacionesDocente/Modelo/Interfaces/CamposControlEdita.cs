using System;

namespace Modelo.Modelos
{
    public interface CamposControlEdita {
        DateTime? FechaMod { get; set; }
        int? UsuarioMod { get; set; }
    }
}
