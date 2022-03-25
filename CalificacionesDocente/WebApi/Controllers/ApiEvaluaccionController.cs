using Microsoft.AspNetCore.Mvc;
using Modelo.Interfaces;

namespace WebApi.Controllers
{
    public class ApiEvaluaccionController : Controller, IApi
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
