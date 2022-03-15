using System;

namespace Modelo.Modelos
{
    public class Evaluacion : CamposControlCrea, CamposControlEdita
    {
        public DateTime FechaMod { get; set; }
        public int UsuarioMod { get; set; }
        public DateTime FechaCrea { get; set; }
        public int UsuarioCrea { get; set; }
    }
}
