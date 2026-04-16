using NUnit.Framework;
using api_automation_framework.Core.Client;
using System.Net;
using api_automation_framework.Core.Settings;
using Newtonsoft.Json;
using api_automation_framework.Models;
using api_automation_framework.Utilities.Assertions;
using System.Net.Http;
using System.Threading.Tasks;

namespace api_automation_framework.Tests
{
    [TestFixture]
    public class GetUserTest
    {
        private ApiClient _apiClient;

        [SetUp]
        public void Setup()
        {
            _apiClient = new ApiClient();
        }

        [Test]
        public async Task GetUser_ValidId_ReturnsSuccessStatusCode()
        {

            // Act
            var request = new HttpRequestMessage(HttpMethod.Get, "users/1");

            var response = await _apiClient.SendAsync<UserData>(request);

            ApiAssertions.AssertStatusCode(response, 200);
            ApiAssertions.AssertSuccess(response);
            ApiAssertions.AssertNotNull(response);

            Assert.AreEqual(1, response.Data?.id);
        }
    }
}