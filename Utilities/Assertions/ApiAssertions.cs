using NUnit.Framework;
using api_automation_framework.Models.Common;

namespace api_automation_framework.Utilities.Assertions
{
    public static class ApiAssertions
    {
        /**
         * Validates HTTP status code.
         */
        public static void AssertStatusCode<T>(ApiResponse<T> response, int expectedStatusCode)
        {
            Assert.AreEqual(expectedStatusCode, response.StatusCode,
                $"Expected status code {expectedStatusCode} but got {response.StatusCode}");
        }

        /**
         * Validates response success.
         */
        public static void AssertSuccess<T>(ApiResponse<T> response)
        {
            Assert.IsTrue(response.IsSuccess,
                $"Request failed with status code {response.StatusCode} and response {response.RawResponse}");
        }

        /**
         * Validates response body is not null.
         */
        public static void AssertNotNull<T>(ApiResponse<T> response)
        {
            Assert.IsNotNull(response.Data, "Response data is null");
        }
    }
}