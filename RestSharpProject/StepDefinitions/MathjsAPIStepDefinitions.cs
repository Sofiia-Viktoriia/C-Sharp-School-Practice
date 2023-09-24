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
        private readonly ScenarioContext _scenarioContext;
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public MathjsAPIStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _restClient = new RestClient(EndPoints.BaseURL);
            _restClient.AddDefaultHeader("User-Agent", "Learning RestSharp");
        }

        [When(@"I send POST request to calculate '([^']*)'")]
        public void WhenISendPOSTRequestToCalculate(string expr)
        {
            var request = new RestRequest();
            request.Method = Method.Post;
            request.AddJsonBody(new RequestBody(expr));
            _scenarioContext["Response"] = ExecuteRequest(request).Result;
        }

        [Then(@"response code equals (.*)"), Scope(Tag = "Mathjs")]
        public void ThenResponseCodeEquals(int code)
        {
            RestResponse response = (RestResponse)_scenarioContext["Response"];
            logger.Info(response.StatusCode + "\n" + response.Content);
            Assert.That((int)response.StatusCode, Is.EqualTo(code), $"Response code does not equal to {code}");
        }

        [Then(@"response contains the '([^']*)'")]
        public void ThenResponseContainsThe(string result)
        {
            ResponseBody response = JsonSerializer.Deserialize<ResponseBody>(((RestResponse)_scenarioContext["Response"]).Content);
            Assert.That(response.Result, Is.EqualTo(result), $"The result of expression does not equal {result}");
        }

        [Then(@"response contains the '([^']*)'"), Scope(Tag = "GetRequest")]
        public void ResponseContainsThe(string result)
        {
            Assert.That(((RestResponse)_scenarioContext["Response"]).Content, Is.EqualTo(result), $"The result of expression does not equal {result}");
        }

        [When(@"I send GET request to calculate '([^']*)'")]
        public void WhenISendGETRequestToCalculate(string expr)
        {
            var request = new RestRequest();
            request.AddQueryParameter("expr", expr);
            _scenarioContext["Response"] = ExecuteRequest(request).Result;
        }

        private async Task<RestResponse> ExecuteRequest(RestRequest request)
        {
            logger.Info(request.Method + " " + EndPoints.BaseURL + request.Resource);
            return await _restClient.ExecuteAsync(request);
        }
    }
}
