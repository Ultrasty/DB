using System;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using StudentHealthDB.Models;
using StudentHealthDB.Mysql;

namespace StudentHealthDB.Controllers
{
    [Route("student/login")]
    [ApiController]
    public class StudentLoginController : ControllerBase
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
                cmd = new MySqlCommand("select password from student where student_ID = ?id;", conn);
                cmd.Parameters.AddWithValue("?id", req.id);
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
                /*conn.Open(); //打开数据库连接
                string sql = "select * from user";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader mdr = cmd.ExecuteReader();
                if (mdr.Read())
                {
                    string str = mdr["authority"].ToString();//接收一个返回值
                    //对查询到数据进行相应的操作
                }
                conn.Close();*/
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return resp;
        }

        // DELETE api/values/5
/*        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }*/
    }
    /*[ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }*/
}
