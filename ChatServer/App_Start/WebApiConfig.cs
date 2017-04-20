using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

using System.Web.Http.OData.Builder;
using System.Web.Http.OData.Extensions;
namespace ChatServer
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            #region 日志

            config.Filters.Add(new BcApiFrame.Log.Filter_ApiRecord.Filter_ApiRecord());
            config.Filters.Add(new BcApiFrame.Log.Filter_ErrorRecord.ApiHandleErrorAttribute());
            config.Filters.Add(new BcApiFrame.Log.Filter_Monitor.StatisticsTrackerApiAttribute());

            #endregion

            #region 启用跨域

            config.EnableCors();

            #endregion

            #region 请注意 OData URL 区分大小写。

            //ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            //builder.EntitySet<Customer>("TestApiOData3ef");
            //config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());

            #endregion

            #region Use camel case for JSON data.

            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            #endregion

            #region 原始

            // Web API 配置和服务

            // Web API 路由
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}",
                defaults: new { id = RouteParameter.Optional }
            );

            #endregion
        }
    }
}
