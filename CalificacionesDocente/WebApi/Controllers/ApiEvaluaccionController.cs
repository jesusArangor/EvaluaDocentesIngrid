using Microsoft.AspNetCore.Mvc;
using Modelo.Interfaces;
using Modelo.Modelos;
using System.Collections.Generic;

namespace WebApi.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    [Route("Api/Evaluacion")]
    public class ApiEvaluaccionController : Controller, IApi
    {
        /// <summary>
        /// Metodo para calificar cada nota de la evaluación
        /// </summary>
        /// <param name="calificacion">Entidad con el contenido de la calificacion individual</param>
        /// <returns>Estado</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public int ActualizarCalificacion(Calificacion calificacion)
        {
            throw new System.NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public List<Calificacion> Calificacion(int id)
        {
            throw new System.NotImplementedException();
        }

        public int CargaDocente()
        {
            throw new System.NotImplementedException();
        }

        public int CargaEvaluacion()
        {
            throw new System.NotImplementedException();
        }

        public int ConfirmarCargaDocente(int id, bool aprobacion)
        {
            throw new System.NotImplementedException();
        }

        public int ConfirmarCargaEvaluacion(int id, bool aprobacion)
        {
            throw new System.NotImplementedException();
        }

        public List<Evaluacion> ConsultaEvaluaciones()
        {
            throw new System.NotImplementedException();
        }

        public List<Curso> Cursos(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<Docente> Docentes()
        {
            throw new System.NotImplementedException();
        }

        public List<Docente> Docentes(string documento, int semestre, int anio)
        {
            throw new System.NotImplementedException();
        }

        public Evaluacion Evaluacion(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<Evaluacion> EvaluacionesRestantes()
        {
            throw new System.NotImplementedException();
        }

        public List<Facultad> Facultades()
        {
            throw new System.NotImplementedException();
        }

        public List<Formato> Formatos()
        {
            throw new System.NotImplementedException();
        }

        public List<Programa> Programas()
        {
            throw new System.NotImplementedException();
        }

        public List<Sede> Sedes()
        {
            throw new System.NotImplementedException();
        }

        public List<Evaluacion> UltimasEvaluaciones()
        {
            throw new System.NotImplementedException();
        }

        public CargaDocente VistaCargaDocente(int id)
        {
            throw new System.NotImplementedException();
        }

        public CargaEvaluacion VistaCargaEvaluacion(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
