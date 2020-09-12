using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using StudentHealthDB.Models;
using StudentHealthDB.Mysql;

namespace StudentHealthDB.Controllers
{
    [Route("facility/student")]
    [ApiController]
    public class FacilityStudentController : ControllerBase
    {

        // POST facility/student
        [HttpPost]
        public FacilityStudentResponse Post([FromBody] FacilityStudentRequest req)
        {
            FacilityStudentResponse resp = new FacilityStudentResponse();
            try
            {
                MySqlConnection conn = SQLManager.getConn(); //连接数据库
                conn.Open(); //打开数据库连接
                MySqlCommand cmd = null;//sql语句
                cmd = new MySqlCommand("select distinct applicant_ID from application " +
                    "where facility_ID=@facility and date=@date and " +
                    "((start_time>=@start and start_time<@end)or(end_time>@start and end_time<=@end));", conn);
                cmd.Parameters.AddWithValue("@facility", req.facility);//绑定参数facility
                cmd.Parameters.AddWithValue("@date", req.date);//绑定参数date
                cmd.Parameters.AddWithValue("@start", req.starttime);//绑定参数start
                cmd.Parameters.AddWithValue("@end", req.endtime);//绑定参数end
                MySqlDataReader mdr = cmd.ExecuteReader();
                if (!mdr.HasRows)//无学生
                {
                    resp.student = null;
                    mdr.Close();
                    resp.result = "none";
                }
                else  //查询成功
                {
                    List<string> id = new List<string>();
                    resp.student = new List<StudentInfo>();
                    while (mdr.Read())
                    {
                        id.Add(Convert.ToString(mdr.GetValue(0)));
                    }
                    mdr.Close();
                    for (int i = 0; i < id.Count; i++)
                    {
                        //查询每个id的学生信息
                        cmd = new MySqlCommand("select student_name,department from student where student_ID=@id;", conn);
                        cmd.Parameters.AddWithValue("@id", id[i]);//绑定参数id
                        mdr = cmd.ExecuteReader();
                        mdr.Read();
                        StudentInfo stu = new StudentInfo();
                        stu.id = id[i];
                        stu.name = Convert.ToString(mdr.GetValue(0));
                        stu.department = Convert.ToString(mdr.GetValue(1));//查询结果参数？？
                        resp.student.Add(stu);
                        mdr.Close();
                        resp.result = "success";
                    }
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
