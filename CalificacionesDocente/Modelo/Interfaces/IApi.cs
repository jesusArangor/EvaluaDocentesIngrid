using Modelo.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Interfaces
{
    public interface IApi
    {
        public List<Sede> Sedes();
        public List<Docente> Docentes();
        public List<Docente> Docentes(string documento, int semestre, int anio);
        public List<Curso> Cursos(int id);
        public List<Facultad> Facultades();
        public List<Programa> Programas();
        public List<Formato> Formatos();
        // El file se captura desde request; regresa el id de la carga
        public int CargaEvaluacion();
        public CargaEvaluacion VistaCargaEvaluacion(int id);
        public int ConfirmarCargaEvaluacion(int id, bool aprobacion);
        public int CargaDocente();
        public CargaDocente VistaCargaDocente(int id);
        public int ConfirmarCargaDocente(int id, bool aprobacion);
        public Evaluacion Evaluacion(int id);
        public List<Calificacion> Calificacion(int id);
        public int ActualizarCalificacion(Calificacion calificacion);

        public List<Evaluacion> UltimasEvaluaciones();
        public List<Evaluacion> ConsultaEvaluaciones(/*TODO: Definir parametros*/);
    }
}
