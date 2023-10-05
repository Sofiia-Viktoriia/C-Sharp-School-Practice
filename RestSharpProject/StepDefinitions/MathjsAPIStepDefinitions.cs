using NUnit.Framework;
using RestSharp;
using RestSharpProject.Constants.Common;
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
            _restClient = new RestClient(EndPoints.BaseUrl);
            _restClient.AddDefaultHeader("User-Agent", "Learning RestSharp");
        }

        [When(@"I send a request to calculate '([^']*)'"), Scope(Tag = "PostRequest")]
        public void WhenISendPostRequestToCalculate(string expr)
        {
            var request = new RestRequest(EndPoints.ExpressionCalculation, Method.Post);
            request.AddJsonBody(new RequestBody(expr));
            _scenarioContext["Response"] = ExecuteRequest(request).Result;
        }

        [Then(@"response contains the '([^']*)'"), Scope(Tag = "PostRequest")]
        public void ThenResponseContainsThe(string result)
        {
            VerifyResponseIsSuccess();
            ResponseBody response = JsonSerializer.Deserialize<ResponseBody>(((RestResponse)_scenarioContext["Response"]).Content);
            Assert.That(response.Result, Is.EqualTo(result), $"The result of expression does not equal {result}");
        }

        [Then(@"response contains the '([^']*)'"), Scope(Tag = "GetRequest")]
        public void ResponseContainsThe(string result)
        {
            VerifyResponseIsSuccess();
            Assert.That(((RestResponse)_scenarioContext["Response"]).Content, Is.EqualTo(result), $"The result of expression does not equal {result}");
        }

        [When(@"I send a request to calculate '([^']*)'"), Scope(Tag = "GetRequest")]
        public void WhenISendGetRequestToCalculate(string expr)
        {
            var request = new RestRequest(EndPoints.ExpressionCalculation, Method.Get);
            request.AddQueryParameter("expr", expr);
            _scenarioContext["Response"] = ExecuteRequest(request).Result;
        }

        private async Task<RestResponse> ExecuteRequest(RestRequest request)
        {
            logger.Info(request.Method + " " + EndPoints.BaseUrl + request.Resource);
            return await _restClient.ExecuteAsync(request);
        }

        private void VerifyResponseIsSuccess()
        {
            RestResponse response = (RestResponse)_scenarioContext["Response"];
            logger.Info(response.StatusCode + "\n" + response.Content);
            Assert.That((int)response.StatusCode, Is.EqualTo(ResponseCodes.Success), $"Response code does not equal to {ResponseCodes.Success}");
        }
    }
}
