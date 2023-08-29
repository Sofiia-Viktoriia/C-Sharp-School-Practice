using System.Text.Json.Serialization;

namespace RestSharpProject.Models.Reqres
{
    public class UserList
    {
        [JsonPropertyName("data")]
        public UserBody[] Data { get; set; }
    }
}
