using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentHealthDB.Models
{
    public class TeacherAddRequest
    {
        public string id { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public string department { get; set; }
        public string title { get; set; }
        public string telephone { get; set; }
    }
    public class TeacherAddResponse
    {
        public string result { get; set; }
    }
}
