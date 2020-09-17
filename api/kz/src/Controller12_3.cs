using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Health.Models;
using dbproj.connect;
using MySql.Data.MySqlClient;

namespace dbproj.Controllers
{
    [ApiController]
    [Route("api/12/getDepartment")]
    public class Controller12_3 : ControllerBase
    {
    
        [HttpGet("{teacher_ID}")]
        public string Get(string teacher_ID)
        {
            Connection conn=new Connection();
            MySqlConnection myConn= conn.GetConnection();
            string s=string.Format("select department from teacher where teacher_ID='{0}'",teacher_ID);
            MySqlCommand command=new MySqlCommand(s,myConn);
            MySqlDataReader reader = command.ExecuteReader();
            try{
                reader.Read();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return "该ID不存在";
            }
            string result=reader.GetString(0);
            reader.Close();
            conn.Close();
            return result;
        }

    }
}