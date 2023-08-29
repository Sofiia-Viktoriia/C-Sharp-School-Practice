using NUnit.Framework;
using RestSharp;
using RestSharpProject.Constants.Mathjs;
using RestSharpProject.Models.Mathjs;
using System.Text.Json;

namespace RestSharpProject.StepDefinitions
{
    [Binding]
    public class MathjsAPIStepDefinitions
    {
        private readonly RestClient _restClient;
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        private RestResponse _response;

        public MathjsAPIStepDefinitions()
        {
            _restClient = new RestClient(EndPoints.BaseURL);
            _restClient.AddDefaultHeader("User-Agent", "Learning RestSharp");
        }

        [When(@"I send POST request to calculate '([^']*)'")]
        public void WhenISendPOSTRequestToCalculate(string expr)
        {
            var request = new RestRequest();
            request.Method = Method.Post;
            request.AddJsonBody(new RequestBody(expr));
            _response = ExecuteRequest(request).Result;
        }

        [Then(@"response code equals (.*)"), Scope(Tag = "Mathjs")]
        public void ThenResponseCodeEquals(int code)
        {
            logger.Info(_response.StatusCode + "\n" + _response.Content);
            Assert.That((int)_response.StatusCode, Is.EqualTo(code), $"Response code does not equal to {code}");
        }

        [Then(@"response contains the '([^']*)'")]
        public void ThenResponseContainsThe(string result)
        {
            ResponseBody response = JsonSerializer.Deserialize<ResponseBody>(_response.Content);
            Assert.That(response.Result, Is.EqualTo(result), $"The result of expression does not equal {result}");
        }

        [Then(@"response contains the '([^']*)'"), Scope(Tag = "GetRequest")]
        public void ResponseContainsThe(string result)
        {
            Assert.That(_response.Content, Is.EqualTo(result), $"The result of expression does not equal {result}");
        }

        [When(@"I send GET request to calculate '([^']*)'")]
        public void WhenISendGETRequestToCalculate(string expr)
        {
            var request = new RestRequest();
            request.AddQueryParameter("expr", expr);
            _response = ExecuteRequest(request).Result;
        }

        private async Task<RestResponse> ExecuteRequest(RestRequest request)
        {
            logger.Info(request.Method + " " + EndPoints.BaseURL + request.Resource);
            return await _restClient.ExecuteAsync(request);
        }
    }
}
