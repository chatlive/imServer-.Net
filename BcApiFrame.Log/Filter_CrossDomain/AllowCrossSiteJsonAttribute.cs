using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BcApiFrame.Log.Filter_CrossDomain
{
    /// <summary>
    /// 允许跨域站点访问
    /// </summary>
    public class AllowCrossSiteJsonAttribute : ActionFilterAttribute
    {
        //public override void OnActionExecuting(ActionExecutingContext filterContext)
        //{
        //    //var domains = new List<string> { "domain2.com", "domain1.com" };

        //    //if (domains.Contains(filterContext.RequestContext.HttpContext.Request.UrlReferrer.Host))
        //    //{
        //    //    filterContext.RequestContext.HttpContext.Response.AddHeader("Access-Control-Allow-Origin", "*");
        //    //}

        //    //filterContext.RequestContext.HttpContext.Response.AddHeader("Access-Control-Allow-Origin", "*");

        //    base.OnActionExecuting(filterContext);
        //}
    }
}