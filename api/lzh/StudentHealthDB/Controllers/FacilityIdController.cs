using System;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using StudentHealthDB.Models;
using StudentHealthDB.Mysql;

namespace StudentHealthDB.Controllers
{
    [Route("facility/id")]
    [ApiController]
    public class FacilityIdController : ControllerBase
    {

        // POST facility/id
        [HttpPost]
        public FacilityIdResponse Post([FromBody] FacilityIdRequest req)
        {
            FacilityIdResponse resp = new FacilityIdResponse();
            try
            {
                MySqlConnection conn = SQLManager.getConn(); //连接数据库
                conn.Open(); //打开数据库连接
                MySqlCommand cmd = null;//sql语句
                cmd = new MySqlCommand("select facility_ID from facilities where facility_name = @name;", conn);
                cmd.Parameters.AddWithValue("@name", req.name);//绑定参数
                MySqlDataReader mdr = cmd.ExecuteReader();
                if (!mdr.HasRows)//查询无结果
                {
                    resp.result = "wrong name";
                }
                else  //查询成功
                {
                    mdr.Read();
                    resp.id = mdr[0].ToString();
                    resp.result = "success";
                }
                mdr.Close();
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
