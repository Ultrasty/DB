using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Health.Models;
using dbproj.connect;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;

namespace dbproj.Controllers
{
    [ApiController]
    [Route("api/12/apply")]
    public class Controller12 : ControllerBase
    {

         [HttpPost]
        public string Post(application12_s application12)
        {
            Connection conn=new Connection();
            MySqlConnection myConn= conn.GetConnection();
            string getNum="select count(sickleave_ID) from sick_leave";
            int num=0;
            MySqlCommand command=new MySqlCommand(getNum,myConn);
            MySqlDataReader reader = command.ExecuteReader();
            try
            {
                reader.Read();
                num=reader.GetInt16(0)+1;
                reader.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
            //string time=DateTime.Now.ToShortDateString();
            string s=string.Format("insert into sick_leave values({0},{1},'00000','{2}','2020-01-01',0,'2020-01-01',\"{3}\")",num.ToString(),application12.student_ID,application12.application_time,application12.reason);
            Console.WriteLine("\n"+s+"\n");
            int i=0;
            MySqlCommand command1=new MySqlCommand(s,myConn);  
            try
            {
                i=command1.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
            
            conn.Close();
            string url = "http://101.132.145.102:5000/api/sendmessage";
            string ss="";
            string sss="";
            string tid="";
            if(i!=0)
                {
                    
                    Message t= new Message();
                    t.sender_id = "00000";
                    t.content="你有病假申请待处理";
                    tid="1";
                    t.receiver_id=tid;
                    ss = JsonConvert.SerializeObject(t);
                    sss = Controller12_1.Post1(url, ss);
                    tid="2";
                    t.receiver_id=tid;
                    ss = JsonConvert.SerializeObject(t);
                    sss = Controller12_1.Post1(url, ss);
                     tid="3";
                    t.receiver_id=tid;
                    ss = JsonConvert.SerializeObject(t);
                    sss = Controller12_1.Post1(url, ss);
                     tid="4";
                    t.receiver_id=tid;
                    ss = JsonConvert.SerializeObject(t);
                    sss = Controller12_1.Post1(url, ss);
                     tid="5";
                    t.receiver_id=tid;
                    ss = JsonConvert.SerializeObject(t);
                    sss = Controller12_1.Post1(url, ss);
                     tid="6";
                    t.receiver_id=tid;
                    ss = JsonConvert.SerializeObject(t);
                    sss = Controller12_1.Post1(url, ss);
                     tid="7";
                    t.receiver_id=tid;
                    ss = JsonConvert.SerializeObject(t);
                    sss = Controller12_1.Post1(url, ss);
                    tid="55555";
                    t.receiver_id=tid;
                    ss = JsonConvert.SerializeObject(t);
                    sss = Controller12_1.Post1(url, ss);
                    return "success";
                }
            return "fail";
        }
    
        [HttpGet("{department}")]
        public application12_t[] Get(string department)
        {
            Connection conn=new Connection();
            MySqlConnection myConn= conn.GetConnection();
            string s=string.Format("select * from (student natural join sick_leave)  where department=\"{0}\" and teacher_ID='00000'",department);
            MySqlCommand command=new MySqlCommand(s,myConn);
            MySqlDataReader reader = command.ExecuteReader();
            return12 arr=new return12();
            int i=0;
            while(reader.Read())
                {
                    application12_t result=new application12_t();
                    result.student_ID=reader.GetString("student_ID");
                    result.sickleave_ID=reader.GetInt16("sickleave_ID").ToString();  //
                    result.teacher_ID=reader.GetString("teacher_ID");
                    result.allowedays=reader.GetInt16("allowed_time").ToString();   //
                    result.approval_time=reader.GetDateTime("approval_time").ToShortDateString();
                    result.terminate_time=reader.GetDateTime("terminate_time").ToShortDateString();
                    result.reason=reader.GetString("reason");
                    result.application_time=reader.GetDateTime("application_time").ToShortDateString();
                    arr.applications[i]=result;
                    i++;
                }
            reader.Close();
            conn.Close();
            return arr.applications;
        }

    }
}