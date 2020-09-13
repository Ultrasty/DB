using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

using MySql.Data.MySqlClient;
namespace database.Controllers
{
    [ApiController]
    [Route("api/22")] 
    public class Get22 : ControllerBase
    {
        [HttpPost]
        public LinkedList<return22> getStu22([FromBody]string trip_num){    
            LinkedList<return22> result=new LinkedList<return22>();
            CommonClass commonClass=new CommonClass();
            commonClass.open();    
            MySqlCommand cmd1 = new MySqlCommand("select student_ID,student_name,trip_num,date from back_info natural join student where trip_num='"+trip_num+"'", commonClass.returnConn());
            MySqlDataReader dataReader1 = cmd1.ExecuteReader();
            while(dataReader1.Read()){
                return22 temp=new return22();
                temp.stu_id=dataReader1.GetString("student_ID");
               temp.stu_name=dataReader1.GetString("student_name");
                temp.trip_num=dataReader1.GetString("trip_num");
                temp.date=dataReader1.GetString("date");
                result.AddLast(temp);
            } 
            commonClass.close();
            commonClass.open();
            MySqlCommand cmd2 = new MySqlCommand("select student_ID,student_name,trip_num,date from leaving_record natural join student where trip_num='"+trip_num+"'", commonClass.returnConn());
            MySqlDataReader dataReader2 = cmd2.ExecuteReader();
            while(dataReader2.Read()){
                return22 temp=new return22();
                temp.stu_id=dataReader2.GetString("student_ID");
                temp.stu_name=dataReader2.GetString("student_name");
                temp.trip_num=dataReader2.GetString("trip_num");
                temp.date=dataReader2.GetString("date");
                result.AddLast(temp);
            }
           commonClass.close();
            return result;
        }
    }
}