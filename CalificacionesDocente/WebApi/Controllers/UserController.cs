using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Modelo.Interfaces;
using Modelo.Modelos;
using Swashbuckle.AspNetCore.Annotations;
using WebApi.Helpers;

namespace WebApi.Controllers
{
    [SwaggerTag(description: "Web API para autenticación de Usuarios.")]
    [ApiController]
    [Route("Api/Users")]
    public class UsersController : ControllerBase
    {
        private IUsuarioService _userService;

        public UsersController(IUsuarioService userService)
        {
            _userService = userService;
        }
                
        [HttpPost("Authenticate")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            var response = _userService.Authenticate(model);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }       
    }
}