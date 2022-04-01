namespace Modelo.Modelos
{
    public class AuthenticateResponse
    {
        public int Id { get; set; }
        public string Correo { get; set; }
        public string Nombre { get; set; }
        public string Token { get; set; }

        public AuthenticateResponse(Usuario user, string token)
        {
            Id = user.Id;
            Correo = user.Correo;
            Nombre = user.Nombre;
            Token = token;
        }
    }
}
