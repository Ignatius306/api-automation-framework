namespace api_automation_framework.Models
{
    public class UserData
    {
        public int id { get; set; }
        public string email { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
    }

    public class UserResponse
    {
        public UserData? Data { get; set; }
    }

    public class User
    {
        public string? name { get; set; }
        public string? job { get; set; }
    }
}