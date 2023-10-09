using RestSharp;
using System.Text.Json;

namespace RestSharpProject.Services
{
    public class ApiService
    {
        private RestClient _restClient;
        private readonly ScenarioContext _scenarioContext;
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public ApiService(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        public ApiService SetBaseUrl(string baseUrl)
        {
            _scenarioContext.Set(baseUrl);
            _restClient = new RestClient(baseUrl);
            return this;
        }

        public ApiService SetHeader(string header, string value)
        {
            _restClient.AddDefaultHeader(header, value);
            return this;
        }

        public ApiService SetPathAndMethod(string path, Method method)
        {
            _scenarioContext.Get<RestRequest>().Resource = path;
            _scenarioContext.Get<RestRequest>().Method = method;
            return this;
        }

        public ApiService ResetRequest()
        {
            _scenarioContext.Set(new RestRequest());
            return this;
        }

        public ApiService AddBody<T>(T body) where T : class
        {
            _scenarioContext.Get<RestRequest>().AddJsonBody(body);
            return this;
        }

        public ApiService AddParameter(string name, string value)
        {
            _scenarioContext.Get<RestRequest>().AddQueryParameter(name, value);
            return this;
        }

        public ApiService SendRequest()
        {
            RestRequest request = _scenarioContext.Get<RestRequest>();
            logger.Info(request.Method + " " + _scenarioContext.Get<string>() + request.Resource);
            RestResponse response = _restClient.Execute(request);
            _scenarioContext.Set(response);
            logger.Info(response.StatusCode + "\n" + response.Content);
            return this;
        }

        public T GetResponseContent<T>()
        {
            return JsonSerializer.Deserialize<T>(_scenarioContext.Get<RestResponse>().Content);
        }

        public string GetResponseContent()
        {
            return _scenarioContext.Get<RestResponse>().Content;
        }

        public int GetResponseStatusCode()
        {
            return (int)_scenarioContext.Get<RestResponse>().StatusCode;
        }
    }
}
