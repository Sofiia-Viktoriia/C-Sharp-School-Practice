using System.Text.Json.Serialization;

namespace RestSharpProject.Models.Reqres
{
    public class UserBodyResponse
    {
        [JsonPropertyName("data")]
        public UserBody Data { get; set; }
    }
}
