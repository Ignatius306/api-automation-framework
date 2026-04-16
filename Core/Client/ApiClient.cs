using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using api_automation_framework.Core.Settings;
using Newtonsoft.Json;
using api_automation_framework.Models.Common;

namespace api_automation_framework.Core.Client
{
    public class ApiClient
    {
        private readonly HttpClient _httpClient;
        /**
         * Initializes API client.
         */
        public ApiClient()
        {
            var baseUrl = ConfigManager.GetBaseUrl() ?? string.Empty;
            if (!baseUrl.EndsWith("/")) baseUrl += "/";
            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri(baseUrl)
            };
        }

        /**
         * Sends a GET request to the specified endpoint.
         *
         * @param endpoint API endpoint
         * @return HttpResponseMessage
         */
        public async Task<HttpResponseMessage> GetAsync(string endpoint)
        {
            return await _httpClient.GetAsync(endpoint);
        }

        /**
         * Sends a POST request with JSON body.
         *
         * @param endpoint API endpoint
         * @param body Request payload
         * @return HttpResponseMessage
         */
        public async Task<HttpResponseMessage> PostAsync(string endpoint, string body)
        {
            var content = new StringContent(body, Encoding.UTF8, "application/json");
            return await _httpClient.PostAsync(endpoint, content);
        }

        /**
         * Sends a PUT request with JSON body.
         *
         * @param endpoint API endpoint
         * @param body Request payload
         * @return HttpResponseMessage
         */
        public async Task<HttpResponseMessage> PutAsync(string endpoint, string body)
        {
            var content = new StringContent(body, Encoding.UTF8, "application/json");
            return await _httpClient.PutAsync(endpoint, content);
        }

        /**
         * Sends a DELETE request to the specified endpoint.
         *
         * @param endpoint API endpoint
         * @return HttpResponseMessage
         */
        public async Task<HttpResponseMessage> DeleteAsync(string endpoint)
        {
            return await _httpClient.DeleteAsync(endpoint);
        }

        /**
         * Sends a request to the specified endpoint.
         *
         * @param request HttpRequestMessage
         * @return HttpResponseMessage
         */
        public async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request)
        {
            return await _httpClient.SendAsync(request);
        }

        /**
         * Sends a request to the specified endpoint and deserializes the response.
         *
         * @param request HttpRequestMessage
         * @return ApiResponse<T>
         */
        public async Task<ApiResponse<T>> SendAsync<T>(HttpRequestMessage request)
        {
            var response = await _httpClient.SendAsync(request);
            var content = await response.Content.ReadAsStringAsync();
            return new ApiResponse<T>
            {
                Data = JsonConvert.DeserializeObject<T>(content),
                StatusCode = (int)response.StatusCode,
                RawResponse = content
            };
        }
    }
}