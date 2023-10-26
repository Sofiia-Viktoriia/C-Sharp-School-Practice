using NUnit.Framework;
using RestSharp;
using RestSharpProject.Constants.Mathjs;
using RestSharpProject.Models.Mathjs;
using System.Net;
using System.Numerics;

namespace RestSharpProject.Services
{
    public class MathjsApiService
    {
        private readonly ApiService _apiService;

        public MathjsApiService(ApiService apiService)
        {
            _apiService = apiService;
            _apiService
                .SetBaseUrl(EndPoints.BaseUrl)
                .SetDefaultHeader("User-Agent", "Learning RestSharp");
        }

        public MathjsApiService PostCalculateExpression(string expr)
        {
            _apiService
                .ResetRequest()
                .SetPathAndMethod(EndPoints.ExpressionCalculation, Method.Post)
                .AddBody(new RequestBody(expr))
                .SendRequest();
            return this;
        }

        public MathjsApiService GetCalculateExpression(double value)
        {
            _apiService
                .ResetRequest()
                .SetPathAndMethod(EndPoints.ExpressionCalculation, Method.Get)
                .AddParameter("expr", $"sqrt({value})")
                .SendRequest();
            return this;
        }

        public MathjsApiService VerifyResponseIsSuccess()
        {
            Assert.That(_apiService.GetResponseStatusCode(), Is.EqualTo(((int)HttpStatusCode.OK)), $"Response code does not equal to {((int)HttpStatusCode.OK)}");
            return this;
        }

        public MathjsApiService VerifyPostCalculationResult(string result)
        {
            ResponseBody? response = _apiService.GetResponseContent<ResponseBody>();
            Assert.That(response?.Result, Is.EqualTo(result), $"The result of expression does not equal {result}");
            return this;
        }

        public MathjsApiService VerifyGetCalculationResult(double value)
        {
            string result;
            if (value >= 0)
            {
                result = Complex.Sqrt(value).Real.ToString();
            }
            else
            {
                result = Complex.Sqrt(value).Imaginary.ToString() + 'i';
            }
            Assert.That(_apiService.GetResponseContent(), Is.EqualTo(result), $"The result of expression does not equal {result}");
            return this;
        }
    }
}
