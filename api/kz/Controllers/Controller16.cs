using System;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Health.Models;
using dbproj.connect;
using MySql.Data.MySqlClient;

namespace dbproj.Controllers
{
    [ApiController]
    [Route("api/16")]
    public class Controller16 : ControllerBase
    {

        [HttpPost]
        public string Post(return16 trace)
        {
            Connection conn=new Connection();
            MySqlConnection myConn= conn.GetConnection();
            string s=string.Format("insert into clockin_record values(\"{0}\",date_format(\"{1}\",\"%Y-%m-%d\"),{2},\"{3}\",\"{4}\")",trace.s_id,trace.date,trace.health_situation,trace.current_province,trace.current_city);
            Console.WriteLine("\n"+s+"\n");
            MySqlCommand command=new MySqlCommand(s,myConn);  
            string sql=string.Format("select current_province from clockin_record where student_ID=\"{0}\" order by date desc limit 1",trace.s_id);
            MySqlCommand command1=new MySqlCommand(sql,myConn);
            MySqlDataReader reader1 = command1.ExecuteReader();
            string beforeLocation="null";
            string insertTrace=string.Format("insert into outprovince values(\"{0}\",date_format(\"{1}\",\"%Y-%m-%d\"),'{2}')",trace.s_id,trace.date,trace.current_province);
            try
            {
                reader1.Read();
                beforeLocation=reader1.GetString("current_province");
                reader1.Close();
                if(beforeLocation!=trace.current_province)
                {
                    MySqlCommand command2=new MySqlCommand(insertTrace,myConn);
                    command2.ExecuteNonQuery();
                }

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
            int success=0;
            try
            {
                success=command.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
            
            conn.Close();
            if(success!=0)
                return "打卡成功";
            return "打卡失败";
        }
    }
}
