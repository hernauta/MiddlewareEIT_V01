using System.ComponentModel.DataAnnotations;

namespace MiddlewareEIT.API.Models.Users
{
    public class RegisterRequest
    {
        [Required]
        public int RutCliente { get; set; }
        [Required]
        public string DvCliente { get; set; }
        [Required]
        public string Libreria { get; set; }
        [Required]
        public string UsuarioWms { get; set; }
        [Required]
        public string PasswordWms { get; set; }
        [Required]
        public string Owner { get; set; }

    }
}