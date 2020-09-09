using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
namespace database.Controllers
{
    [ApiController]
    [Route("api/21")] 
    public class get21 : ControllerBase
    {
        [HttpPost]
        public LinkedList<return21> getStuQua([FromBody]string index){
            LinkedList<return21>result=new LinkedList<return21>();
            CommonClass commonClass=new CommonClass();
            commonClass.open();    
            MySqlCommand cmd = new MySqlCommand("select * from quarantine_record where student_id="+index, commonClass.returnConn());
            MySqlDataReader dataReader = cmd.ExecuteReader();
            while(dataReader.Read()){
                return21 temp=new return21();
                temp.stu_id=dataReader.GetString("student_ID");
                temp.quan_id=dataReader.GetString("quarantine_ID");
                temp.start_day=dataReader.GetString("start_day");
                temp.end_day=dataReader.GetString("end_day");
                temp.place=dataReader.GetString("quarantine_place");
                result.AddLast(temp);
            }
            commonClass.close();
            return result;

        }


    } 
}