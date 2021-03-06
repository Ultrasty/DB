﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using API1.Models;
using MySql.Data.MySqlClient;
using Read.json;
using System.Data;

namespace API1.Controllers
{


    [Route("api/gettable")]
    [ApiController]
    public class Values1Controller : ControllerBase
    {

        [HttpGet]
        public tableinfo Get(string table)
        {
            tableinfo resp = new tableinfo();
            try
            {

                string ip = Request.Headers["X-Forwarded-For"].FirstOrDefault();
                if (string.IsNullOrEmpty(ip))
                ip = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                Console.WriteLine("=============================");
                //使用postman调用接口，使用部署后的网站的页面调用接口，看看请求方的IP是不是同一个
                //是的话可以在网站全部部署后阻止跨域ajax请求，提高安全性
                Console.WriteLine(ip);
                Console.WriteLine("=============================");
                //从配置文件中读取字符串
                Json_File _Json_File = new Json_File();
                var configuration = _Json_File.Read_Json_File();
                string connString = configuration["conn"];

                MySqlConnection conn = new MySqlConnection(connString);
                using (MySqlCommand cmd = new MySqlCommand())//创建查询命令
                {
                    string sql = "select * from " + table;

                    cmd.Connection = conn;
                    cmd.CommandText = sql;
                    //cmd.Parameters.Add(new MySqlParameter("@tablename",req.table));表名不能进行参数化查询
                    MySqlDataAdapter reader = new MySqlDataAdapter(cmd);//创建一个执行命令的适配器对象              
                    DataSet ds = new DataSet();//相当于建立一个基于前台的虚拟数据库
                    DataTable dtable;//相当于数据库中的一张数据表
                    DataRowCollection coldrow;//相当于表中行的集合
                    DataRow drow;//相当于一行中列的数据集合
                    reader.Fill(ds, "ds");//将查询的结果存储到虚拟数据库ds的虚拟表student中
                    dtable = ds.Tables["ds"];//将数据表student的数据复制到DataTable对象（取库中的一张数据表）
                    coldrow = dtable.Rows;//获取数据表中的所有行
                    int len = coldrow[0].ItemArray.Length;//获取一行有多少字段

                    resp.countofcolumns = len;//数据表列数
                    resp.countofrows = coldrow.Count;//数据表行数

                    resp.tableheader = new string[0];
                    for (int i = 0; i < dtable.Columns.Count; i++)
                    {
                        List<string> b = resp.tableheader.ToList();
                        b.Add(dtable.Columns[i].ColumnName);
                        resp.tableheader = b.ToArray();
                    }
                    resp.tableinformation = new List<List<string>>();
                    for (int inti = 0; inti < coldrow.Count; inti++)
                    {
                        drow = coldrow[inti];
                        List<string> temp = new List<string>();
                        for (int j = 0; j < len; j++)
                        {
                            temp.Add(drow[j].ToString());
                        }
                        resp.tableinformation.Add(temp);

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return resp;
        }
    }


    //通过数据表的名称获取数据表的API
    [Route("api/gettablebyname")]
    [ApiController]
    public class Values2Controller : ControllerBase
    {

        [HttpPost]
        public tableinfo Post([FromBody] tablename req)
        {
            tableinfo resp = new tableinfo();
            try
            {
                //从配置文件中读取字符串
                Json_File _Json_File = new Json_File();
                var configuration = _Json_File.Read_Json_File();
                string connString = configuration["conn"];

                MySqlConnection conn = new MySqlConnection(connString);
                using (MySqlCommand cmd = new MySqlCommand())//创建查询命令
                {
                    string sql = "select * from "+req.table;

                    cmd.Connection = conn;
                    cmd.CommandText = sql;
                    //cmd.Parameters.Add(new MySqlParameter("@tablename",req.table));表名不能进行参数化查询
                    MySqlDataAdapter reader = new MySqlDataAdapter(cmd);//创建一个执行命令的适配器对象              
                    DataSet ds = new DataSet();//相当于建立一个基于前台的虚拟数据库
                    DataTable dtable;//相当于数据库中的一张数据表
                    DataRowCollection coldrow;//相当于表中行的集合
                    DataRow drow;//相当于一行中列的数据集合
                    reader.Fill(ds, "ds");//将查询的结果存储到虚拟数据库ds的虚拟表student中
                    dtable = ds.Tables["ds"];//将数据表student的数据复制到DataTable对象（取库中的一张数据表）
                    coldrow = dtable.Rows;//获取数据表中的所有行
                    int len = coldrow[0].ItemArray.Length;//获取一行有多少字段

                    resp.countofcolumns = len;//数据表列数
                    resp.countofrows = coldrow.Count;//数据表行数

                    resp.tableheader = new string[0];
                    for (int i = 0; i < dtable.Columns.Count; i++)
                    {
                        List<string> b = resp.tableheader.ToList();
                        b.Add(dtable.Columns[i].ColumnName);
                        resp.tableheader = b.ToArray();
                    }
                    resp.tableinformation = new List<List<string>>();
                    for (int inti = 0; inti < coldrow.Count; inti++)
                    {
                        drow = coldrow[inti];
                        List<string> temp = new List<string>();
                        for (int j = 0; j < len; j++)
                        {
                            temp.Add(drow[j].ToString());
                        }
                        resp.tableinformation.Add(temp);
                        
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return resp;
        }
    }

    [Route("api/sendmessage")]
    [ApiController]
    public class Values3Controller : ControllerBase
    {

        [HttpPost]
        public string Post([FromBody] message req)
        {
            string resp = "";
            try
            {
                //从配置文件中读取字符串
                Json_File _Json_File = new Json_File();
                var configuration = _Json_File.Read_Json_File();
                string connString = configuration["conn"];

                MySqlConnection conn = new MySqlConnection(connString);
                
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand())//创建查询命令
                {
                    string sql = "insert into the_chat_record(sender_id,receiver_id,date,time,content) " +
                        "values (@sender_id,@receiver_id,@date,@time,@content)";

                    cmd.Connection = conn;
                    cmd.CommandText = sql;
                    cmd.Parameters.Add(new MySqlParameter("@sender_id", req.sender_id));
                    cmd.Parameters.Add(new MySqlParameter("@receiver_id", req.receiver_id));
                    cmd.Parameters.Add(new MySqlParameter("@content", req.content));
                    cmd.Parameters.Add(new MySqlParameter("@date", DateTime.Now.ToString("yyyy-MM-dd")));
                    cmd.Parameters.Add(new MySqlParameter("@time", DateTime.Now.ToLongTimeString().ToString()));
                    cmd.ExecuteNonQuery();//用来执行sql语句
                }
                conn.Close();
                resp = "success";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                resp = "fail";
            }

            return resp;
        }
    }

    [Route("api/getmessage")]
    [ApiController]
    public class Values4Controller : ControllerBase
    {

        [HttpPost]
        public tableinfo Post([FromBody] twoperson req)
        {
            tableinfo resp = new tableinfo();
            try
            {
                //从配置文件中读取字符串
                Json_File _Json_File = new Json_File();
                var configuration = _Json_File.Read_Json_File();
                string connString = configuration["conn"];

                MySqlConnection conn = new MySqlConnection(connString);
                using (MySqlCommand cmd = new MySqlCommand())//创建查询命令
                {
                    string sql = "select * from the_chat_record where the_chat_record.sender_id = " +
                        "@sender_id and the_chat_record.receiver_id = @receiver_id";

                    cmd.Connection = conn;
                    cmd.CommandText = sql;
                    cmd.Parameters.Add(new MySqlParameter("@sender_id", req.sender_id));
                    cmd.Parameters.Add(new MySqlParameter("@receiver_id", req.receiver_id));
                    //cmd.Parameters.Add(new MySqlParameter("@tablename",req.table));表名不能进行参数化查询
                    MySqlDataAdapter reader = new MySqlDataAdapter(cmd);//创建一个执行命令的适配器对象              
                    DataSet ds = new DataSet();//相当于建立一个基于前台的虚拟数据库
                    DataTable dtable;//相当于数据库中的一张数据表
                    DataRowCollection coldrow;//相当于表中行的集合
                    DataRow drow;//相当于一行中列的数据集合
                    reader.Fill(ds, "ds");//将查询的结果存储到虚拟数据库ds的虚拟表student中
                    dtable = ds.Tables["ds"];//将数据表student的数据复制到DataTable对象（取库中的一张数据表）
                    coldrow = dtable.Rows;//获取数据表中的所有行
                    int len = coldrow[0].ItemArray.Length;//获取一行有多少字段

                    resp.countofcolumns = len;//数据表列数
                    resp.countofrows = coldrow.Count;//数据表行数

                    resp.tableheader = new string[0];
                    for (int i = 0; i < dtable.Columns.Count; i++)
                    {
                        List<string> b = resp.tableheader.ToList();
                        b.Add(dtable.Columns[i].ColumnName);
                        resp.tableheader = b.ToArray();
                    }
                    resp.tableinformation = new List<List<string>>();
                    for (int inti = 0; inti < coldrow.Count; inti++)
                    {
                        drow = coldrow[inti];
                        List<string> temp = new List<string>();
                        for (int j = 0; j < len; j++)
                        {
                            temp.Add(drow[j].ToString());
                        }
                        resp.tableinformation.Add(temp);

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return resp;
        }
    }
}
