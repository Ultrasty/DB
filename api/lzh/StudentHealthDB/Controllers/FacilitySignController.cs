using System;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using StudentHealthDB.Models;
using StudentHealthDB.Mysql;

namespace StudentHealthDB.Controllers
{
    [Route("facility/sign")]
    [ApiController]
    public class FacilitySignController : ControllerBase
    {
        // POST facility/sign
        [HttpPost]
        public FacilitySignResponse Post([FromBody] FacilitySignRequest req)
        {
            FacilitySignResponse resp = new FacilitySignResponse();
            try
            {
                MySqlConnection conn = SQLManager.getConn(); //连接数据库
                conn.Open(); //打开数据库连接
                MySqlCommand cmd = null;//sql语句
                string currentTime = DateTime.Now.ToString();//获取当前时间
                string date = DateTime.Now.ToString("yyyy-MM-dd");//获取当前日期
                int hour = DateTime.Now.Hour;//获取小时
                int minute = DateTime.Now.Minute;//获取分钟
                cmd = new MySqlCommand("select start_time,end_time from application " +
                    "where applicant_ID=@id and facility_ID=@facility and date=@date;", conn);
                cmd.Parameters.AddWithValue("@facility", req.facility);//绑定参数facility
                cmd.Parameters.AddWithValue("@date", date);//绑定参数date
                cmd.Parameters.AddWithValue("@id", req.id);//绑定参数start
                MySqlDataReader mdr = cmd.ExecuteReader();
                bool success = false;
                if (!mdr.HasRows)//当天无预约
                {
                    mdr.Close();
                    resp.result = "fail";
                }
                else  //有预约
                {
                    while (mdr.Read())
                    {
                        int start = Convert.ToInt32(mdr.GetValue(0));
                        int end = Convert.ToInt32(mdr.GetValue(1));
                        if(req.inout == 0)//进入设施打卡
                        {
                            if(hour==start && minute<=30)//预约使用时间之后半小时以内
                            {
                                mdr.Close();
                                //插入当前时间
                                cmd = new MySqlCommand("update application set enter_time = @enter " +
                                    "where applicant_ID=@id and facility_ID=@facility and date=@date and start_time=@start;", conn);
                                cmd.Parameters.AddWithValue("@enter", currentTime);//绑定参数为当前时间
                                cmd.Parameters.AddWithValue("@id", req.id);
                                cmd.Parameters.AddWithValue("@facility", req.facility);
                                cmd.Parameters.AddWithValue("@date", date);
                                cmd.Parameters.AddWithValue("@start", start);
                                cmd.Prepare();
                                cmd.ExecuteNonQuery();//执行update语句
                                resp.result = "success";
                                success = true;
                                break;
                            }
                        }
                        else//出设施打卡
                        {
                            if (hour == end - 1 && minute >= 30)//预约结束时间之前半小时以内
                            {
                                mdr.Close();
                                //插入当前时间
                                cmd = new MySqlCommand("update application set left_time = @left " +
                                    "where applicant_ID=@id and facility_ID=@facility and date=@date and start_time=@start;", conn);
                                cmd.Parameters.AddWithValue("@left", currentTime);//绑定参数为当前时间
                                cmd.Parameters.AddWithValue("@id", req.id);
                                cmd.Parameters.AddWithValue("@facility", req.facility);
                                cmd.Parameters.AddWithValue("@date", date);
                                cmd.Parameters.AddWithValue("@start", start);
                                cmd.Prepare();
                                cmd.ExecuteNonQuery();//执行update语句
                                resp.result = "success";
                                success = true;
                                break;
                            }
                        }
                    }
                }
                if(success==false)
                {
                    mdr.Close();
                    resp.result = "fail";
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
