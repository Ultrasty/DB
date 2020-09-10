using System;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using StudentHealthDB.Models;
using StudentHealthDB.Mysql;

namespace StudentHealthDB.Controllers
{
    [Route("teacher/login")]
    [ApiController]
    public class TeacherLoginController : ControllerBase
    {

        // POST student/login
        [HttpPost]
        public LoginResponse Post([FromBody] LoginRequest req)
        {
            LoginResponse resp = new LoginResponse();
            try
            {
                MySqlConnection conn = SQLManager.getConn(); //连接数据库
                conn.Open(); //打开数据库连接
                MySqlCommand cmd = null;//创建查询指令
                cmd = new MySqlCommand("select password from teacher where teacher_ID = ?id;", conn);
                cmd.Parameters.AddWithValue("?id", req.id);//替换参数
                MySqlDataReader mdr = cmd.ExecuteReader();
                if (mdr.HasRows)
                {
                    string pwd;
                    mdr.Read();
                    pwd = mdr[0].ToString();
                    if (pwd == req.password)
                    {
                        resp.result = "success";
                    }
                    else
                        resp.result = "wrong password";
                }
                else
                    resp.result = "wrong id";
                mdr.Close();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return resp;
        }
    }
}
