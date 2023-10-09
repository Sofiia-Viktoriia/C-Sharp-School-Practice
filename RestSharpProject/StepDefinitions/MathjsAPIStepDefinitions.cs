using RestSharpProject.Services;

namespace RestSharpProject.StepDefinitions
{
    [Binding]
    public class MathjsAPIStepDefinitions
    {
        private readonly MathjsApiService _mathjsApiService;

        public MathjsAPIStepDefinitions(MathjsApiService mathjsApiService)
        {
            _mathjsApiService = mathjsApiService;
            _mathjsApiService.SetRestClient();
        }

        [When(@"I send a request to calculate '([^']*)'")]
        public void WhenISendARequestToCalculate(string expr)
        {
            _mathjsApiService.PostCalculateExpression(expr);
        }

        [Then(@"response contains the '([^']*)'")]
        public void ThenResponseContainsThe(string result)
        {
            _mathjsApiService
                .VerifyResponseIsSuccess()
                .VerifyPostCalculationResult(result);
        }

        [Then(@"response contains the correct square root of a ([^']*) value")]
        public void ResponseContainsTheCorrectSquareRootOfAValue(double value)
        {
            _mathjsApiService
                .VerifyResponseIsSuccess()
                .VerifyGetCalculationResult(value);
        }

        [When(@"I send a request to get a square root of a ([^']*)")]
        public void ISendARequestToGetASquareRootOfA(double value)
        {
            _mathjsApiService.GetCalculateExpression(value);
        }
    }
}
