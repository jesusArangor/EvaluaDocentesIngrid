using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Modelo.Interfaces;
using Modelo.Modelos;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Servicios
{
    public class UsuarioService : IUsuarioService
    {
        
        private readonly AppSettings _appSettings;
        private readonly IUsuarioData usuarioData;

        public UsuarioService(IOptions<AppSettings> appSettings, IUsuarioData usuarioData) 
        {
            _appSettings = appSettings.Value;
            this.usuarioData = usuarioData;
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var user = usuarioData.Autenticar(model.Username, model.Password);
          
            // return null if user not found
            if (user == null) return null;

            // authentication successful so generate jwt token
            var token = generateJwtToken(user);

            return new AuthenticateResponse(user, token);
        }

        public IEnumerable<Usuario> GetAll()
        {
            return usuarioData.Obtener();
        }

        public Usuario GetById(int id)
        {
            return usuarioData.Obtener(id);
        }

        // helper methods

        private string generateJwtToken(Usuario user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_appSettings.Secret); 
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials( new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        public static SecurityKey CreateSecurityKey(string securityKey)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
        }
    }
}
