using Microsoft.AspNetCore.Mvc;
using Modelo.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Interfaces
{
    public interface IApi
    {
        public ActionResult<StatusResponse<bool>> ActualizarCalificacion(Calificacion calificacion);

        public ActionResult<StatusResponse<IEnumerable<Calificacion>>> Calificacion(int id);

        public ActionResult<StatusResponse<RespuestaCargaDocente>> CargaDocente();

        // El file se captura desde request; regresa el id de la carga
        public ActionResult<StatusResponse<RespuestaCargaEvaluacion>> CargaEvaluacion();

        public ActionResult<StatusResponse<bool>> ConfirmarCargaDocente(int id, bool aprobacion);

        public ActionResult<StatusResponse<bool>> ConfirmarCargaEvaluacion(int id, bool aprobacion);

        public ActionResult<StatusResponse<IEnumerable<Evaluacion>>> ConsultaEvaluaciones(/*TODO: Definir parametros*/);

        public ActionResult<StatusResponse<IEnumerable<Curso>>> Cursos(int id);

        public ActionResult<StatusResponse<IEnumerable<Docente>>> Docentes();

        public ActionResult<StatusResponse<IEnumerable<Docente>>> Docentes(string documento, int semestre, int anio);

        public ActionResult<StatusResponse<Evaluacion>> Evaluacion(int id);

        public ActionResult<StatusResponse<IEnumerable<Evaluacion>>> EvaluacionDocente(int idDocente, int idCurso);

        public ActionResult<StatusResponse<IEnumerable<Evaluacion>>> EvaluacionesRestantes();

        public ActionResult<StatusResponse<IEnumerable<Facultad>>> Facultades();

        public ActionResult<StatusResponse<IEnumerable<Formato>>> Formatos();

        public ActionResult<StatusResponse<IEnumerable<Programa>>> Programas();

        public ActionResult<StatusResponse<IEnumerable<Sede>>> Sedes();

        public ActionResult<StatusResponse<IEnumerable<Evaluacion>>> UltimasEvaluaciones();

        public ActionResult<StatusResponse<IEnumerable<DocenteTemporal>>> VistaCargaDocente(int id);

        public ActionResult<StatusResponse<IEnumerable<EvaluacionTemporal>>> VistaCargaEvaluacion(int id);
    }
}
