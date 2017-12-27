using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Http;

namespace Lesson01
{
    public class FormatterConfig
    {
        static internal void Register(HttpConfiguration config)
        {
            //json formatteri silmek
            config.Formatters.Remove(config.Formatters.JsonFormatter);


            //json formatteri elave etmek
            config.Formatters.Add(new JsonMediaTypeFormatter());
        }
    }
}