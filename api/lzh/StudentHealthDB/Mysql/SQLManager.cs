using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentHealthDB.Mysql
{
    public class SQLManager
    {
        static public MySqlConnection getConn()
        {
            string connetStr = "server=121.199.77.139;port=3306;user=test;password=123;database=healthsystem;Charset=utf8;";
            MySqlConnection conn = new MySqlConnection(connetStr);
            Console.WriteLine("连接成功");
            return conn;
        }
    }
}
