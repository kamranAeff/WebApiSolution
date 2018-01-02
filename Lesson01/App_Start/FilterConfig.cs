using Lesson01.Filters;
using System.Web.Http;

namespace Lesson01
{
    public class FilterConfig
    {
        static internal void Register(HttpConfiguration config)
        {
            config.Filters.Add(new GlobalLogFilterAttribute());

            //model validating
            config.Filters.Add(new ValidateModelAttribute());
        }
    }
}