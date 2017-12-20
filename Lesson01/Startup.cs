using System.Web.Http;

namespace Lesson01
{
    public class Startup
    {
        static internal void Configure(HttpConfiguration config)
        {
            WebApiConfig.Register(config);

            //filters configurations

            FilterConfig.Register(config);
        }
    }
}