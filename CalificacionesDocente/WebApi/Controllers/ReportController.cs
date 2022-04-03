using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modelo.Interfaces;
using Modelo.Modelos;

namespace WebApi.Controllers
{
    public class ReportController : Controller
    {
        private ICalificacionData dataCalificacion;

        public ReportController(ICalificacionData dataCalificacion) {
            this.dataCalificacion = dataCalificacion;
        }

        [NonAction]
        public ActionResult Evaluacion()
        {
            var lista = dataCalificacion.Obtener(1);
            return PartialView(lista);
        }

    }
}
