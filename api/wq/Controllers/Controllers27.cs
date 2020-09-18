using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
namespace database.Controllers
{
    [ApiController]
    [Route("api/19/delete")]
    public class get27 : ControllerBase
    {
        [HttpGet]
        public string getStuQua()
        {
            
            CommonClass commonClass = new CommonClass();
            commonClass.open();
            MySqlCommand cmd = new MySqlCommand("delete  from back_info where student_id='1850003' or student_ID='1750001' ", commonClass.returnConn());
            cmd.ExecuteNonQuery();
            commonClass.close();
            return "É¾³ý³É¹¦";

        }


    }
}