using Lesson01.Models;
using Lesson01.Utils;
using Resources;
using System;
using System.Web.Http.Controllers;
using System.Web.Http.ModelBinding;

namespace Lesson01.Binders
{
    public class LocationModelBinder : IModelBinder
    {
        public bool BindModel(HttpActionContext actionContext, ModelBindingContext bindingContext)
        {
            if (bindingContext.ModelType != typeof(Location))
                return false;

            var val = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);

            if (val == null)
                return false;

            var key = val.RawValue as string;

            if (key == null)
            {
                bindingContext.ModelState.AddModelError(bindingContext.ModelName, WebApiResource.InvalidLocationValue);
                return false;
            }

            var parameters = key.Split(',');

            if (parameters.Length != 3)
            {
                bindingContext.ModelState.AddModelError(bindingContext.ModelName, WebApiResource.InvalidLocationValue);
                return false;
            }

            byte x = 0, y = 0, z = 0;

            if (Byte.TryParse(parameters.Get(0), out x) && Byte.TryParse(parameters.Get(1), out y) && Byte.TryParse(parameters.Get(2), out z))
            {
                bindingContext.Model = Location.Create(x, y, z);
                return true;
            }

            bindingContext.ModelState.AddModelError(bindingContext.ModelName, WebApiResource.InvalidLocationValue);
            return false;
        }
    }
}