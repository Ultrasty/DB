using System;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using StudentHealthDB.Models;
using StudentHealthDB.Mysql;

namespace StudentHealthDB.Controllers
{
    [Route("student/alter")]
    [ApiController]
    public class StudentAlterController : ControllerBase
    {

        // POST student/alter
        [HttpPost]
        public StudentAddResponse Post([FromBody] StudentAddRequest req)
        {
            StudentAddResponse resp = new StudentAddResponse();
            try
            {
                MySqlConnection conn = SQLManager.getConn(); //连接数据库
                conn.Open(); //打开数据库连接
                MySqlCommand test = null;//创建查询指令
                test = new MySqlCommand("select* from student where student_ID=?id;", conn);
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
                    MySqlCommand cmd = null;//创建查询指令
                    if(req.password != null)//修改密码
                    {
                        cmd = new MySqlCommand("update student set password = @password where student_ID = @id;", conn);
                        cmd.Parameters.AddWithValue("@id", req.id);
                        cmd.Parameters.AddWithValue("@password", req.password);
                        cmd.Prepare();
                        cmd.ExecuteNonQuery();//执行update语句
                    }
                    if (req.department != null)//修改学院
                    {
                        cmd = new MySqlCommand("update student set department = @department where student_ID = @id;", conn);
                        cmd.Parameters.AddWithValue("@id", req.id);
                        cmd.Parameters.AddWithValue("@department", req.department);
                        cmd.Prepare();
                        cmd.ExecuteNonQuery();//执行update语句
                    }
                    if (req.classnum != null)//修改班级
                    {
                        cmd = new MySqlCommand("update student set class_num = @classnum where student_ID = @id;", conn);
                        cmd.Parameters.AddWithValue("@id", req.id);
                        cmd.Parameters.AddWithValue("@classnum", req.classnum);
                        cmd.Prepare();
                        cmd.ExecuteNonQuery();//执行update语句
                    }
                    if (req.dorm != null)//修改宿舍
                    {
                        cmd = new MySqlCommand("update student set dorm_num = @dorm where student_ID = @id;", conn);
                        cmd.Parameters.AddWithValue("@id", req.id);
                        cmd.Parameters.AddWithValue("@dorm", req.dorm);
                        cmd.Prepare();
                        cmd.ExecuteNonQuery();//执行update语句
                    }
                    if (req.healthcodecolor != null)//修改健康码颜色
                    {
                        string color = "";
                        if (req.healthcodecolor == "绿色")
                            color = "green";
                        else if (req.healthcodecolor == "红色")
                            color = "red";
                        else if (req.healthcodecolor == "黄色")
                            color = "yellow";
                        cmd = new MySqlCommand("update student set healthcode_color = @healthcodecolor where student_ID = @id;", conn);
                        cmd.Parameters.AddWithValue("@id", req.id);
                        cmd.Parameters.AddWithValue("@healthcodecolor", color);
                        cmd.Prepare();
                        cmd.ExecuteNonQuery();//执行update语句
                    }
                    if (req.telephone != null)//修改联系方式
                    {
                        cmd = new MySqlCommand("update student set contact_way = @telephone where student_ID = @id;", conn);
                        cmd.Parameters.AddWithValue("@id", req.id);
                        cmd.Parameters.AddWithValue("@telephone", req.telephone);
                        cmd.Prepare();
                        cmd.ExecuteNonQuery();//执行update语句
                    }
                    if (req.emergencyphone != null)//修改紧急联系方式
                    {
                        cmd = new MySqlCommand("update student set emergency_contact = @emergencyphone where student_ID = @id;", conn);
                        cmd.Parameters.AddWithValue("@id", req.id);
                        cmd.Parameters.AddWithValue("@emergencyphone", req.emergencyphone);
                        cmd.Prepare();
                        cmd.ExecuteNonQuery();//执行update语句
                    }
                    if (req.healthstatus != null)//修改健康状态
                    {
                        cmd = new MySqlCommand("update student set currenthealth_status = @healthstatus where student_ID = @id;", conn);
                        cmd.Parameters.AddWithValue("@id", req.id);
                        int health;
                        switch (req.healthstatus)
                        {
                            case "健康":
                                health = 0;
                                break;
                            case "发热":
                                health = 1;
                                break;
                            case "疑似":
                                health = 2;
                                break;
                            case "确诊":
                                health = 3;
                                break;
                            default: health = -1; break;
                        }
                        cmd.Parameters.AddWithValue("@healthstatus", health);
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
