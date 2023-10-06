using NUnit.Framework;
using RestSharp;
using RestSharpProject.Constants.Common;
using RestSharpProject.Constants.Reqres;
using RestSharpProject.Models.Reqres;
using System.Text.Json;

namespace RestSharpProject.StepDefinitions
{
    [Binding]
    public class ReqresAPIStepDefinitions
    {
        private readonly RestClient _restClient;
        private readonly ScenarioContext _scenarioContext;
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public ReqresAPIStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _restClient = new RestClient(EndPoints.BaseUrl);
        }

        [When(@"I send request to get list of users")]
        public void WhenISendRequestToGetListOfUsers()
        {
            var request = new RestRequest(EndPoints.Users, Method.Get);
            _scenarioContext["Response"] = ExecuteRequest(request).Result;
        }

        [Then(@"response body contains list of users")]
        public void ThenResponseBodyContainsListOfUsers()
        {
            VerifyResponseCode(ResponseCodes.Success);
            UserList userList = JsonSerializer.Deserialize<UserList>(((RestResponse)_scenarioContext["Response"]).Content);
            Assert.That(userList.Data, Is.Not.Empty, "List does not contain users");
        }

        [When(@"I send request to get a single user with id (.*)")]
        public void WhenISendRequestToGetASingleUserWithId(int userId)
        {
            var request = new RestRequest(EndPoints.UserById(userId), Method.Get);
            _scenarioContext["Response"] = ExecuteRequest(request).Result;
        }

        [Then(@"user is not found")]
        public void ThenUserIsNotFound()
        {
            VerifyResponseCode(ResponseCodes.NotFound);
        }

        [Then(@"response body contains user with id (.*)")]
        public void ThenResponseBodyContainsUserWithId(int userId)
        {
            VerifyResponseCode(ResponseCodes.Success);
            UserBodyResponse user = JsonSerializer.Deserialize<UserBodyResponse>(((RestResponse)_scenarioContext["Response"]).Content);
            Assert.That(user.Data.Id, Is.EqualTo(userId), $"The Id of returned user does not equal {userId}");
        }

        [When(@"I send request to create a user with the following data")]
        public void WhenISendRequestToCreateAUserWithTheFollowingData(CreateUpdateUserBody userCreationBody)
        {
            _scenarioContext["CreateUpdateUserBody"] = userCreationBody;
            var request = new RestRequest(EndPoints.Users, Method.Post);
            request.AddJsonBody(userCreationBody);
            _scenarioContext["Response"] = ExecuteRequest(request).Result;
        }

        [Then(@"user is created")]
        public void ThenUserIsCreated()
        {
            VerifyResponseCode(ResponseCodes.Created);
            VerifyCreateUpdateResponseBody();
        }

        [Then(@"user is updated")]
        public void ThenUserIsUpdated()
        {
            VerifyResponseCode(ResponseCodes.Success);
            VerifyCreateUpdateResponseBody();
        }

        [When(@"I send a request to update a user with id (.*) fully")]
        public void WhenISendARequestToUpdateAUserWithIdFully(int userId, CreateUpdateUserBody userUpdateBody)
        {
            var request = new RestRequest(EndPoints.UserById(userId), Method.Put);
            request.AddJsonBody(userUpdateBody);
            _scenarioContext["CreateUpdateUserBody"] = userUpdateBody;
            _scenarioContext["Response"] = ExecuteRequest(request).Result;
        }

        [When(@"I send a request to update a user with id (.*) partially")]
        public void WhenISendARequestToUpdateAUserWithIdPartially(int userId, CreateUpdateUserBody userUpdateBody)
        {
            var request = new RestRequest(EndPoints.UserById(userId), Method.Patch);
            request.AddJsonBody(userUpdateBody);
            _scenarioContext["CreateUpdateUserBody"] = userUpdateBody;
            _scenarioContext["Response"] = ExecuteRequest(request).Result;
        }

        [When(@"I send request to delete a user with id (.*)")]
        public void WhenISendRequestToDeleteAUserWithId(int userId)
        {
            var request = new RestRequest(EndPoints.UserById(userId), Method.Delete);
            _scenarioContext["Response"] = ExecuteRequest(request).Result;
        }

        [Then(@"user is deleted")]
        public void ThenUserIsDeleted()
        {
            VerifyResponseCode(ResponseCodes.Deleted);
        }

        [When(@"I send request to register with the following data")]
        public void WhenISendRequestToRegisterWithTheFollowingData(LoginRegistrationBody registrationBody)
        {
            var request = new RestRequest(EndPoints.Registration, Method.Post);
            request.AddJsonBody(registrationBody);
            _scenarioContext["Response"] = ExecuteRequest(request).Result;
        }

        [Then(@"user is registered")]
        [Then(@"user is logged in")]
        public void ThenUserIsRegisteredLoggedIn()
        {
            VerifyResponseCode(ResponseCodes.Success);
        }

        [When(@"I send request to login with the following credentials")]
        public void WhenISendRequestToLoginWithTheFollowingCredentials(LoginRegistrationBody loginBody)
        {
            var request = new RestRequest(EndPoints.Login, Method.Post);
            request.AddJsonBody(loginBody);
            _scenarioContext["Response"] = ExecuteRequest(request).Result;
        }

        [Given(@"delay equals (.*) seconds")]
        public void GivenDelayEqualsSeconds(int seconds)
        {
            _scenarioContext["Delay"] = seconds;
        }

        [When(@"I send request to get list of users with delay")]
        public void WhenISendRequestToGetListOfUsersWithDelay()
        {
            var request = new RestRequest(EndPoints.Users, Method.Get);
            request.AddQueryParameter("delay", (int)_scenarioContext["Delay"]);
            _scenarioContext["Response"] = ExecuteRequest(request).Result;
        }

        private async Task<RestResponse> ExecuteRequest(RestRequest request)
        {
            logger.Info(request.Method + " " + EndPoints.BaseUrl + request.Resource);
            return await _restClient.ExecuteAsync(request);
        }

        private void VerifyResponseCode(int code)
        {
            RestResponse response = (RestResponse)_scenarioContext["Response"];
            logger.Info(response.StatusCode + "\n" + response.Content);
            Assert.That((int)response.StatusCode, Is.EqualTo(code), $"Response code does not equal to {code}");
        }

        private void VerifyCreateUpdateResponseBody()
        {
            CreateUpdateUserBody user = JsonSerializer.Deserialize<CreateUpdateUserBody>(((RestResponse)_scenarioContext["Response"]).Content);
            CreateUpdateUserBody expectedUser = (CreateUpdateUserBody)_scenarioContext["CreateUpdateUserBody"];
            Assert.Multiple(() =>
            {
                Assert.That(user.Name, Is.EqualTo(expectedUser.Name), $"The Name of returned user does not equal {expectedUser.Name}");
                Assert.That(user.Job, Is.EqualTo(expectedUser.Job), $"The Job of returned user does not equal {expectedUser.Job}");
            });
        }
    }
}
