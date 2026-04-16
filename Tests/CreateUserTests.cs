using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NUnit.Framework;
using api_automation_framework.Core.Client;
using api_automation_framework.Models;

namespace api_automation_framework.Tests
{
    [TestFixture]
    public class CreateUserTests
    {
        private ApiClient _apiClient;

        [SetUp]
        public void Setup()
        {
            _apiClient = new ApiClient();
        }

        [Test]
        public async Task CreateUser_ValidData_ReturnsSuccessStatusCode()
        {
            // Arrange
            var user = new User
            {
                name = "John Doe",
                job = "Developer"
            };

            var request = new HttpRequestMessage(HttpMethod.Post, "users")
            {
                Content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json")
            };

            // Act
            var response = await _apiClient.SendAsync(request);
            var content = await response.Content.ReadAsStringAsync();
            TestContext.WriteLine(content);

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
        }
    }
}