using Microsoft.AspNetCore.Mvc;
using Modelo.Interfaces;
using Modelo.Modelos;
using System;
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
        private readonly IDataReader<Facultad, int> facultadDb;
        private readonly IDataReader<Formato, int> formatoDb;
        private readonly IDataReader<Programa, int> programaDb;
        private readonly IDataReader<Sede, int> sedeDb;
        private readonly IDataReader<Curso, int> cursoDb;
        private readonly IEvaluacionData evalucionData;

        public ApiEvaluaccionController(IDataReader<Facultad, int> facultadDb, IDataReader<Formato, int> formatoDb,
               IDataReader<Programa, int> programaDb, IDataReader<Sede, int> sedeDb, IDataReader<Curso, int> cursoDb,
               IEvaluacionData evalucionData)
        {
            this.facultadDb = facultadDb;
            this.formatoDb = formatoDb;
            this.programaDb = programaDb;
            this.sedeDb = sedeDb;
            this.cursoDb = cursoDb;
            this.evalucionData = evalucionData;
        }

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

            return Ok(new { estado = true });
        }

        [HttpGet("Cursos/{id}")]
        public IActionResult Cursos(int id)
        {
            try
            {
                var lista = cursoDb.Obtener();
                var respuesta = new StatusResponse { Success = true, Content = lista };
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                var respuesta = new StatusResponse { Success = false, Message = ex.Message };
                return BadRequest(respuesta);
            }
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
            try
            {
                var data = evalucionData.Obtener(id);
                var respuesta = new StatusResponse { Success = true, Content = data };
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                var respuesta = new StatusResponse { Success = false, Message = ex.Message };
                return BadRequest(respuesta);
            }
        }

        [HttpGet("EvaluacionesRestantes")]
        public IActionResult EvaluacionesRestantes()
        {

            return Ok();
        }

        [HttpGet("Facultades")]
        public IActionResult Facultades()
        {
            try
            {
                var lista = facultadDb.Obtener();
                var respuesta = new StatusResponse { Success = true, Content = lista };
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                var respuesta = new StatusResponse { Success = false, Message = ex.Message };
                return BadRequest(respuesta);
            }
        }

        [HttpGet("Formatos")]
        public IActionResult Formatos()
        {
            try
            {
                var lista = formatoDb.Obtener();
                var respuesta = new StatusResponse { Success = true, Content = lista };
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                var respuesta = new StatusResponse { Success = false, Message = ex.Message };
                return BadRequest(respuesta);
            }
        }

        [HttpGet("Programas")]
        public IActionResult Programas()
        {
            try
            {
                var lista = programaDb.Obtener();
                var respuesta = new StatusResponse { Success = true, Content = lista };
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                var respuesta = new StatusResponse { Success = false, Message = ex.Message };
                return BadRequest(respuesta);
            }
        }

        [HttpGet("Sedes")]
        public IActionResult Sedes()
        {
            try
            {
                var lista = sedeDb.Obtener();
                var respuesta = new StatusResponse { Success = true, Content = lista };
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                var respuesta = new StatusResponse { Success = false, Message = ex.Message };
                return BadRequest(respuesta);
            }
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

        [HttpGet("EvaluacionDocente")]
        public IActionResult EvaluacionDocente(int idDocente, int idCurso)
        {
            try
            {
                var data = evalucionData.evaluaciones(idDocente, idCurso);             
                var respuesta = new StatusResponse { Success = true, Content = data };
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                var respuesta = new StatusResponse { Success = false, Message = ex.Message };
                return BadRequest(respuesta);
            }           
        }
    }
}
