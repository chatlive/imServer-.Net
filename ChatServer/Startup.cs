using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;

[assembly: OwinStartupAttribute(typeof(ChatServer.Startup))]
namespace ChatServer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //app.MapSignalR();
            app.Map("/signalr", map =>
            {
                map.UseCors(CorsOptions.AllowAll);
                var hubConfiguration = new HubConfiguration();
#if DEBUG
                hubConfiguration.EnableDetailedErrors = true;
#else
                hubConfiguration.EnableDetailedErrors = false;
#endif
                map.RunSignalR(hubConfiguration);
            });

            //GlobalHost.HubPipeline.RequireAuthentication();
        }
    }
}
