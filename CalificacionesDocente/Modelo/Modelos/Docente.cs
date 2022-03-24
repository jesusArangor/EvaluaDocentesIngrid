using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Modelos
{
    public class Docente : CamposControlCrea, CamposControlEdita
    {
        public int Id { get; set; }
        public string Documento { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public int IdCarga { get; set; }
        public DateTime? FechaMod { get; set; }
        public int? UsuarioMod { get; set; }
        public DateTime FechaCrea { get; set; }
        public int UsuarioCrea { get; set; }
    }
}
