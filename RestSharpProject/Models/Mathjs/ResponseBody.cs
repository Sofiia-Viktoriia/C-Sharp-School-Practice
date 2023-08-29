using System.Text.Json.Serialization;

namespace RestSharpProject.Models.Mathjs
{
    public class ResponseBody
    {
        [JsonPropertyName("result")]
        public string Result { get; set; }
    }
}
