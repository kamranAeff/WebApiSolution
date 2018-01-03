using System;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace Lesson01.Binders
{
    public class DateTimeParameterAttribute : ParameterBindingAttribute
    {
        public string DateFormat { get; set; }

        public bool ReadFromQueryString { get; set; }


        public override HttpParameterBinding GetBinding(
            HttpParameterDescriptor parameter)
        {
            if (parameter.ParameterType == typeof(DateTime?))
            {
                var binding = new DateTimeParameterBinding(parameter);

                binding.DateFormat = DateFormat;
                binding.ReadFromQueryString = ReadFromQueryString;

                return binding;
            }

            return parameter.BindAsError("Expected type DateTime?");
        }
    }
}