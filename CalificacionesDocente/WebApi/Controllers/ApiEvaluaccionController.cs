using DocumentFormat.OpenXml.Drawing.Diagrams;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modelo.Interfaces;
using Modelo.Modelos;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;

namespace WebApi.Controllers
{
    /// <summary>
    /// Api general para consumo de metodos para evalucacion docente
    /// </summary>
    [SwaggerTag(description: "Web API para Manejo de datos de ala apliccion evaluacion docente.")]
    [ApiController]
    [Route("Api/Evaluacion")]
    public class ApiEvaluaccionController : Controller, IApi
    {
        private readonly IDataReader<Curso, int> cursoDb;
        private readonly IDocenteData docenteData;
        private readonly IEvaluacionData evalucionData;
        private readonly IDataReader<Facultad, int> facultadDb;
        private readonly IDataReader<Formato, int> formatoDb;
        private readonly IDataReader<Programa, int> programaDb;
        private readonly IDataReader<Sede, int> sedeDb;
        public ApiEvaluaccionController(IDataReader<Facultad, int> facultadDb, IDataReader<Formato, int> formatoDb,
               IDataReader<Programa, int> programaDb, IDataReader<Sede, int> sedeDb, IDataReader<Curso, int> cursoDb,
               IEvaluacionData evalucionData, IDocenteData docenteData)
        {
            this.facultadDb = facultadDb;
            this.formatoDb = formatoDb;
            this.programaDb = programaDb;
            this.sedeDb = sedeDb;
            this.cursoDb = cursoDb;
            this.evalucionData = evalucionData;
            this.docenteData = docenteData;
        }

        /// <summary>
        /// Metodo para calificar cada nota de la evaluación
        /// </summary>
        /// <param name="calificacion">Entidad con el contenido de la calificacion individual</param>
        /// <returns>Estado</returns>
        [HttpPost("ActualizarCalificacion")]
        public ActionResult<StatusResponse<bool>> ActualizarCalificacion(Calificacion calificacion)
        {

            return Ok();
        }

        [HttpGet("Calificacion/{id}")]
        public ActionResult<StatusResponse<IEnumerable<Calificacion>>> Calificacion(int id)
        {

            return Ok();
        }

        /// <summary>
        /// Permite la carga de datos de docente
        /// </summary>
        /// <remarks>
        /// Permite la carga de datos de docente, transmitiendo un archivo via post
        /// </remarks>
        /// <response code="401">Unauthorized. No se ha indicado o es incorrecto el Token JWT de acceso.</response>              
        /// <response code="200">OK. Carga realizada con exito.</response>        
        /// <response code="400">Pericion rechazada por error en en servidor.</response>        
        [HttpPost("CargaDocente")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<StatusResponse<RespuestaCargaDocente>> CargaDocente()
        {
            try
            {
                var file = Request.Form.Files[0];

                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var extension = Path.GetExtension(fileName);
                    int idcarga = 0;
                    var temporales = docenteData.CargaTemporales(file.OpenReadStream(), extension, ref idcarga);
                    var respuesta = new StatusResponse<RespuestaCargaDocente>
                    {
                        Success = false,
                        Content = new RespuestaCargaDocente
                        {
                            Datos = temporales,
                            IdCarga = idcarga
                        }
                    };
                    return Ok(respuesta);
                }
                else
                {
                    return BadRequest();
                }

            }
            catch (Exception ex)
            {
                var respuesta = new StatusResponse<RespuestaCargaDocente> { Success = false, Message = ex.Message };
                return BadRequest(respuesta);
            }
        }

        [HttpPost("CargaEvaluacion")]
        public ActionResult<StatusResponse<RespuestaCargaEvaluacion>> CargaEvaluacion()
        {

            return Ok();
        }

        [HttpPost("ConfirmarCargaDocente")]
        public ActionResult<StatusResponse<bool>> ConfirmarCargaDocente(int id, bool aprobacion)
        {

            return Ok();
        }

        [HttpPost("ConfirmarCargaEvaluacion")]
        public ActionResult<StatusResponse<bool>> ConfirmarCargaEvaluacion(int id, bool aprobacion)
        {

            return Ok();
        }

        [HttpGet("ConsultaEvaluaciones")]
        public ActionResult<StatusResponse<IEnumerable<Evaluacion>>> ConsultaEvaluaciones()
        {

            return Ok(new { estado = true });
        }

