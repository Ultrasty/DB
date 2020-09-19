using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Health.Models;
using dbproj.connect;
using MySql.Data.MySqlClient;

namespace dbproj.Controllers
{
    [ApiController]
    [Route("api/13")]
    public class Controller13 : ControllerBase
    {
    
        [HttpGet("{sickleave_ID}")]
        public return13 Get(string sickleave_ID)
        {
            Connection conn=new Connection();
            MySqlConnection myConn= conn.GetConnection();
            string s=string.Format("select* from sick_leave where sickleave_ID='{0}'",sickleave_ID);
            MySqlCommand command=new MySqlCommand(s,myConn);
            MySqlDataReader reader = command.ExecuteReader();
            return13 result=new return13();
            reader.Read();
            result.student_ID=reader.GetString("student_ID");
            result.teacher_ID=reader.GetString("teacher_ID");
            
            result.allowedays=reader.GetInt16("allowed_time").ToString();       //
            result.approval_time=reader.GetDateTime("approval_time").ToShortDateString();
            result.terminate_time=reader.GetDateTime("terminate_time").ToShortDateString();
            result.reason=reader.GetString("reason");
            result.application_time=reader.GetDateTime("application_time").ToShortDateString();
            if(result.teacher_ID=="000")
            {
                result.allowedays="0";
                result.approval_time=result.approval_time+" 已驳回";
                result.terminate_time="无";
            }
            if(result.teacher_ID=="00000")
            {
                result.approval_time="待审批";
                result.terminate_time="暂无";
            }
            reader.Close();
            conn.Close();
            return result;
        }

    }
}