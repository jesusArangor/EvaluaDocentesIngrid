using System;

namespace Modelo.Modelos
{
    public class Calificacion : CamposControlCrea, CamposControlEdita
    {
        public int Id { get; set; }
        public int FormatoId { get; set; }
        public int EvaluacionId { get; set; }
        public int Nota { get; set; }
        public string Observacion { get; set; }
        public bool? PlanMejora { get; set; }
        public DateTime? FechaMod { get; set; }
        public int? UsuarioMod { get; set; }
        public DateTime FechaCrea { get; set; }
        public int UsuarioCrea { get; set; }
    }
}
