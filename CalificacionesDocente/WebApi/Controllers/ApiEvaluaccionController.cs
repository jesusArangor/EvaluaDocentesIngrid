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
        public IActionResult CargaDocente()
        {
            return Ok();
        }

        public IActionResult CargaEvaluacion()
        {

            return Ok();
        }

        public IActionResult ConfirmarCargaDocente(int id, bool aprobacion)
        {

            return Ok();
        }

        public IActionResult ConfirmarCargaEvaluacion(int id, bool aprobacion)
        {

            return Ok();
        }

        public IActionResult ConsultaEvaluaciones()
        {

            return Ok();
        }

        public IActionResult Cursos(int id)
        {

            return Ok();
        }

        public IActionResult Docentes()
        {

            return Ok(); 
        }

        public IActionResult Docentes(string documento, int semestre, int anio)
        {

            return Ok();
        }

        public IActionResult Evaluacion(int id)
        {

            return Ok();
        }

        public IActionResult EvaluacionesRestantes()
        {

            return Ok();
        }

        public IActionResult Facultades()
        {

            return Ok();
        }

        public IActionResult Formatos()
        {

            return Ok();
        }

        public IActionResult Programas()
        {

            return Ok();
        }

        public IActionResult Sedes()
        {

            return Ok();
        }

        public IActionResult UltimasEvaluaciones()
        {

            return Ok();
        }

        public IActionResult VistaCargaDocente(int id)
        {

            return Ok();
        }

        public IActionResult VistaCargaEvaluacion(int id)
        {

            return Ok();
        }

        /// <summary>
        /// Metodo para calificar cada nota de la evaluación
        /// </summary>
        /// <param name="calificacion">Entidad con el contenido de la calificacion individual</param>
        /// <returns>Estado</returns>
        IActionResult IApi.ActualizarCalificacion(Calificacion calificacion)
        {

            return Ok();
        }

        IActionResult IApi.Calificacion(int id)
        {

            return Ok();
        }
    }
}
