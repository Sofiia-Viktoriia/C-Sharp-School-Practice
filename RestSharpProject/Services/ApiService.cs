using RestSharp;
using System.Text.Json;

namespace RestSharpProject.Services
{
    public class ApiService
    {
        private RestClient _restClient = new();
        private RestRequest _restRequest;
        private readonly ScenarioContext _scenarioContext;
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public ApiService(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        public ApiService SetBaseUrl(string baseUrl)
        {
            _restClient = new RestClient(baseUrl);
            return this;
        }

        public ApiService SetDefaultHeader(string header, string value)
        {
            _restClient.AddDefaultHeader(header, value);
            return this;
        }

        public ApiService SetPathAndMethod(string path, Method method)
        {
            _restRequest.Resource = path;
            _restRequest.Method = method;
            return this;
        }

        public ApiService ResetRequest()
        {
            _restRequest = new RestRequest();
            return this;
        }

        public ApiService AddBody<T>(T body) where T : class
        {
            _restRequest.AddBody(body);
            return this;
        }

        public ApiService AddParameter(string name, string value)
        {
            _restRequest.AddQueryParameter(name, value);
            return this;
        }

        public ApiService SendRequest()
        {
            logger.Info(_restRequest.Method + " " + _restClient.BuildUri(_restRequest) + "\n"
                + JsonSerializer.Serialize(_restRequest.Parameters.Where(p => p.Type == ParameterType.RequestBody).Select(x => x.Value).DefaultIfEmpty("").First()));
            RestResponse response = _restClient.Execute(_restRequest);
            _scenarioContext.Set(response);
            logger.Info(response.StatusCode + "\n" + response.Content);
            return this;
        }

        public T? GetResponseContent<T>()
        {
            return JsonSerializer.Deserialize<T>(_scenarioContext.Get<RestResponse>().Content);
        }

        public string? GetResponseContent()
        {
            return _scenarioContext.Get<RestResponse>().Content;
        }

        public int GetResponseStatusCode()
        {
            return (int)_scenarioContext.Get<RestResponse>().StatusCode;
        }
    }
}
