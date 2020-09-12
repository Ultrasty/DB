namespace StudentHealthDB.Models
{
    public class FacilityAlterRequest
    {
        public string facility { get; set; }
        public string name { get; set; }
        public int? startdate { get; set; }
        public int? enddate { get; set; }
        public int? starttime { get; set; }
        public int? endtime { get; set; }
        public int? capacity { get; set; }
    }
    public class FacilityAlterResponse
    {
        public string result { get; set; }
    }
}

