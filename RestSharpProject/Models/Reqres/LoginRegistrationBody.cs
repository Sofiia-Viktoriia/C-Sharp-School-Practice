using System.Text.Json.Serialization;

namespace RestSharpProject.Models.Reqres
{
    public class LoginRegistrationBody
    {
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("password")]
        public string Password { get; set; }
    }
}
