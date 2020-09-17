using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Health.Models;
using dbproj.connect;
using MySql.Data.MySqlClient;

namespace dbproj.Controllers
{
    [ApiController]
    [Route("api/15/getNum")]
    public class Controller15 : ControllerBase
    {

         [HttpGet("{date}")]
        public string Post(string date)
        {
            Connection conn=new Connection();
            MySqlConnection myConn= conn.GetConnection();
            string s=string.Format("select count(*) from leaving_record where date='{0}'",date);
            string sql=string.Format("select count(*) from leaving_record where date_back='{0}'",date);
            MySqlCommand command=new MySqlCommand(s,myConn);
            MySqlDataReader reader= command.ExecuteReader();
            reader.Read();
            int sout=reader.GetInt16(0);
            reader.Close();
            MySqlCommand command1=new MySqlCommand(sql,myConn);
            MySqlDataReader reader1= command1.ExecuteReader();
            reader1.Read();
            int sin=reader1.GetInt16(0);
            reader1.Close();
            conn.Close();
            return "出校:"+sout.ToString()+" 返校:"+sin.ToString();
        }
    }
}