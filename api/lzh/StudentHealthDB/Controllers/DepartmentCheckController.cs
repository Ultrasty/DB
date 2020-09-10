using System;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using StudentHealthDB.Models;
using StudentHealthDB.Mysql;

namespace StudentHealthDB.Controllers
{
    [Route("department/check")]
    [ApiController]
    public class DepartmentCheckController : ControllerBase
    {

        // POST department/check
        [HttpPost]
        public DepartmentCheckResponse Post([FromBody] DepartmentCheckRequest req)
        {
            DepartmentCheckResponse resp = new DepartmentCheckResponse();
            try
            {
                MySqlConnection conn = SQLManager.getConn(); //连接数据库
                conn.Open(); //打开数据库连接
                MySqlCommand cmd = null;//sql语句
                cmd = new MySqlCommand("select department from student where student_ID = @id;", conn);
                cmd.Parameters.AddWithValue("@id", req.id);//绑定参数
                MySqlDataReader mdr = cmd.ExecuteReader();
                if (!mdr.HasRows)//查询无结果
                {
                    resp.result = "wrong id";
                }
                else  //查询成功
                {
                    mdr.Read();
                    resp.department = mdr[0].ToString();
                    mdr.Close();
                    cmd = new MySqlCommand("select * from department where dept_name = @department;", conn);
                    cmd.Parameters.AddWithValue("@department", resp.department);//绑定参数
                    mdr = cmd.ExecuteReader();
                    mdr.Read();
                    resp.building = mdr[1].ToString();
                    resp.name = mdr[2].ToString();
                    resp.phonenumber = mdr[3].ToString();
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
