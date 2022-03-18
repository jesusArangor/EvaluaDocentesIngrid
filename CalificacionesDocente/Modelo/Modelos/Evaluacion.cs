using System;

namespace Modelo.Modelos
{
    public class Evaluacion : CamposControlCrea, CamposControlEdita
    {
     public  int Id { get; set; }
        public string Documento { get; set; }
        public int CursoId { get; set; }
        public int SemestreId { get; set; }
        public int Sedeid { get; set; }
        public DateTime FechaMod { get; set; }
        public int UsuarioMod { get; set; }
        public DateTime FechaCrea { get; set; }
        public int UsuarioCrea { get; set; }
    }
}
