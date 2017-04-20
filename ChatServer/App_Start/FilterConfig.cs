using System.Web;
using System.Web.Mvc;

namespace ChatServer
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());

            filters.Add(new BcApiFrame.Log.Filter_Monitor.StatisticsTrackerAttribute());
            filters.Add(new BcApiFrame.Log.Filter_ErrorRecord.MvcHandleErrorAttribute());
        }
    }
}
