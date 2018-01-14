using Lesson01.Binders;
using Lesson01.Models;
using System;
using System.Web.Http;
using System.Web.Http.ModelBinding.Binders;

namespace Lesson01
{
    public class BinderConfig
    {
        static internal void Register(HttpConfiguration config)
        {
            config.BindParameter(typeof(DateTime), new DateTimeModelBinder());
            config.BindParameter(typeof(DateTime?), new DateTimeModelBinder());

            //----------------------------

            config.BindParameter(typeof(Location), new LocationModelBinder());
        }
    }
}