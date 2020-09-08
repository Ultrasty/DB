using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Read.json
{
    public class Json_File
    {
        public IConfigurationRoot Read_Json_File()
        {
            //这句代码会读取read_json.json中的内容
            return new ConfigurationBuilder().AddJsonFile("myconfig.json")
                                             .Build();

        }

    }
}