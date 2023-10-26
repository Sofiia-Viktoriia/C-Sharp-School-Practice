using NUnit.Framework;
using RestSharp;
using RestSharpProject.Constants.Reqres;
using RestSharpProject.Models.Reqres;
using System.Net;

namespace RestSharpProject.Services
{
    public class ReqresApiService
    {
        private readonly ApiService _apiService;

        public ReqresApiService(ApiService apiService)
        {
            _apiService = apiService;
            _apiService.SetBaseUrl(EndPoints.BaseUrl);
        }

        public ReqresApiService GetListOfUsers()
        {
            _apiService
                .CreateRequest(EndPoints.Users, Method.Get)
                .SendRequest();
            return this;
        }

        public ReqresApiService GetListOfUsersWithDelay(int delay)
        {
            _apiService
                .CreateRequest(EndPoints.Users, Method.Get)
                .AddParameter("delay", delay.ToString())
                .SendRequest();
            return this;
        }

        public ReqresApiService GetSingleUser(int userId)
        {
            _apiService
                .CreateRequest(EndPoints.UserById(userId), Method.Get)
                .SendRequest();
            return this;
        }

        public ReqresApiService CreateUser(CreateUpdateUserBody userCreationBody)
        {
            _apiService
                .CreateRequest(EndPoints.Users, Method.Post)
                .AddBody(userCreationBody)
                .SendRequest();
            return this;
        }

        public ReqresApiService UpdateUser(int userId, CreateUpdateUserBody userUpdateBody, Method method)
        {
            _apiService
                .CreateRequest(EndPoints.UserById(userId), method)
                .AddBody(userUpdateBody)
                .SendRequest();
            return this;
        }

        public ReqresApiService DeleteUser(int userId)
        {
            _apiService
                .CreateRequest(EndPoints.UserById(userId), Method.Delete)
                .SendRequest();
            return this;
        }

        public ReqresApiService Register(LoginRegistrationBody registrationBody)
        {
            _apiService
                .CreateRequest(EndPoints.Registration, Method.Post)
                .AddBody(registrationBody)
                .SendRequest();
            return this;
        }

        public ReqresApiService Login(LoginRegistrationBody loginBody)
        {
            _apiService
                .CreateRequest(EndPoints.Login, Method.Post)
                .AddBody(loginBody)
                .SendRequest();
            return this;
        }

        public ReqresApiService VerifyResponseCode(HttpStatusCode code)
        {
            Assert.That(_apiService.GetResponseStatusCode(), Is.EqualTo(((int)code)), $"Response code does not equal to {((int)code)}");
            return this;
        }

        public ReqresApiService VerifyResponseContainsListOfUsers()
        {
            Assert.That(_apiService.GetResponseContent<UserList>()?.Data, Is.Not.Empty, "List does not contain users");
            return this;
        }

        public ReqresApiService VerifyResponseContainsUserId(int userId)
        {
            Assert.That(_apiService.GetResponseContent<UserBodyResponse>()?.Data.Id, Is.EqualTo(userId), $"The Id of returned user does not equal {userId}");
            return this;
        }

        public ReqresApiService VerifyResponseContainsUserInfo(CreateUpdateUserBody expectedInfo)
        {
            CreateUpdateUserBody? user = _apiService.GetResponseContent<CreateUpdateUserBody>();
            Assert.Multiple(() =>
            {
                Assert.That(user?.Name, Is.EqualTo(expectedInfo.Name), $"The Name of returned user does not equal {expectedInfo.Name}");
                Assert.That(user?.Job, Is.EqualTo(expectedInfo.Job), $"The Job of returned user does not equal {expectedInfo.Job}");
            });
            return this;
        }
    }
}
