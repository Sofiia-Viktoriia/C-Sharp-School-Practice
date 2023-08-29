using System.Text.Json.Serialization;

namespace RestSharpProject.Models.Mathjs
{
    public class RequestBody
    {
        [JsonPropertyName("expr")]
        public string Expression { get; set; }

        public RequestBody(string expression)
        {
            Expression = expression;
        }
    }
}
