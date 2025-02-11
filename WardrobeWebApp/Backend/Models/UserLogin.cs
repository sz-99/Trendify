using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Backend.Models
{
    public class UserLogin
    {
        [Key]
        public int UserId { get; set; } 
        public string UserName { get; set; }

        public string Password { get; set; }

        [JsonPropertyName("token")]
        public string? Token { get; set; }

    }
}
