using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Health.Models;
using dbproj.connect;
using MySql.Data.MySqlClient;

namespace dbproj.Controllers
{
    [ApiController]
    [Route("api/15/getRecord")]
    public class Controller15_1 : ControllerBase
    {

         [HttpGet("{s_id}")]
        public return14[] Post(string s_id)
        {
            Connection conn=new Connection();
            MySqlConnection myConn= conn.GetConnection();
            string s=string.Format("select * from leaving_record where student_ID='{0}'",s_id);
            MySqlCommand command=new MySqlCommand(s,myConn);
            MySqlDataReader reader= command.ExecuteReader();
            int i=0;
            return15 result=new return15();
            while(reader.Read())
            {
                result.arr[i]=new return14();
                result.arr[i].date=reader.GetDateTime("date").ToShortDateString();
                result.arr[i].date_back=reader.GetDateTime("date_back").ToShortDateString();
                result.arr[i].destination=reader.GetString("destination");
                result.arr[i].record_ID=reader.GetInt16("record_ID").ToString(); //
                result.arr[i].student_ID=reader.GetString("student_ID");
                result.arr[i].transport=reader.GetString("transport");
                result.arr[i].trip_num=reader.GetString("trip_num");
                result.arr[i].back_num=reader.GetString("back_num");
                i++;

            }
            reader.Close();
            conn.Close();
            return result.arr;
        }
    }
}