using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System;
using MySql.Data.MySqlClient;

namespace database.Controllers
{
    [ApiController]
    [Route("23")] 
    public class get23 : ControllerBase
    {
        [HttpPost]
        public LinkedList<return23> getStuTimes23([FromBody]DateTime date){
            LinkedList<return23> result=new LinkedList<return23>();
            CommonClass commonClass=new CommonClass();
            commonClass.open();
            if(date==null){
                date=DateTime.Now;
            }
            MySqlCommand cmd =new MySqlCommand("select student_ID,student_name from student ",commonClass .returnConn());
            MySqlDataReader dataReader=cmd.ExecuteReader();
            while(dataReader.Read()){
                return23 temp=new return23();
                temp.stu_id=dataReader.GetString("student_ID");
                temp.stu_name=dataReader.GetString("student_name");
                result.AddLast(temp);
            }
            commonClass .close();
           
            foreach (var item in result)
            { commonClass .open();
                 MySqlCommand tempcmd =new MySqlCommand("select student_ID,date,current_province,current_city from clockin_record where student_ID= '"+item.stu_id+"' ",commonClass .returnConn());
                 MySqlDataReader tempdataReader=tempcmd.ExecuteReader();
                LinkedList<clockin> tempresult=new LinkedList<clockin>();
                while(tempdataReader.Read()){
                    clockin tempclo=new clockin();
                    tempclo.stu_id=tempdataReader.GetString("student_ID");
                    tempclo.date=tempdataReader.GetString("date");
                    tempclo.place_pro=tempdataReader.GetString("current_province");
                    tempclo.place_city=tempdataReader.GetString("current_city");
                    tempresult.AddLast(tempclo);
                }
                string objpro="";string objcity="";
                foreach (var tempitem in tempresult)
                {
                    if(Convert.ToDateTime(tempitem.date)==date){
                       objpro=tempitem.place_pro;
                       objcity=tempitem.place_city;
                       break;
                    }
                }
                int count=0;
                foreach (var tempitem in tempresult)
                {
                    if(Convert.ToDateTime(tempitem.date)<=date){
                        if(tempitem.place_pro==objpro){
                            if(tempitem.place_city==objcity){
                                count++;
                            }
                        }
                    }
                }
                item.times=count;
                item.place_pro=objpro;
                item.place_city=objcity;
                 commonClass .close();
            }


           
            return result;
        }
    }
    
}

/*"select student_ID ,count(*) as times,current_city,current_province "+
                                                "from clockin_record as A "+
                                                "group by student_ID "+
                                                "where (A.current_province,A.current_city) = (select current_province,current_city from clockin_record as B "+
                                                                        "where A.student_ID=B.student_ID and B.date='"+
                                                                            date+"')"
                                                                            
                                                                            
temp.times=dataReader.GetInt32("times");
                temp.place_pro=dataReader.GetString("province");
                temp.place_city=dataReader.GetString("city");
                                                                            
                                                                            
                                                                            */