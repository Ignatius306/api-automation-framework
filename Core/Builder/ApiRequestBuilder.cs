using System.Linq;
using System.Net.Http;
using System.Collections.Generic;

namespace api_automation_framework.Core.Builder
{
     public class ApiRequestBuilder
    {
        private readonly Dictionary<string, string> _headers;
        private readonly Dictionary<string, string> _queryParams;
        private string _body;

        /**
         * Initializes request builder.
         */
        public ApiRequestBuilder()
        {
            _headers = new Dictionary<string, string>();
            _queryParams = new Dictionary<string, string>();
            _body = string.Empty;
        }

        /**
         * Add header to request.
         *
         * @param key Header key
         * @param value Header value
         * @return ApiRequestBuilder
         */
        public ApiRequestBuilder AddHeader(string key, string value)
        {
            _headers[key] = value;
            return this;
        }

        /**
         * Add query parameter to request.
         *
         * @param key Query parameter key
         * @param value Query parameter value
         * @return ApiRequestBuilder
         */
        public ApiRequestBuilder AddQueryParam(string key, string value)
        {
            _queryParams[key] = value;
            return this;
        }

        /**
         * Add body to request.
         *
         * @param body Request body
         * @return ApiRequestBuilder
         */
        public ApiRequestBuilder AddBody(string body)
        {
            _body = body;
            return this;
        }

        /**
         * Build request.
         *
         * @return HttpRequestMessage
         */
        public HttpRequestMessage Build(string endpoint, HttpMethod method)
        {
            if (_queryParams.Count > 0)
            {
                var query = string.Join("&", _queryParams.Select(q => $"{q.Key}={q.Value}"));
                endpoint = $"{endpoint}?{query}";
            }
            var request = new HttpRequestMessage(method, endpoint);
            foreach (var header in _headers)
            {
                request.Headers.Add(header.Key, header.Value);
            }
            if(!string.IsNullOrEmpty(_body))
            {
                request.Content = new StringContent(_body, System.Text.Encoding.UTF8, "application/json");
            }
            return request;
        }
    }
}