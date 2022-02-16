using NUnit.Framework;
using RestSharp;
using System;
using TechTalk.SpecFlow;

namespace Experian.Steps
{
    [Binding]
    public class APITestsSteps
    {
        RestClient client;
        RestRequest request;

        [Given(@"existing Server application https://reqres\.in/api")]
        public void GivenExistingServerApplicationHttpsReqres_InApi()
        {
            client = new RestClient($"https://reqres.in/api");
        }
        
        
        [Then(@"on GET request /users it returns expected users list")]
        public void ThenOnGETRequestUsersItReturnsExpectedUsersList()
        {
            request = new RestRequest("users", Method.Get);
            var response = client.ExecuteGetAsync(request);

            Assert.True(response.Result.ResponseStatus == ResponseStatus.Completed);
        }
        
        [Then(@"on GET request to /users/(.*) it returns expected welcome message")]
        public void ThenOnGETRequestToUsersItReturnsExpectedWelcomeMessage(int p0)
        {
            request = new RestRequest($"users/{p0}", Method.Get);
            var response = client.GetAsync(request);

            Assert.True(response.Result.ResponseStatus == ResponseStatus.Completed);
        }
        
        [Then(@"on GET request to /users/(.*) it returns (.*) status code")]
        public void ThenOnGETRequestToUsersItReturnsStatusCode(int p0, int p1)
        {
            request = new RestRequest($"users/{p0}", Method.Get);
            var response = client.GetAsync(request);

            Assert.True(response.Result.ResponseStatus == ResponseStatus.Error);
        }
    }
}
