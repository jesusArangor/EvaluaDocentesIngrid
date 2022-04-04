using Microsoft.AspNetCore.Mvc;
using Modelo.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Interfaces
{
    public interface IApi
    {
        public IActionResult Sedes();
        public IActionResult Docentes();
        public IActionResult Docentes(string documento, int semestre, int anio);
        public IActionResult Cursos(int id);
        public IActionResult Facultades();
        public IActionResult Programas();
        public IActionResult Formatos();
        // El file se captura desde request; regresa el id de la carga
        public IActionResult CargaEvaluacion();
        public IActionResult VistaCargaEvaluacion(int id);
        public IActionResult ConfirmarCargaEvaluacion(int id, bool aprobacion);
        public IActionResult CargaDocente();
        public IActionResult VistaCargaDocente(int id);
        public IActionResult ConfirmarCargaDocente(int id, bool aprobacion);
        public IActionResult Evaluacion(int id);
        public IActionResult Calificacion(int id);
        public IActionResult ActualizarCalificacion(Calificacion calificacion);
        public IActionResult UltimasEvaluaciones();
        public IActionResult EvaluacionesRestantes();
        public IActionResult ConsultaEvaluaciones(/*TODO: Definir parametros*/);
    }
}
