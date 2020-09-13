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
    [Route("api/20")] 
    public class Get20 : ControllerBase
    {
        [HttpPost]
        public LinkedList<return20> getStuQua([FromBody]string date){
            LinkedList<return20>result=new LinkedList<return20>();
            CommonClass commonClass=new CommonClass();
            commonClass.open();    
            MySqlCommand cmd = new MySqlCommand("select  student_ID,student_name,healthcode_color,currenthealth_status,current_province,current_city,date "+
                                            "from clockin_record natural join student "+
                                            "where date='"+date+"' and (current_province,current_city) in "+
                                                                "(select province,city from pandemic_situation where date='"+
                                                                              date+"' and risk_level > 0)", commonClass.returnConn());
            MySqlDataReader dataReader = cmd.ExecuteReader();
          //
            while(dataReader.Read()){
                return20 temp=new return20();
                temp.student_ID=dataReader.GetString("student_ID");
                temp.student_name=dataReader.GetString("student_name");
                temp.healthcode_color=dataReader.GetString("healthcode_color");
                temp.currenthealth_status=dataReader.GetString("currenthealth_status");
                temp.province=dataReader.GetString("current_province");
                temp.city=dataReader.GetString("current_city");
               // temp.risk_level=dataReader.GetInt32("risk_level");
                temp.date=Convert.ToDateTime(dataReader.GetString("date"));
                result.AddLast(temp);
            }
            commonClass.close();
            foreach (var item in result)
            {
                commonClass.open();
                 MySqlCommand tempcmd = new MySqlCommand("select risk_level from pandemic_situation "+
                                        "where date='"+date+"' and province='"+item.province+"' and city='"+item.city+"'",commonClass .returnConn());
                MySqlDataReader tempread=tempcmd.ExecuteReader();
                tempread.Read();
                item.risk_level=tempread.GetInt32("risk_level");
                commonClass.close();
            }



            return result;

        }


    } 
}