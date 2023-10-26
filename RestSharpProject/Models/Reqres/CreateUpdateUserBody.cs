using System.Text.Json.Serialization;

namespace RestSharpProject.Models.Reqres
{
    public class CreateUpdateUserBody
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("job")]
        public string Job { get; set; }
    }
}
