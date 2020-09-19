using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Health.Models;
using dbproj.connect;
using MySql.Data.MySqlClient;

namespace dbproj.Controllers
{
    [ApiController]
    [Route("api/14/leave")]
    public class Controller14 : ControllerBase
    {

         [HttpPost]
        public string Post(leave Leave)
        {
            Connection conn=new Connection();
            MySqlConnection myConn= conn.GetConnection();
            string query=string.Format("select count(student_ID) from leaving_record where student_ID='{0}'",Leave.student_ID);
            string health=string.Format("select count(*) from student where (student_ID='{0}' and (healthcode_color!='green' or currenthealth_status!=0))",Leave.student_ID);
            MySqlCommand h=new MySqlCommand(health,myConn);
            MySqlDataReader heal=h.ExecuteReader();
            heal.Read();
            int y=heal.GetInt16(0);
            heal.Close();
            if(y!=0)
            return "fail,you have risk";
            MySqlCommand queryNum=new MySqlCommand(query,myConn);
            MySqlDataReader reader1 = queryNum.ExecuteReader();
            int num=0;
            try
            {
                reader1.Read();
                num=reader1.GetInt16(0)+1;
                reader1.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
             //string time=DateTime.Now.ToShortDateString();
            string s=string.Format("insert into leaving_record values('{0}',{1},'{2}','{3}','{4}','{5}','{6}','{7}','{8}')",Leave.student_ID,num.ToString(),Leave.destination,Leave.date,Leave.transport,Leave.trip_num,"9999-12-31","未知","0000");
            MySqlCommand command=new MySqlCommand(s,myConn);
            int i=command.ExecuteNonQuery();
            conn.Close();
            if(i!=0)
                return num.ToString();
            return "fail";        
        }
    }
}