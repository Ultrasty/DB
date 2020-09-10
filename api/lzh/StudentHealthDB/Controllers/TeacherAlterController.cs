using System;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using StudentHealthDB.Models;
using StudentHealthDB.Mysql;

namespace StudentHealthDB.Controllers
{
    [Route("teacher/alter")]
    [ApiController]
    public class TeacherAlterController : ControllerBase
    {

        // POST teacher/alter
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
                if (!mdr.HasRows)  //id不存在
                {
                    resp.result = "wrong id";
                    mdr.Close();
                }
                else
                {
                    mdr.Close();
                    MySqlCommand cmd = null;//创建指令
                    if (req.password != null)//修改密码
                    {
                        cmd = new MySqlCommand("update teacher set password = @password where teacher_ID = @id;", conn);
                        cmd.Parameters.AddWithValue("@id", req.id);
                        cmd.Parameters.AddWithValue("@password", req.password);
                        cmd.Prepare();
                        cmd.ExecuteNonQuery();//执行update语句
                    }
                    if (req.department != null)//修改学院
                    {
                        cmd = new MySqlCommand("update teacher set department = @department where teacher_ID = @id;", conn);
                        cmd.Parameters.AddWithValue("@id", req.id);
                        cmd.Parameters.AddWithValue("@department", req.department);
                        cmd.Prepare();
                        cmd.ExecuteNonQuery();//执行update语句
                    }
                    if (req.title != null)//修改职称
                    {
                        cmd = new MySqlCommand("update teacher set title = @title where teacher_ID = @id;", conn);
                        cmd.Parameters.AddWithValue("@id", req.id);
                        cmd.Parameters.AddWithValue("@title", req.title);
                        cmd.Prepare();
                        cmd.ExecuteNonQuery();//执行update语句
                    }
                    if (req.telephone != null)//修改联系方式
                    {
                        cmd = new MySqlCommand("update teacher set contact_way = @telephone where teacher_ID = @id;", conn);
                        cmd.Parameters.AddWithValue("@id", req.id);
                        cmd.Parameters.AddWithValue("@telephone", req.telephone);
                        cmd.Prepare();
                        cmd.ExecuteNonQuery();//执行update语句
                    }
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

