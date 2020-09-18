using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Health.Models;
using dbproj.connect;
using MySql.Data.MySqlClient;

namespace dbproj.Controllers
{
    [ApiController]
    [Route("api/12/end")]
    public class Controller12_2 : ControllerBase
    {
         [HttpPost]
        public string Post(end End)
        {
            Connection conn=new Connection();
            MySqlConnection myConn= conn.GetConnection();
             string time=DateTime.Now.ToShortDateString();
            string s=string.Format("update sick_leave set terminate_time='{0}' where sickleave_ID='{1}'",time,End.sickleave_ID);
            MySqlCommand command=new MySqlCommand(s,myConn);
            int i=command.ExecuteNonQuery();
            conn.Close();
            if(i!=0)
                return "success";
            return "fail";
            
        }
    }
}