using System.Collections.Generic;

namespace StudentHealthDB.Models
{
    public class FacilityStudentRequest
    {
        public string facility { get; set; }
        public string date { get; set; }
        public int? starttime { get; set; }
        public int? endtime { get; set; }
    }
    public class FacilityStudentResponse
    {
        public string result { get; set; }
        public List<StudentInfo> student{ get; set;}
    }
    public class StudentInfo
    {
        public string id { get; set; }
        public string name { get; set; }
        public string department { get; set; }
    }
}
