namespace RestSharpProject.Constants.Reqres
{
    public class EndPoints
    {
        public const string BaseURL = "https://reqres.in/";
        public const string Users = "api/users";
        public static string UserById(int id) => $"api/users/{id}";
        public static string Registration = "api/register";
        public static string Login = "api/login";
    }
}
