using System.Web.Http;

namespace Lesson01
{
    public class Startup
    {
        static internal void Configure(HttpConfiguration config)
        {
            WebApiConfig.Register(config);

            HandlerConfig.Register(config);

            //filters configurations

            FilterConfig.Register(config);

            //formatter configurations

            FormatterConfig.Register(config);

            //binders configurations
            BinderConfig.Register(config);

            //mapper configurations
            MapperConfig.Register(config);
        }
    }
}