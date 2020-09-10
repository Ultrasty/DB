namespace StudentHealthDB.Models
{
    public class LoginRequest
    {
        public string id { get; set; }
        public string password { get; set; }

    }
    public class LoginResponse
    {
        public string result { get; set; }
    }

}