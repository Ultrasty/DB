namespace StudentHealthDB.Models
{
    public class StudentCheckRequest
    {
        public string id { get; set; }
    }
    public class StudentCheckResponse
    {
        public string result { get; set; }
        public string name { get; set; }
        public string gender { get; set; }
        public string department { get; set; }
        public string grade { get; set; }
        public string classnum { get; set; }
        public string dorm { get; set; }
        public string healthcodecolor { get; set; }
        public string telephone { get; set; }
        public string emergencyphone { get; set; }
        public string healthstatus { get; set; }

    }
}
