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
    [Route("api/19")] 
    public class Get19 : ControllerBase
    {
        [HttpGet]
        public LinkedList<return19> setStuBatch(){
            LinkedList<return19>result=new LinkedList<return19>();
            CommonClass commonClass=new CommonClass();
            commonClass.open();  
            String date=DateTime.Now.ToShortDateString(); 
     //       date="2020-09-20";          //交代码要去掉这一行
            MySqlCommand cmd = new MySqlCommand("select  student_ID,student_name,date "+
                                            "from clockin_record natural join student "+
                                            "where date='"+date+"' and (current_province,current_city) in "+
                                                                "(select province,city from pandemic_situation where date='"+
                                                                              date+"' and risk_level = 0)", commonClass.returnConn());
            MySqlDataReader dataReader = cmd.ExecuteReader();
            
            
            while(dataReader.Read()){
                return19 temp=new return19();
                temp.student_ID=dataReader.GetString("student_ID");
                temp.student_name=dataReader.GetString("student_name");                         
                result.AddLast(temp);
            }
            commonClass.close();
            

            LinkedListNode<return19> po=result.First;
            while(po!=result.Last){
                commonClass.open();
                MySqlCommand tempcmd19=new MySqlCommand("select student_ID from back_info where student_ID='"+po.Value.student_ID+"'",commonClass .returnConn());
                MySqlDataReader tempread19=tempcmd19.ExecuteReader();
                if(tempread19.Read()){
                    LinkedListNode<return19> pre=po;
                    po=po.Next;
                    result.Remove(pre);
                }else{
                    po=po.Next;
                }
                commonClass.close();
            }
            
            if (po == null)
            {
                ;
            }
            else
            {
                commonClass.open();
                MySqlCommand tempcmd=new MySqlCommand("select student_ID from back_info where student_ID='"+po.Value.student_ID+"'",commonClass .returnConn());
                MySqlDataReader tempread=tempcmd.ExecuteReader();
                if(tempread.Read()){
                    result.Remove(po);
                }
                commonClass.close();
            }
           
           

             commonClass.open();
            //得到返校批次信息；
            MySqlCommand getbatch=new MySqlCommand("select * from batch",commonClass .returnConn());
            MySqlDataReader getbatchread=getbatch.ExecuteReader();
            LinkedList<batch> batches=new LinkedList<batch>();
            while(getbatchread.Read()){
                batch temp=new batch();
                temp.batch_num=getbatchread.GetString("batch_num");
                temp.date=getbatchread.GetString("date");
                batches.AddLast(temp);
            }
            commonClass .close();

            LinkedListNode<batch> point=batches.First;
            

            foreach (var item in result)
            {
                string batch_num=point.Value.batch_num;
                item.batch_num=batch_num;
                item.date=Convert.ToDateTime(point.Value.date);
                point=point.Next;
            }

            //插入到batch_info

            foreach(var item in result){
                commonClass.open();
                MySqlCommand insert=new MySqlCommand("insert into back_info values('"+item.student_ID+"','"+item.date+"','null','null',"+item.batch_num+", '2020-9');",commonClass .returnConn());
                insert.ExecuteNonQuery();
                commonClass.close();
            }



            return result;

        }


    } 
}


/*
 foreach (var item in result)
            {//把已经分配的删除
                commonClass.open();
                MySqlCommand tempcmd=new MySqlCommand("select student_ID from back_info where student_ID='"+item.student_ID+"'",commonClass .returnConn());
                MySqlDataReader tempread=tempcmd.ExecuteReader();
                if(tempread.Read()){
                    result.Remove(item);
                }
                commonClass.close();
            }*/