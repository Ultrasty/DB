using System;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using StudentHealthDB.Models;
using StudentHealthDB.Mysql;

namespace StudentHealthDB.Controllers
{
    [Route("facility/apply")]
    [ApiController]
    public class FacilityApplyController : ControllerBase
    {
        //将日期转化为星期几的函数
        //param in: DateTime date 指定日期
        //param out: int 将星期几转化为int
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

        // POST facility/apply
        [HttpPost]
        public FacilityApplyResponse Post([FromBody] FacilityApplyRequest req)
        {
            FacilityApplyResponse resp = new FacilityApplyResponse();
            try
            {
                MySqlConnection conn = SQLManager.getConn(); //连接数据库
                conn.Open(); //打开数据库连接
                MySqlCommand test = null;//创建查询指令
                test = new MySqlCommand("select start_time,end_time,max_capacity,start_day,end_day " +
                    "from facilities where facility_ID=?facility;", conn);
                test.Parameters.AddWithValue("?facility", req.facility);
                MySqlDataReader mdr = test.ExecuteReader();//查询设施信息
                if (!mdr.HasRows)
                {
                    resp.result = "wrong facility";//id错误
                    mdr.Close();
                    conn.Close();
                    return resp;
                }
                else
                {
                    mdr.Read();
                    FacilityInfo info = new FacilityInfo();//存储设施信息类
                    info.start = Convert.ToInt32(mdr.GetValue(0));//存储开放起始时间
                    info.end = Convert.ToInt32(mdr.GetValue(1));//存储开放结束时间
                    info.capacity = Convert.ToInt32(mdr.GetValue(2));//存储容量
                    info.startday = Convert.ToInt32(mdr.GetValue(3));//开放起始日期
                    info.endday = Convert.ToInt32(mdr.GetValue(4));//开放最后日期
                    mdr.Close();
                    if (req.starttime < info.start || req.endtime > info.end)//检查申请时间是否符合要求
                    {
                        conn.Close();
                        resp.result = "invalid time";
                        return resp;
                    }
                    int weekday = GetWeek(req.date);//转换int星期几
                    if (weekday < info.startday || weekday > info.endday)//检查日期是否符合要求
                    {
                        conn.Close();
                        resp.result = "invalid date";
                        return resp;
                    }
                    MySqlCommand cmd = null;//创建查询指令
                    
                    //查询健康状态
                    cmd = new MySqlCommand("select currenthealth_status from student " +
                            "where student_ID=@id;", conn);
                    cmd.Parameters.AddWithValue("@id", req.id);
                    mdr = cmd.ExecuteReader();
                    mdr.Read();
                    if (!mdr.HasRows)
                    {
                        resp.result = "wrong id";//id错误
                        mdr.Close();
                        conn.Close();
                        return resp;
                    }
                    int health = Convert.ToInt32(mdr.GetValue(0));
                    mdr.Close();
                    if(health!=0)//若健康状态不为“健康”，申请失败
                    {
                        conn.Close();
                        resp.result = "unqualified";
                        return resp;
                    }

                    string date = req.date.ToString("yyyy-MM-dd");
                    //检查同一申请人申请时间段是否已有其他申请
                    cmd = new MySqlCommand("select applicant_ID from application " +
                            "where applicant_ID=@id and date=@date and " +
                            "(start_time>=@start and start_time<=@end or end_time<=@end and end_time>=@start);", conn);
                    cmd.Parameters.AddWithValue("@id", req.id );
                    cmd.Parameters.AddWithValue("@date", date);
                    cmd.Parameters.AddWithValue("@start", req.starttime);
                    cmd.Parameters.AddWithValue("@end", req.endtime);
                    mdr = cmd.ExecuteReader();
                    if(mdr.HasRows)//已有其他申请
                    {
                        mdr.Close();
                        conn.Close();
                        resp.result = "time overlap";
                        return resp;
                    }
                    mdr.Close();
                    /*
                    int[] quantity;//存储每一时间段人数
                    int hours = req.endtime - req.starttime;
                    quantity = new int[hours];*/

                    //查看每一时间段申请总人数
                    for (int i = req.starttime;i<req.endtime;i++)
                    {
                        cmd = new MySqlCommand("select count(*) from application " +
                            "where facility_ID=@id and date=@date and start_time<=@start and end_time>=@end;", conn);
                        cmd.Parameters.AddWithValue("@id", req.facility);
                        cmd.Parameters.AddWithValue("@date", date);
                        cmd.Parameters.AddWithValue("@start", i);
                        cmd.Parameters.AddWithValue("@end", i+1);
                        mdr = cmd.ExecuteReader();
                        if(mdr.HasRows)
                        {
                            mdr.Read();/*
                            quantity[i - req.starttime] = Convert.ToInt32(mdr.GetValue(0));*/
                            int number = Convert.ToInt32(mdr.GetValue(0));
                            if(number>=info.capacity)//若有时间段预约数已达到容量上限，预约失败
                            {
                                mdr.Close();
                                conn.Close();
                                resp.result = "no left";
                                return resp;
                            }
                        }/*
                        else
                            quantity[i - req.starttime] = 0;*/
                        mdr.Close();
                    }

                    //所有条件符合，插入记录
                    cmd = new MySqlCommand("insert into application values(@id,@facility,@date,@start,@end);", conn);
                    cmd.Parameters.AddWithValue("@id", req.id);
                    cmd.Parameters.AddWithValue("@facility", req.facility);
                    cmd.Parameters.AddWithValue("@date", date);
                    cmd.Parameters.AddWithValue("@start", req.starttime);
                    cmd.Parameters.AddWithValue("@end", req.endtime);
                    cmd.Prepare();
                    cmd.ExecuteNonQuery();//执行insert语句
                    resp.result = "success";
                }
                conn.Close();//关闭连接
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                resp.result = "fail";
            }
            return resp;
        }
    }

}
