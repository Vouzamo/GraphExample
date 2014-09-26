using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Routing;
using Data.Context;

namespace Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            // Initialize Database
            Database.SetInitializer(new GraphInitializer());
        }
    }
}
