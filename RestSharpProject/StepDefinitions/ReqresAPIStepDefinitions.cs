using NUnit.Framework;
using RestSharp;
using RestSharpProject.Constants.Common;
using RestSharpProject.Constants.Reqres;
using RestSharpProject.Models.Reqres;
using System.Text.Json;
using TechTalk.SpecFlow.Assist;

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

        [When(@"I send request to get a single user")]
        public void WhenISendRequestToGetASingleUser()
        {
            var request = new RestRequest(EndPoints.UserById((int)_scenarioContext["UserId"]), Method.Get);
            _scenarioContext["Response"] = ExecuteRequest(request).Result;
        }

        [Then(@"user is not found")]
        public void ThenUserIsNotFound()
        {
            VerifyResponseCode(ResponseCodes.NotFound);
        }

        [Given(@"user has id (.*)")]
        public void GivenUserHasId(int userId)
        {
            _scenarioContext["UserId"] = userId;
        }

        [Then(@"response body contains user with id (.*)")]
        public void ThenResponseBodyContainsUserWithId(int userId)
        {
            VerifyResponseCode(ResponseCodes.Success);
            UserBodyResponse user = JsonSerializer.Deserialize<UserBodyResponse>(((RestResponse)_scenarioContext["Response"]).Content);
            Assert.That(user.Data.Id, Is.EqualTo(userId), $"The Id of returned user does not equal {userId}");
        }

        [Given(@"user has the following data")]
        public void GivenUserHasTheFollowingData(CreateUpdateUserBody userCreationBody)
        {
            _scenarioContext["CreateUpdateUserBody"] = userCreationBody;
        }

        [When(@"I send request to create a user")]
        public void WhenISendRequestToCreateAUser()
        {
            var request = new RestRequest(EndPoints.Users, Method.Post);
            request.AddJsonBody(_scenarioContext["CreateUpdateUserBody"]);
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

        [Given(@"data for updating user includes")]
        public void GivenDataForUpdatingUserIncludes(CreateUpdateUserBody userUpdateBody)
        {
            _scenarioContext["CreateUpdateUserBody"] = userUpdateBody;
        }

        [When(@"I send PUT request to update a user")]
        public void WhenISendPUTRequestToUpdateAUser()
        {
            var request = new RestRequest(EndPoints.UserById((int)_scenarioContext["UserId"]), Method.Put);
            request.AddJsonBody(_scenarioContext["CreateUpdateUserBody"]);
            _scenarioContext["Response"] = ExecuteRequest(request).Result;
        }

        [When(@"I send PATCH request to update a user")]
        public void WhenISendPATCHRequestToUpdateAUser()
        {
            var request = new RestRequest(EndPoints.UserById((int)_scenarioContext["UserId"]), Method.Patch);
            request.AddJsonBody(_scenarioContext["CreateUpdateUserBody"]);
            _scenarioContext["Response"] = ExecuteRequest(request).Result;
        }

        [When(@"I send request to delete a user")]
        public void WhenISendRequestToDeleteAUser()
        {
            var request = new RestRequest(EndPoints.UserById((int)_scenarioContext["UserId"]), Method.Delete);
            _scenarioContext["Response"] = ExecuteRequest(request).Result;
        }

        [Then(@"user is deleted")]
        public void ThenUserIsDeleted()
        {
            VerifyResponseCode(ResponseCodes.Deleted);
        }

        [Given(@"user has the following registration data")]
        public void GivenUserHasTheFollowingRegistrationData(LoginRegistrationBody registrationBody)
        {
            _scenarioContext["LoginRegistrationBody"] = registrationBody;
        }

        [When(@"I send request to register")]
        public void WhenISendRequestToRegister()
        {
            var request = new RestRequest(EndPoints.Registration, Method.Post);
            request.AddJsonBody(_scenarioContext["LoginRegistrationBody"]);
            _scenarioContext["Response"] = ExecuteRequest(request).Result;
        }

        [Then(@"user is registered")]
        [Then(@"user is logged in")]
        public void ThenUserIsRegisteredLoggedIn()
        {
            VerifyResponseCode(ResponseCodes.Success);
        }

        [Given(@"user has the following login data")]
        public void GivenUserHasTheFollowingLoginData(LoginRegistrationBody loginBody)
        {
            _scenarioContext["LoginRegistrationBody"] = loginBody;
        }

        [When(@"I send request to login")]
        public void WhenISendRequestToLogin()
        {
            var request = new RestRequest(EndPoints.Login, Method.Post);
            request.AddJsonBody(_scenarioContext["LoginRegistrationBody"]);
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
