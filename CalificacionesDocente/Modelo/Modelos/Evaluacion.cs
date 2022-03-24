using System;

namespace Modelo.Modelos
{
    public class Evaluacion : CamposControlCrea, CamposControlEdita
    {
        public int Id { get; set; }
        public int CursoId { get; set; }
        public int Sedeid { get; set; }
        public int Facultadid { get; set; }
        public int Programaid { get; set; }
        public int Docenteid { get; set; }
        public int CargaEvaluacionId { get; set; }
        public string Modulo { get; set; }
        public string Curriculo { get; set; }
        public string PlanAula { get; set; }
        public DateTime FechaCrea { get; set; }
        public int UsuarioCrea { get; set; }
        public DateTime? FechaMod { get; set; }
        public int? UsuarioMod { get; set; }
    }
}