        [HttpGet("Cursos/{id}")]
        public ActionResult<StatusResponse<IEnumerable<Curso>>> Cursos(int id)
        {
            try
            {
                var lista = cursoDb.Obtener();
                var respuesta = new StatusResponse<IEnumerable<Curso>> { Success = true, Content = lista };
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                var respuesta = new StatusResponse<IEnumerable<Curso>> { Success = false, Message = ex.Message };
                return BadRequest(respuesta);
            }
        }

        [HttpGet("Docentes")]
        public ActionResult<StatusResponse<IEnumerable<Docente>>> Docentes()
        {

            return Ok();
        }

        [HttpGet("DocentesFiltro")]
        public ActionResult<StatusResponse<IEnumerable<Docente>>> Docentes(string documento, int semestre, int anio)
        {

            return Ok();
        }

        [HttpGet("Evaluacion/{id}")]
        public ActionResult<StatusResponse<Evaluacion>> Evaluacion(int id)
        {
            try
            {
                var data = evalucionData.Obtener(id);
                var respuesta = new StatusResponse<Evaluacion> { Success = true, Content = data };
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                var respuesta = new StatusResponse<Evaluacion> { Success = false, Message = ex.Message };
                return BadRequest(respuesta);
            }
        }

        [HttpGet("EvaluacionDocente")]
        public ActionResult<StatusResponse<IEnumerable<Evaluacion>>> EvaluacionDocente(int idDocente, int idCurso)
        {
            try
            {
                var data = evalucionData.Evaluaciones(idDocente, idCurso);
                var respuesta = new StatusResponse<IEnumerable<Evaluacion>> { Success = true, Content = data };
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                var respuesta = new StatusResponse<IEnumerable<Evaluacion>> { Success = false, Message = ex.Message };
                return BadRequest(respuesta);
            }
        }

        [HttpGet("EvaluacionesRestantes")]
        public ActionResult<StatusResponse<IEnumerable<Evaluacion>>> EvaluacionesRestantes()
        {

            return Ok();
        }

        [HttpGet("Facultades")]
        public ActionResult<StatusResponse<IEnumerable<Facultad>>> Facultades()
        {
            try
            {
                var lista = facultadDb.Obtener();
                var respuesta = new StatusResponse<IEnumerable<Facultad>> { Success = true, Content = lista };
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                var respuesta = new StatusResponse<IEnumerable<Facultad>> { Success = false, Message = ex.Message };
                return BadRequest(respuesta);
            }
        }

        [HttpGet("Formatos")]
        public ActionResult<StatusResponse<IEnumerable<Formato>>> Formatos()
        {
            try
            {
                var lista = formatoDb.Obtener();
                var respuesta = new StatusResponse<IEnumerable<Formato>> { Success = true, Content = lista };
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                var respuesta = new StatusResponse<IEnumerable<Formato>> { Success = false, Message = ex.Message };
                return BadRequest(respuesta);
            }
        }

        [HttpGet("Programas")]
        public ActionResult<StatusResponse<IEnumerable<Programa>>> Programas()
        {
            try
            {
                var lista = programaDb.Obtener();
                var respuesta = new StatusResponse<IEnumerable<Programa>> { Success = true, Content = lista };
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                var respuesta = new StatusResponse<IEnumerable<Programa>> { Success = false, Message = ex.Message };
                return BadRequest(respuesta);
            }
        }

        [HttpGet("Sedes")]
        public ActionResult<StatusResponse<IEnumerable<Sede>>> Sedes()
        {
            try
            {
                var lista = sedeDb.Obtener();
                var respuesta = new StatusResponse<IEnumerable<Sede>> { Success = true, Content = lista };
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                var respuesta = new StatusResponse<IEnumerable<Sede>> { Success = false, Message = ex.Message };
                return BadRequest(respuesta);
            }
        }

        [HttpGet("UltimasEvaluaciones")]
        public ActionResult<StatusResponse<IEnumerable<Evaluacion>>> UltimasEvaluaciones()
        {

            return Ok();
        }

        [HttpGet("VistaCargaDocente/{id}")]
        public ActionResult<StatusResponse<IEnumerable<DocenteTemporal>>> VistaCargaDocente(int id)
        {

            return Ok();
        }

        [HttpGet("VistaCargaEvaluacion/{id}")]
        public ActionResult<StatusResponse<IEnumerable<EvaluacionTemporal>>> VistaCargaEvaluacion(int id)
        {

            return Ok();
        }
    }
}
