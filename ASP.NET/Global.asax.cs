using System.Web.Mvc;
using System.Web.Routing;

namespace DBContext
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            DbContext.RouteConfig.RegisterRoutes(RouteTable.Routes);

        }
    }
}
