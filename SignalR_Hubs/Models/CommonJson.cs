using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR_Hubs.Models
{
    public class CommonJson
    {
        /// <summary>
        ///  用camel命名法 转化为JSON数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static string camelJson(object model)
        {
            var setting = new JsonSerializerSettings() { ContractResolver = new CamelCasePropertyNamesContractResolver() };

            string result = JsonConvert.SerializeObject(model, new JsonSerializerSettings() { ContractResolver = new CamelCasePropertyNamesContractResolver() });
            return result;
        }

        /// <summary>
        ///  用camel命名法 转化对象
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static object camelObject(object model)
        {
            string json = CommonJson.camelJson(model);
            var result = JsonConvert.DeserializeObject(json);

            return result;
        }

    }
}
