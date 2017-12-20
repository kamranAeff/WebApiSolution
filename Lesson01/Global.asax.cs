using System.Web.Http;

namespace Lesson01
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //GlobalConfiguration.Configure(WebApiConfig.Register);

            GlobalConfiguration.Configure(Startup.Configure);
        }
    }
}
