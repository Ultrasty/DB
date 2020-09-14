using System;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using StudentHealthDB.Models;
using StudentHealthDB.Mysql;

namespace StudentHealthDB.Controllers
{
    [Route("facility/alter")]
    [ApiController]
    public class FacilityAlterController : ControllerBase
    {
        // POST facility/alter
        [HttpPost]
        public FacilityAlterResponse Post([FromBody] FacilityAlterRequest req)
        {
            FacilityAlterResponse resp = new FacilityAlterResponse();
            try
            {
                //时间更改的约束
                if (req.starttime!=null && req.endtime!=null && req.starttime >= req.endtime)
                {
                    resp.result = "fail";
                    return resp;
                }
                if (req.starttime != null && req.starttime < 0)
                {
                    resp.result = "fail";
                    return resp;
                }
                if (req.starttime != null && req.endtime > 24)
                {
                    resp.result = "fail";
                    return resp;
                }
                MySqlConnection conn = SQLManager.getConn(); //连接数据库
                conn.Open(); //打开数据库连接mdr.Close();
                MySqlCommand cmd = null;//创建查询指令
                if (req.name != null)//修改名称
                {
                    cmd = new MySqlCommand("update facilities set facility_name = @name where facility_ID = @id;", conn);
                    cmd.Parameters.AddWithValue("@id", req.facility);
                    cmd.Parameters.AddWithValue("@name", req.name);
                    cmd.Prepare();
                    cmd.ExecuteNonQuery();//执行update语句
                }
                if (req.starttime != null)//修改开放时间
                {
                    cmd = new MySqlCommand("update facilities set start_time = @start where facility_ID = @id;", conn);
                    cmd.Parameters.AddWithValue("@id", req.facility);
                    cmd.Parameters.AddWithValue("@start", req.starttime);
                    cmd.Prepare();
                    cmd.ExecuteNonQuery();//执行update语句
                }
                if (req.endtime != null)//修改结束开放时间
                {
                    cmd = new MySqlCommand("update facilities set end_time = @end where facility_ID = @id;", conn);
                    cmd.Parameters.AddWithValue("@id", req.facility);
                    cmd.Parameters.AddWithValue("@end", req.endtime);
                    cmd.Prepare();
                    cmd.ExecuteNonQuery();//执行update语句
                }
                if (req.startdate != null)//修改开放起始日期
                {
                    cmd = new MySqlCommand("update facilities set start_day = @start where facility_ID = @id;", conn);
                    cmd.Parameters.AddWithValue("@id", req.facility);
                    cmd.Parameters.AddWithValue("@start", req.startdate);
                    cmd.Prepare();
                    cmd.ExecuteNonQuery();//执行update语句
                }
                if (req.enddate != null)//修改最后开放日期
                {
                    cmd = new MySqlCommand("update facilities set end_day = @end where facility_ID = @id;", conn);
                    cmd.Parameters.AddWithValue("@id", req.facility);
                    cmd.Parameters.AddWithValue("@end", req.enddate);
                    cmd.Prepare();
                    cmd.ExecuteNonQuery();//执行update语句
                }
                if (req.capacity != null)//修改容量
                {
                    cmd = new MySqlCommand("update facilities set max_capacity = @capacity where facility_ID = @id;", conn);
                    cmd.Parameters.AddWithValue("@id", req.facility);
                    cmd.Parameters.AddWithValue("@capacity", req.capacity);
                    cmd.Prepare();
                    cmd.ExecuteNonQuery();//执行update语句
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
    }
}
