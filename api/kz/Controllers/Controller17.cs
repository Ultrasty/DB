using System;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Health.Models;
using dbproj.connect;
using MySql.Data.MySqlClient;

namespace dbproj.Controllers
{
    [ApiController]
    [Route("api/17")]
    public class Controller17 : ControllerBase
    {

        // GET api/values/id
        [HttpGet("{date}")]
        public outStudent[] GET(string date)
        {
            Connection conn=new Connection();
            MySqlConnection myConn= conn.GetConnection();
            string sql=string.Format("select student_ID,nowProvince from outprovince where outDate='{0}'",date);
            MySqlCommand command1=new MySqlCommand(sql,myConn);
            MySqlDataReader reader1 = command1.ExecuteReader();
            int i=0;
            return17 list=new return17();
            while(reader1.Read())
            {
                outStudent result=new outStudent();
                list.outStudents[0]=result;
                result.s_id=reader1.GetString("student_ID");
                result.outProvince=reader1.GetString("nowProvince");
                i++;
            }
            
            conn.Close();
            return list.outStudents;
        }
    }
}