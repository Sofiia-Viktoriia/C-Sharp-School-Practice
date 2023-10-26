using RestSharp;
using RestSharpProject.Models.Reqres;
using RestSharpProject.Services;
using System.Net;

namespace RestSharpProject.StepDefinitions
{
    [Binding]
    public class ReqresAPIStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly ReqresApiService _reqresApiService;

        public ReqresAPIStepDefinitions(ScenarioContext scenarioContext, ReqresApiService reqresApiService)
        {
            _scenarioContext = scenarioContext;
            _reqresApiService = reqresApiService;
            _reqresApiService.SetRestClient();
        }

        [When(@"I send request to get list of users")]
        public void WhenISendRequestToGetListOfUsers()
        {
            _reqresApiService.GetListOfUsers();
        }

        [Then(@"response body contains list of users")]
        public void ThenResponseBodyContainsListOfUsers()
        {
            _reqresApiService
                .VerifyResponseCode(HttpStatusCode.OK)
                .VerifyResponseContainsListOfUsers();
        }

        [When(@"I send request to get a single user with id (.*)")]
        public void WhenISendRequestToGetASingleUserWithId(int userId)
        {
            _reqresApiService.GetSingleUser(userId);
        }

        [Then(@"user is not found")]
        public void ThenUserIsNotFound()
        {
            _reqresApiService.VerifyResponseCode(HttpStatusCode.NotFound);
        }

        [Then(@"response body contains user with id (.*)")]
        public void ThenResponseBodyContainsUserWithId(int userId)
        {
            _reqresApiService
                .VerifyResponseCode(HttpStatusCode.OK)
                .VerifyResponseContainsUserId(userId);
        }

        [When(@"I send request to create a user with the following data")]
        public void WhenISendRequestToCreateAUserWithTheFollowingData(CreateUpdateUserBody userCreationBody)
        {
            _scenarioContext.Set(userCreationBody);
            _reqresApiService.CreateUser(userCreationBody);
        }

        [Then(@"user is created")]
        public void ThenUserIsCreated()
        {
            _reqresApiService
                .VerifyResponseCode(HttpStatusCode.Created)
                .VerifyResponseContainsUserInfo(_scenarioContext.Get<CreateUpdateUserBody>());
        }

        [Then(@"user is updated")]
        public void ThenUserIsUpdated()
        {
            _reqresApiService
                .VerifyResponseCode(HttpStatusCode.OK)
                .VerifyResponseContainsUserInfo(_scenarioContext.Get<CreateUpdateUserBody>());
        }

        [When(@"I send a request to update a user with id (.*) fully")]
        public void WhenISendARequestToUpdateAUserWithIdFully(int userId, CreateUpdateUserBody userUpdateBody)
        {
            _scenarioContext.Set(userUpdateBody);
            _reqresApiService.UpdateUser(userId, userUpdateBody, Method.Put);
        }

        [When(@"I send a request to update a user with id (.*) partially")]
        public void WhenISendARequestToUpdateAUserWithIdPartially(int userId, CreateUpdateUserBody userUpdateBody)
        {
            _scenarioContext.Set(userUpdateBody);
            _reqresApiService.UpdateUser(userId, userUpdateBody, Method.Patch);
        }

        [When(@"I send request to delete a user with id (.*)")]
        public void WhenISendRequestToDeleteAUserWithId(int userId)
        {
            _reqresApiService.DeleteUser(userId);
        }

        [Then(@"user is deleted")]
        public void ThenUserIsDeleted()
        {
            _reqresApiService.VerifyResponseCode(HttpStatusCode.NoContent);
        }

        [When(@"I send request to register with the following data")]
        public void WhenISendRequestToRegisterWithTheFollowingData(LoginRegistrationBody registrationBody)
        {
            _reqresApiService.Register(registrationBody);
        }

        [Then(@"user is registered")]
        [Then(@"user is logged in")]
        public void ThenUserIsRegisteredLoggedIn()
        {
            _reqresApiService.VerifyResponseCode(HttpStatusCode.OK);
        }

        [When(@"I send request to login with the following credentials")]
        public void WhenISendRequestToLoginWithTheFollowingCredentials(LoginRegistrationBody loginBody)
        {
            _reqresApiService.Login(loginBody);
        }

        [Given(@"delay equals (.*) seconds")]
        public void GivenDelayEqualsSeconds(int seconds)
        {
            _scenarioContext.Set(seconds);
        }

        [When(@"I send request to get list of users with delay")]
        public void WhenISendRequestToGetListOfUsersWithDelay()
        {
            _reqresApiService.GetListOfUsersWithDelay(_scenarioContext.Get<int>());
        }
    }
}
