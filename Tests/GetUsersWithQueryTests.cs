using NUnit.Framework;
using api_automation_framework.Core.Client;
using System.Net;
using api_automation_framework.Core.Settings;
using Newtonsoft.Json;
using api_automation_framework.Models;
using api_automation_framework.Core.Builder;

namespace api_automation_framework.Tests
{
    [TestFixture]
    public class GetUsersWithQueryTests
    {
        private ApiClient _apiClient;

        [SetUp]
        public void Setup()
        {
            _apiClient = new ApiClient();
        }

        [Test]
        public async Task GetUsersWithQuery_ValidQuery_ReturnsSuccessStatusCode()
        {
            // Arrange
           var builder = new ApiRequestBuilder()
                .AddQueryParam("page", "2");

            var request = builder.Build("users", HttpMethod.Get);

            // Act
            var response = await _apiClient.SendAsync(request);

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
    }
}