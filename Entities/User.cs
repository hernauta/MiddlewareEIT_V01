using System.Text.Json.Serialization;

namespace MiddlewareEIT.API.Entities
{
    public class User
    {
        public int Id { get; set; }
        public int RutCliente { get; set; }
        public string DvCliente { get; set; }
        public string Libreria { get; set; }
        public string UsuarioWms { get; set; }
        public string Owner { get; set; }

        [JsonIgnore]
        public string PasswordWms { get; set; }       

    }
}