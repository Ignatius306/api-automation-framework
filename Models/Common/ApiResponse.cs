namespace api_automation_framework.Models.Common
{
    public class ApiResponse<T>
    {
        public T? Data { get; set; }
        public int StatusCode { get; set; }
        public string RawResponse { get; set; }
        public bool IsSuccess => StatusCode >= 200 && StatusCode < 300;
    }
}