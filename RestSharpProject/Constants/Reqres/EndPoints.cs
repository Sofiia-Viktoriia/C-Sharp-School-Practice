namespace RestSharpProject.Constants.Reqres
{
    public static class EndPoints
    {
        public const string BaseUrl = "https://reqres.in";
        public const string Users = "/api/users";
        public static string UserById(int id) => $"/api/users/{id}";
        public const string Registration = "/api/register";
        public const string Login = "/api/login";
    }
}
