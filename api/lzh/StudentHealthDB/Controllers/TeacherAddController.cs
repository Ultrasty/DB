using System;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using StudentHealthDB.Models;
using StudentHealthDB.Mysql;

namespace StudentHealthDB.Controllers
{
    [Route("teacher/add")]
    [ApiController]
    public class TeacherAddController : ControllerBase
    {

        // POST Teacher/add
        [HttpPost]
        public TeacherAddResponse Post([FromBody] TeacherAddRequest req)
        {
            TeacherAddResponse resp = new TeacherAddResponse();
            try
            {
                MySqlConnection conn = SQLManager.getConn(); //连接数据库
                conn.Open(); //打开数据库连接
                MySqlCommand test = null;//创建查询指令
                test = new MySqlCommand("select* from teacher where teacher_ID=?id;", conn);
                test.Parameters.AddWithValue("?id", req.id);
                MySqlDataReader mdr = test.ExecuteReader();
                if (mdr.HasRows)
                {
                    resp.result = "id existed";
                    mdr.Close();
                }
                else
                {
                    mdr.Close();
                    MySqlCommand cmd = null;//创建查询指令

                    cmd = new MySqlCommand("insert into Teacher values" +
                                                                "(@id,@password,@name,@department,@title,@telephone);", conn);
                    cmd.Parameters.AddWithValue("@id", req.id);
                    cmd.Parameters.AddWithValue("@name", req.name);
                    cmd.Parameters.AddWithValue("@password", req.password);
                    cmd.Parameters.AddWithValue("@department", req.department);
                    cmd.Parameters.AddWithValue("@title", req.title);
                    cmd.Parameters.AddWithValue("@telephone", req.telephone);
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
