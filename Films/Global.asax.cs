using Films.Kernel.Managers;
using Films.Server;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Films
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            Injector.Configs.Debug = true;
            Injector.Configs.TurnDataBase = true;

            Injector.Configs.TurnLog = true;
            Injector.Configs.LogFileName = "C:\\log-test.txt";
        }
    }
}
