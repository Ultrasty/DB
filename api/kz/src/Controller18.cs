using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Health.Models;
using dbproj.connect;
using MySql.Data.MySqlClient;

namespace dbproj.Controllers
{
    [ApiController]
    [Route("api/18")]
    public class Controller18 : ControllerBase
    {

        // GET api/values/id
        //返回申请过病假或目前状态不健康的学生
        [HttpGet("{id}")]
        public status[] Get(string id)
        {
            Connection conn=new Connection();
            return18 result=new return18();
            MySqlConnection myConn= conn.GetConnection();
            string t=string.Format("select student.student_ID,healthcode_color,currenthealth_status,sickleave_ID,terminate_time from student left join sick_leave on student.student_ID=sick_leave.student_ID where (currenthealth_status!=0 or !isnull(sickleave_ID)) and student.student_ID='{0}'",id);
            string s=string.Format("select student.student_ID,healthcode_color,currenthealth_status,sickleave_ID,terminate_time from student left join sick_leave on student.student_ID=sick_leave.student_ID where currenthealth_status!=0 or !isnull(sickleave_ID)");
            if(id=="*")
                t=s;
            MySqlCommand command=new MySqlCommand(t,myConn);
            MySqlDataReader reader = command.ExecuteReader();
            int i=0;
            while(reader.Read())
            {
                status temp=new status();
                temp.healthcode_color=reader.GetString("healthcode_color");
                temp.currenthealth_status=reader.GetInt16("currenthealth_status");
                temp.student_ID=reader.GetString("student_ID");
                if(!reader.IsDBNull(4))
                    temp.terminate_time=reader.GetDateTime("terminate_time").ToShortDateString();
                else
                    temp.terminate_time="null";
                if(!reader.IsDBNull(3))
                temp.sickleave_ID=reader.GetInt16("sickleave_ID");
                //-1表示无病假历史
                else
                temp.sickleave_ID=-1;
                result.unhealths[i]=temp;
                i++;
            }
            reader.Close();
            
            conn.Close();
            return result.unhealths;
        }

    }
}
