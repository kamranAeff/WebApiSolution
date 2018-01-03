using Lesson01.Binders;
using System;
using System.Web.Http;

namespace Lesson01
{
    public class BinderConfig
    {
        static internal void Register(HttpConfiguration config)
        {
            config.BindParameter(typeof(DateTime), new DateTimeModelBinder());
            config.BindParameter(typeof(DateTime?), new DateTimeModelBinder());
        }
    }
}