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
        [HttpPost("CargaDocente")]
        public IActionResult CargaDocente()
        {
            return Ok();
        }

        [HttpPost("CargaEvaluacion")]
        public IActionResult CargaEvaluacion()
        {

            return Ok();
        }

        [HttpPost("ConfirmarCargaDocente")]
        public IActionResult ConfirmarCargaDocente(int id, bool aprobacion)
        {

            return Ok();
        }

        [HttpPost("ConfirmarCargaEvaluacion")]
        public IActionResult ConfirmarCargaEvaluacion(int id, bool aprobacion)
        {

            return Ok();
        }

        [HttpGet("ConsultaEvaluaciones")]
        public IActionResult ConsultaEvaluaciones()
        {

            return Ok(new { estado=true});
        }

        [HttpGet("Cursos/{id}")]
        public IActionResult Cursos(int id)
        {

            return Ok();
        }

        [HttpGet("Docentes")]
        public IActionResult Docentes()
        {

            return Ok();
        }

        [HttpGet("DocentesFiltro")]
        public IActionResult Docentes(string documento, int semestre, int anio)
        {

            return Ok();
        }

        [HttpGet("Evaluacion/{id}")]
        public IActionResult Evaluacion(int id)
        {

            return Ok();
        }

        [HttpGet("EvaluacionesRestantes")]
        public IActionResult EvaluacionesRestantes()
        {

            return Ok();
        }

        [HttpGet("Facultades")]
        public IActionResult Facultades()
        {

            return Ok();
        }

        [HttpGet("Formatos")]
        public IActionResult Formatos()
        {

            return Ok();
        }

        [HttpGet("Programas")]
        public IActionResult Programas()
        {

            return Ok();
        }

        [HttpGet("Sedes")]
        public IActionResult Sedes()
        {

            return Ok();
        }

        [HttpGet("UltimasEvaluaciones")]
        public IActionResult UltimasEvaluaciones()
        {

            return Ok();
        }

        [HttpGet("VistaCargaDocente/{id}")]
        public IActionResult VistaCargaDocente(int id)
        {

            return Ok();
        }

        [HttpGet("VistaCargaEvaluacion/{id}")]
        public IActionResult VistaCargaEvaluacion(int id)
        {

            return Ok();
        }

        /// <summary>
        /// Metodo para calificar cada nota de la evaluación
        /// </summary>
        /// <param name="calificacion">Entidad con el contenido de la calificacion individual</param>
        /// <returns>Estado</returns>
        [HttpPost("ActualizarCalificacion")]
        public IActionResult ActualizarCalificacion(Calificacion calificacion)
        {

            return Ok();
        }

        [HttpGet("Calificacion/{id}")]
        public IActionResult Calificacion(int id)
        {

            return Ok();
        }
    }
}
