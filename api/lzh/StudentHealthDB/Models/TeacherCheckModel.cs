namespace StudentHealthDB.Models
{
    public class TeacherCheckRequest
    {
        public string id { get; set; }
    }
    public class TeacherCheckResponse
    {
        public string result { get; set; }
        public string name { get; set; }
        public string department { get; set; }
        public string title { get; set; }
        public string telephone { get; set; }
    }
}
