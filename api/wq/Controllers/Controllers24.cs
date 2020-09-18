using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System;
using MySql.Data.MySqlClient;

using System.IO;
using System.Net;
using Newtonsoft.Json;
using System.Text;
namespace database.Controllers
{
    [ApiController]
    [Route("api/24")] 
    public class Get24 : ControllerBase
    {
        [HttpGet("{index}")]
        public LinkedList<return24> getStu24(string index){
            
            CommonClass commonClass=new CommonClass();
            commonClass.open();
            //
            LinkedList<return24> result=new LinkedList<return24>();
            MySqlCommand command=new MySqlCommand("select student_ID,student_name,contact_way from student where student_ID not in (select student_ID from clockin_record where date='"+DateTime.Now.ToString("yyyy-MM-dd")+"')",commonClass.returnConn());
            MySqlDataReader dataReader=command.ExecuteReader();
            while(dataReader.Read()){
                return24 temp=new return24();
                temp.stu_id=dataReader.GetString("student_ID");
                temp.stu_name=dataReader.GetString("student_name");
                temp.contact_way=dataReader.GetString("contact_way");
                result.AddLast(temp);

            }
            commonClass.close();
            string url = "http://101.132.145.102:5000/api/sendmessage";
            input_24 t= new input_24();
            t.sender_id = index;
            foreach(var item in result)
            {
                t.receiver_id = item.stu_id;
                string ss = JsonConvert.SerializeObject(t);
                string s = Post(url, ss);
                if (s.Equals("success"))
                {
                    item.message = "已发送消息";
                }
                else
                {
                    item.message = "发送消息失败";
                }
            }
          
            return result;


        }

        public static string Post(string url, string postData)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "application/json";
            request.Method = "POST";
            request.Timeout = 100000;

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