using Lesson01.Utils;
using System;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Metadata;

namespace Lesson01.Binders
{
    public class DateTimeParameterBinding : HttpParameterBinding
    {
        public string DateFormat { get; set; }

        public bool ReadFromQueryString { get; set; }


        public DateTimeParameterBinding(HttpParameterDescriptor descriptor)
            : base(descriptor) { }

        public override Task ExecuteBindingAsync(ModelMetadataProvider metadataProvider,HttpActionContext actionContext,CancellationToken cancellationToken)
        {
            string dateToParse = null;
            string paramName = this.Descriptor.ParameterName;

            if (ReadFromQueryString)
            {
                // reading from query string
                var nameVal = actionContext.Request.GetQueryNameValuePairs();
                dateToParse = nameVal.Where(q => q.Key.Equals(paramName))
                                     .FirstOrDefault().Value;
            }
            else
            {
                // reading from route
                var routeData = actionContext.Request.GetRouteData();
                object dateObj = null;
                if (routeData.Values.TryGetValue(paramName, out dateObj))
                {
                    dateToParse = Convert.ToString(dateObj);
                }
            }

            DateTime? dateTime = null;
            if (!string.IsNullOrEmpty(dateToParse))
            {
                if (string.IsNullOrEmpty(DateFormat))
                    dateTime = dateToParse.ExtractDateFromString();
                else
                    dateTime = dateToParse.ExtractDateFromString(DateFormat);
            }

            SetValue(actionContext, dateTime);

            return Task.FromResult<object>(null);
        }
        
    }
}