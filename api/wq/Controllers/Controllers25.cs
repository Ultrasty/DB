using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
//using System.Web.Script.Serialization;

using Newtonsoft.Json.Linq;
namespace database.Controllers
{
    [ApiController]
    [Route("api/25")] 
    public class Get25 : ControllerBase
    {
        [HttpPost]
        public string Update25([FromBody] SSSs[] s){
            if (s.Length == 0)
            {
                return "更新失败";
            }
            int length = s.Length;
         //   city_risk[] ss = new city_risk[length];
            string date = DateTime.Now.ToShortDateString();

            foreach (var item in s)
            {
                CommonClass commonClass = new CommonClass();
                commonClass.open();
                MySqlCommand ifexit = new MySqlCommand("select * from pandemic_situation where province='" + 
                    item.Province + "' and city='" + item.City + "' and date='" +
                    date +"'", commonClass.returnConn());
                MySqlDataReader tempread = ifexit.ExecuteReader();
                if (tempread.Read()) { commonClass.close();  continue; }
                commonClass.close();
                commonClass.open();
                MySqlCommand insert = new MySqlCommand(
                    "insert into pandemic_situation values('" +
                        item.Province + "','" + item.City + "'," + 
                        item.Risk_level + ",'"+date+"');", 
                        commonClass.returnConn());
                insert.ExecuteNonQuery();

                commonClass.close();
            }
           

           

            return "更新成功";

        }


    } 
}