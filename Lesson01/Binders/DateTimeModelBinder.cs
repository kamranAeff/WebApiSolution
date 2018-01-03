using Lesson01.Utils;
using System;
using System.Web.Http.Controllers;
using System.Web.Http.ModelBinding;

namespace Lesson01.Binders
{
    public class DateTimeModelBinder : IModelBinder
    {
        public bool BindModel(HttpActionContext actionContext, ModelBindingContext bindingContext)
        {
            ValidateBindingContext(bindingContext);

            if (!bindingContext.ValueProvider.ContainsPrefix(bindingContext.ModelName) || !CanBindType(bindingContext.ModelType))
                return false;

            var modelName = bindingContext.ModelName;
            if (string.IsNullOrWhiteSpace(modelName))
                return false;

            var attemptedValue = bindingContext.ValueProvider.GetValue(modelName).AttemptedValue;

            try
            {
                bindingContext.Model = attemptedValue.ExtractDateFromString();
            }
            catch (FormatException e)
            {
                bindingContext.ModelState.AddModelError(modelName, e);
            }

            return true;
        }

        private static void ValidateBindingContext(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
                throw new ArgumentNullException("bindingContext");

            if (bindingContext.ModelMetadata == null)
                throw new ArgumentException("ModelMetadata cannot be null", "bindingContext");
        }

        public static bool CanBindType(Type modelType)
        {
            return modelType == typeof(DateTime) || modelType == typeof(DateTime?);
        }
    }
}