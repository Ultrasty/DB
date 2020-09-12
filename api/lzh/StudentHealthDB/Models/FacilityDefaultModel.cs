using System.Collections.Generic;

namespace StudentHealthDB.Models
{
    public class FacilityDefaultRequest
    {
        public string id { get; set; }
    }
    public class FacilityDefaultResponse
    {
        public string result { get; set; }
        public List<record> detail {get; set;}
    }
    public class record
    {
        public string name { get; set; }
        public string date { get; set; }
    }
}
