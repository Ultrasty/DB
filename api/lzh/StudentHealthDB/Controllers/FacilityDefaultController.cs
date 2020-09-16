using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using StudentHealthDB.Models;
using StudentHealthDB.Mysql;

namespace StudentHealthDB.Controllers
{

    [Route("facility/default")]
    [ApiController]
    public class FacilityDefaultController : ControllerBase
    {
        // POST facility/default
        [HttpPost]
        public FacilityDefaultResponse Post([FromBody] FacilityDefaultRequest req)
        {
            FacilityDefaultResponse resp = new FacilityDefaultResponse();
            try
            {
                List<string> id = new List<string>();
                MySqlConnection conn = SQLManager.getConn(); //连接数据库
                conn.Open(); //打开数据库连接
                MySqlCommand cmd = null;//sql语句
                cmd = new MySqlCommand("select facility_ID,date from default_record " +
                    "where applicant_ID=@id;", conn);
                cmd.Parameters.AddWithValue("@id", req.id);//绑定参数id
                MySqlDataReader mdr = cmd.ExecuteReader();
                if (mdr.HasRows)
                {
                    resp.detail = new List<record>();
                    while (mdr.Read())
                    {
                        record rcd = new record();
                        id.Add(Convert.ToString(mdr.GetValue(0)));
                        rcd.date = Convert.ToDateTime(mdr.GetValue(1)).ToString("yyyy-MM-dd");
                        resp.detail.Add(rcd);
                    }
                    mdr.Close();
                    for(int i = 0;i<id.Count;i++)
                    {
                        cmd = new MySqlCommand("select facility_name from facilities " +
                            "where facility_ID=@facility;", conn);
                        cmd.Parameters.AddWithValue("@facility", id[i]);//绑定参数id
                        mdr = cmd.ExecuteReader();
                        mdr.Read();
                        resp.detail[i].name = Convert.ToString(mdr.GetValue(0));
                        mdr.Close();
                    }
                    resp.result = "success";
                }
                else
                    resp.result = "none";
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
