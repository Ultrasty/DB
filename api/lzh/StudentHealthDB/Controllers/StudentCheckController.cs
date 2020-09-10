using System;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using StudentHealthDB.Models;
using StudentHealthDB.Mysql;

namespace StudentHealthDB.Controllers
{
    [Route("student/check")]
    [ApiController]
    public class StudentCheckController : ControllerBase
    {

        // POST student/check
        [HttpPost]
        public StudentCheckResponse Post([FromBody] StudentCheckRequest req)
        {
            StudentCheckResponse resp = new StudentCheckResponse();
            try
            {
                MySqlConnection conn = SQLManager.getConn(); //连接数据库
                conn.Open(); //打开数据库连接
                MySqlCommand cmd = null;//sql语句
                cmd = new MySqlCommand("select " +
                    "student_name, Gender, department, grade, class_num, dorm_num, healthcode_color, " +
                    "contact_way, emergency_contact, currenthealth_status " +
                    "from student where student_ID = @id;", conn);
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
                    int gen = Convert.ToInt32(mdr.GetValue(1));
                    resp.gender = gen == 0 ? "男" : "女";
                    resp.department = mdr[2].ToString();
                    resp.grade = mdr[3].ToString();
                    resp.classnum = mdr[4].ToString();
                    resp.dorm = mdr[5].ToString();
                    string color = mdr[6].ToString();
                    switch(color)
                    {
                        case "green":
                            resp.healthcodecolor = "绿色";
                            break;
                        case "red":
                            resp.healthcodecolor = "红色";
                            break;
                        case "yellow":
                            resp.healthcodecolor = "黄色";
                            break;
                    }
                    resp.telephone = mdr[7].ToString();
                    resp.emergencyphone = mdr[8].ToString();
                    int health = Convert.ToInt32(mdr.GetValue(9));
                    switch(health)
                    {
                        case 0:
                            resp.healthstatus = "健康";
                            break;
                        case 1:
                            resp.healthstatus = "发热";
                            break;
                        case 2:
                            resp.healthstatus = "疑似";
                            break;
                        case 3:
                            resp.healthstatus = "确诊";
                            break;
                    }
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
