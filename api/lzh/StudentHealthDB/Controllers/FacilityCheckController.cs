using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using StudentHealthDB.Models;
using StudentHealthDB.Mysql;

namespace StudentHealthDB.Controllers
{

    [Route("facility/check")]
    [ApiController]
    public class FacilityCheckController : ControllerBase
    {
        // POST facility/check
        [HttpPost]
        public FacilityCheckResponse Post([FromBody] FacilityCheckRequest req)
        {
            FacilityCheckResponse resp = new FacilityCheckResponse();
            try
            {
                MySqlConnection conn = SQLManager.getConn(); //连接数据库
                conn.Open(); //打开数据库连接mdr.Close();
                MySqlCommand cmd = null;//创建查询指令
                cmd = new MySqlCommand("select * from facilities where facility_ID=@facility;", conn);
                cmd.Parameters.AddWithValue("@facility", req.facility);//绑定参数facility
                MySqlDataReader mdr = cmd.ExecuteReader();
                mdr.Read();
                resp.name = Convert.ToString(mdr.GetValue(1));
                resp.starttime = Convert.ToInt32(mdr.GetValue(2));
                resp.endtime = Convert.ToInt32(mdr.GetValue(3));
                resp.capacity = Convert.ToInt32(mdr.GetValue(4));
                resp.startdate = Convert.ToInt32(mdr.GetValue(5));
                resp.enddate = Convert.ToInt32(mdr.GetValue(6));
                mdr.Close();
                if (req.date != null)
                {
                    DateTime dt = Convert.ToDateTime(req.date);
                    int weekday = GetWeek(dt);
                    if (weekday < resp.startdate || weekday > resp.enddate)
                    {
                        resp.result = "not open";
                        conn.Close();//关闭连接
                        return resp;
                    }
                    else
                    {
                        resp.periodleft = new List<period>();
                        for (int i = resp.starttime; i < resp.endtime; i++)
                        {
                            cmd = new MySqlCommand("select count(*) from application " +
                            "where facility_ID=@id and date=@date and start_time<=@start and end_time>=@end;", conn);
                            cmd.Parameters.AddWithValue("@id", req.facility);
                            cmd.Parameters.AddWithValue("@date", req.date);
                            cmd.Parameters.AddWithValue("@start", i);
                            cmd.Parameters.AddWithValue("@end", i + 1);
                            mdr = cmd.ExecuteReader();
                            period pe = new period();
                            pe.start = i;
                            mdr.Read();
                            int number = Convert.ToInt32(mdr.GetValue(0));
                            pe.left = resp.capacity - number;  //剩余容量
                            mdr.Close();
                            resp.periodleft.Add(pe);
                        }
                    }
                }
                resp.result = "success";
                conn.Close();//关闭连接
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                resp.result = "fail";
            }
            return resp;
        }
        public int GetWeek(DateTime date)
        {
            int weekday;
            string dt = date.ToString("dddd");
            switch (dt)
            {
                case "Monday":
                case "星期一":
                    weekday = 1;
                    break;
                case "Tuesday":
                case "星期二":
                    weekday = 2;
                    break;
                case "Wednesday":
                case "星期三":
                    weekday = 3;
                    break;
                case "Thursday":
                case "星期四":
                    weekday = 4;
                    break;
                case "Friday":
                case "星期五":
                    weekday = 5;
                    break;
                case "Saturday":
                case "星期六":
                    weekday = 6;
                    break;
                case "Sunday":
                case "星期日":
                    weekday = 7;
                    break;
                default:
                    weekday = 0;
                    break;
            }
            return weekday;
        }
    }
}
