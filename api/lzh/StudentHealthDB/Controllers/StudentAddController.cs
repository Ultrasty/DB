using System;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using StudentHealthDB.Models;
using StudentHealthDB.Mysql;

namespace StudentHealthDB.Controllers
{
    [Route("student/add")]
    [ApiController]
    public class StudentAddController : ControllerBase
    {

        // POST student/add
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
                if (mdr.HasRows)
                {
                    resp.result = "id existed";
                    mdr.Close();
                }
                else
                {
                    mdr.Close();
                    MySqlCommand cmd = null;//创建查询指令

                    /*                    cmd = new MySqlCommand("insert into student " +
                                            "(student_ID,Gender,student_name,password,department,grade,class_num,dorm_num,healthcode_color," +
                                            "contact_way,emergency_contact,currenthealth_status) " +
                                            "values " +
                                            "('?id',?gender,'?name','?password','?department','?grade','?classnum','?dorm','?healthcodecolor'," +
                                            "'?telephone','?emergencyphone',?healthstatus);", conn);*/

                    /*                    cmd = new MySqlCommand("insert into student values" +
                                                                "('@id',@gender,'@name','@password','@department','@grade','@classnum','@dorm','@healthcodecolor'," +
                                                                "'@telephone','@emergencyphone',@healthstatus);", conn);*/

                    cmd = new MySqlCommand("insert into student values" +
                                                                "(@id,@gender,@name,@password,@department,@grade,@classnum,@dorm,@healthcodecolor," +
                                                                "@telephone,@emergencyphone,@healthstatus);", conn);
                    cmd.Parameters.AddWithValue("@id", req.id);
                    int gen = req.gender == "男" ? 0 : 1;//男为0，女为1
                    cmd.Parameters.AddWithValue("@gender", gen);
                    cmd.Parameters.AddWithValue("@name", req.name);
                    cmd.Parameters.AddWithValue("@password", req.password);
                    cmd.Parameters.AddWithValue("@department", req.department);
                    cmd.Parameters.AddWithValue("@grade", req.grade);
                    cmd.Parameters.AddWithValue("@classnum", req.classnum);
                    cmd.Parameters.AddWithValue("@dorm", req.dorm);
                    string color = "";
                    if (req.healthcodecolor == "绿色")
                        color = "green";
                    else if (req.healthcodecolor == "红色")
                        color = "red";
                    else if (req.healthcodecolor == "黄色")
                        color = "yellow";
                    cmd.Parameters.AddWithValue("@healthcodecolor", color);
                    cmd.Parameters.AddWithValue("@telephone", req.telephone);
                    cmd.Parameters.AddWithValue("@emergencyphone", req.emergencyphone);
                    int health;
                    switch(req.healthstatus)
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
                        default:health = -1;break;
                    }
                    cmd.Parameters.AddWithValue("@healthstatus", health);
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
