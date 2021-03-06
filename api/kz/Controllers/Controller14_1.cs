using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Health.Models;
using dbproj.connect;
using MySql.Data.MySqlClient;

namespace dbproj.Controllers
{
    [ApiController]
    [Route("api/14/back")]
    public class Controller14_1 : ControllerBase
    {

         [HttpPost]
        public string Post(back Back)
        {
            Connection conn=new Connection();
            MySqlConnection myConn= conn.GetConnection();
            string getRecordId=string.Format("select count(*) from leaving_record where student_ID='{0}'",Back.student_ID);
            string health=string.Format("select count(*) from student where (student_ID='{0}' and (healthcode_color!='green' or currenthealth_status!=0))",Back.student_ID);
            MySqlCommand h=new MySqlCommand(health,myConn);
            MySqlDataReader heal=h.ExecuteReader();
            heal.Read();
            int y=heal.GetInt16(0);
            heal.Close();
            if(y!=0)
            return "fail,you have risk";
            MySqlCommand getIt=new MySqlCommand(getRecordId,myConn);
            MySqlDataReader reader=getIt.ExecuteReader();
            reader.Read();
            int x=reader.GetInt16(0);
            reader.Close();
            //string time=DateTime.Now.ToShortDateString();
            string updatesql=string.Format("update leaving_record set date_back='{0}',transport_back='{1}',back_num='{2}' where student_ID='{3}' and record_ID={4}",Back.date_back,Back.transport_back,Back.back_num,Back.student_ID,x.ToString());
            MySqlCommand excute=new MySqlCommand(updatesql,myConn);
            int i=excute.ExecuteNonQuery();
            conn.Close();
            if(i!=0)
                return "success";
            return "fail";
        }
    }
}