using System;
using System.Web.Http;
using System.Web.Http.ModelBinding;

namespace Lesson01.Binders
{
    public class DateTimeModelBinderProvider : ModelBinderProvider
    {
        readonly DateTimeModelBinder binder = new DateTimeModelBinder();

        public override IModelBinder GetBinder(HttpConfiguration configuration, Type modelType)
        {
            if (DateTimeModelBinder.CanBindType(modelType))
                return binder;

            return null;
        }
    }
}