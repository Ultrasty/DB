using System;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using StudentHealthDB.Models;
using StudentHealthDB.Mysql;

namespace StudentHealthDB.Controllers
{
    [Route("teacher/check")]
    [ApiController]
    public class TeacherCheckController : ControllerBase
    {

        // POST teacher/check
        [HttpPost]
        public TeacherCheckResponse Post([FromBody] TeacherCheckRequest req)
        {
            TeacherCheckResponse resp = new TeacherCheckResponse();
            try
            {
                MySqlConnection conn = SQLManager.getConn(); //连接数据库
                conn.Open(); //打开数据库连接
                MySqlCommand cmd = null;//sql语句
                cmd = new MySqlCommand("select teacher_name, department, title, contact_way " +
                    "from teacher where teacher_ID = @id;", conn);
                cmd.Parameters.AddWithValue("@id", req.id);//绑定参数
                MySqlDataReader mdr = cmd.ExecuteReader();
                if (!mdr.HasRows)//查询无结果
                {
                    resp.result = "wrong id";
                }
                else  //查询成功
                {
                    mdr.Read();
                    resp.name = mdr[0].ToString();
                    resp.department = mdr[1].ToString();
                    resp.title  = mdr[2].ToString();
                    resp.telephone = mdr[3].ToString();
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
