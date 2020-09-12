namespace StudentHealthDB.Models
{
    public class FacilitySignRequest
    {
        public string id { get; set; }
        public string facility { get; set; }
        public int inout { get; set; }
    }
    public class FacilitySignResponse
    {
        public string result { get; set; }
    }
}
