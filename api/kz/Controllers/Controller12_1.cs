using Microsoft.AspNetCore.Mvc;
using System;
using MySql.Data.MySqlClient;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using System.Text;
using Health.Models;
using dbproj.connect;

namespace dbproj.Controllers
{
    [ApiController]
    [Route("api/12/agree")]
    public class Controller12_1 : ControllerBase
    {

         [HttpPost]
        public string Post([FromBody] agree agreement)
        {
            Connection conn=new Connection();
            MySqlConnection myConn= conn.GetConnection();
            string s="";
            int _ok=0;
            //string time=DateTime.Now.ToShortDateString();
            if(agreement.teacher_ID=="00000")
            s=string.Format("update sick_leave set teacher_ID='000' where sickleave_ID={0}",agreement.sickleave_ID);
            else
            {
                s=string.Format("update sick_leave set approval_time='{0}',teacher_ID='{1}',allowed_time={2} where sickleave_ID={3}",agreement.approval_time,agreement.teacher_ID,agreement.allowedays.ToString(),agreement.sickleave_ID);
                _ok=1;
            }
            MySqlCommand command=new MySqlCommand(s,myConn);
            int i=command.ExecuteNonQuery();
            string sql=string.Format("select student_ID from sick_leave where sickleave_ID={0}",agreement.sickleave_ID);
            MySqlCommand command1=new MySqlCommand(sql,myConn);
            MySqlDataReader reader= command1.ExecuteReader();
            reader.Read();
            string sid=reader.GetString(0);
            Console.WriteLine("\n"+sid+"\n");
            reader.Close();
            conn.Close();
            string url = "http://101.132.145.102:5000/api/sendmessage";
            string ss="";
            string sss="";
            Message t= new Message();
            if(i!=0)
                {
                    t.sender_id = "00000";
                    t.receiver_id=sid;
                    if(_ok==1)
                        t.content="你的病假申请已批准";
                    else
                        t.content="你的病假申请被驳回";
                    ss = JsonConvert.SerializeObject(t);
                    sss = Post1(url, ss);
                    return "success";
                }
                
            return "fail";
        }

         public static string Post1(string url, string postData)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "application/json";
            request.Method = "POST";
            request.Timeout = 10000000;

            byte[] bytes = Encoding.UTF8.GetBytes(postData);
            request.ContentLength = bytes.Length;
            Stream writer = request.GetRequestStream();
            writer.Write(bytes, 0, bytes.Length);
            writer.Close();

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream() ?? throw new InvalidOperationException(), Encoding.UTF8);
            string result = reader.ReadToEnd();
            response.Close();
            return result;
        }
    }
}