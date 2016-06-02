using Easy.Rpc.directory;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            DirectoryFactory.Register("StudyMenu",
                new StaticDirectory(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "sms_rpc.config"), "StudyMenu"));

        }
    }
}
