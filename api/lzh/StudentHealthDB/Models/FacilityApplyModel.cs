using System;

namespace StudentHealthDB.Models
{
    public class FacilityApplyRequest
    {
        public string id { get; set; }
        public string facility { get; set; }
        public DateTime date { get; set; }
        public int starttime { get; set; }
        public int endtime { get; set; }

    }
    public class FacilityApplyResponse
    {
        public string result { get; set; }
    }
    public class FacilityInfo
    {
        public int start { get; set; }
        public int end { get; set; }
        public int capacity { get; set; }
        public int startday { get; set; }
        public int endday { get; set; }
    }
}
