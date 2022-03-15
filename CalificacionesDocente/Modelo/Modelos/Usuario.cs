using System;

namespace Modelo.Modelos
{
    public class Usuario : CamposControlCrea
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Password { get; set; }
        public DateTime FechaCrea { get; set; }
        public int UsuarioCrea { get; set; }
    }
}
