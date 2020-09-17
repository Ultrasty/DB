using MySql.Data.MySqlClient;
using System.IO;
using System;

namespace dbproj.connect
{
    public class Connection
    {
        static string connString = "server=121.199.77.139;database=healthsystem;uid=test;pwd=123";
        MySqlConnection connect;
        public Connection()
        {
            connect=new MySqlConnection(connString);
        }

        public void Open()
        {
            try
            {
                connect.Open();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Close()
        {
            connect.Close();
        }

        public MySqlConnection GetConnection()
        {
            Open();
            return connect;
        }
        
    }
}