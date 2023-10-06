using System.Text.Json.Serialization;

namespace RestSharpProject.Models.Mathjs
{
    public class RequestBody
    {
        [JsonPropertyName("expr")]
        public string Expression { get; set; }

        [JsonPropertyName("precision")]
        public int Precision { get; set; } = 10;

        public RequestBody(string expression)
        {
            Expression = expression;
        }
    }
}
