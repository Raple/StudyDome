using System;
using System.Threading.Tasks;
using System.Web.Http;
using StudyDome.Api.Utility;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(StudyDome.Api.Startup))]

namespace StudyDome.Api
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();
            config.Filters.Add(new ErrorAttribute());

            WebApiConfig.Register(config);
            app.UseWebApi(config);
        }
    }
}
