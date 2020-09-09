using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System;
using MySql.Data.MySqlClient;

namespace database.Controllers
{
    [ApiController]
    [Route("24")] 
    public class get24 : ControllerBase
    {
        [HttpGet]
        public LinkedList<return24> getStu24(){
            
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
            return result;


        }

    }
    
    
}