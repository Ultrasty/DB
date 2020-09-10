using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

public class CommonClass
{
    string connString = "server=121.199.77.139;database=healthsystem;uid=test;pwd=123";
    MySqlConnection conn;
    public CommonClass()
    {
        conn = new MySqlConnection(connString);
    }

    public void open(){
        conn.Open();
    }
    public MySqlConnection returnConn(){
        return conn;
    }
      public void close()
    {
        conn.Close();
    }

}