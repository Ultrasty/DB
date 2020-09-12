using System.Collections.Generic;

namespace StudentHealthDB.Models
{
    public class FacilityCheckRequest
    {
        public string facility { get; set; }
        public string date { get; set; }
    }
    public class FacilityCheckResponse
    {
        public string result { get; set; }
        public string name { get; set; }
        public int startdate { get; set; }
        public int enddate { get; set; }
        public int starttime { get; set; }
        public int endtime { get; set; }
        public int capacity { get; set; }
        public List<period> periodleft { get; set; }
    }
    public class period
    {
        public int start { get; set; }
        public int left { get; set; }
    }
}
