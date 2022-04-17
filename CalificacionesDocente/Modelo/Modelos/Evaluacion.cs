using System;

namespace Modelo.Modelos
{
    public class Evaluacion : CamposControlCrea, CamposControlEdita
    {
        public int Id { get; set; }
        public int CursoId { get; set; }
        public int SedeId { get; set; }
        public int FacultadId { get; set; }
        public int ProgramaId { get; set; }
        public int DocenteId { get; set; }
        public int CargaEvaluacionId { get; set; }
        public string Modulo { get; set; }
        public string Curriculo { get; set; }
        public string PlanAula { get; set; }
        public int Estado { get; set; }
        public DateTime FechaCrea { get; set; }
        public int UsuarioCrea { get; set; }
        public DateTime? FechaMod { get; set; }
        public int? UsuarioMod { get; set; }
        public string NombreCurso { get; set; }
        public string NombreSede { get; set; }
        public string NombreFacultad { get; set; }
        public string NombrePrograma { get; set; }
        public string NombreDocente { get; set; }
        public string DocumentoDocente { get; set; }
        public string CorreoDocente { get; set; }
        public string TelefonoDocente { get; set; }
        public string Nombreusumodifica { get; set; }
        public string NombreUsuIngresa { get; set; }
        public string NombreArchivoCarga { get; set; }
        public int SemestreCarga { get; set; }
        public int AnioCarga { get; set; }
    }
}
