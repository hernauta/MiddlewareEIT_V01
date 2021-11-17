namespace MiddlewareEIT.API.Models.Users
{
    public class AuthenticateResponse
    {
        public int Id { get; set; }
        public string RutCliente { get; set; }
        public string DvCliente { get; set; }
        public string UsuarioWms { get; set; }
        public string Owner { get; set; }
        
        public string JwtToken { get; set; }
    }
}