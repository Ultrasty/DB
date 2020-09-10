namespace StudentHealthDB.Models
{
    public class DepartmentCheckRequest
    {
        public string id { get; set; }
    }
    public class DepartmentCheckResponse
    {
        public string result { get; set; }
        public string department { get; set; }
        public string building { get; set; }
        public string name { get; set; }
        public string phonenumber { get; set; }

    }
}
