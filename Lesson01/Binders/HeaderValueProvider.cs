using Newtonsoft.Json;
using System.Globalization;
using System.Linq;
using System.Net.Http.Headers;
using System.Web.Http.ValueProviders;

namespace Lesson01.Binders
{
    public class HeaderValueProvider<T> : IValueProvider
        where T : class
    {
        private readonly HttpRequestHeaders headers;
        
        public HeaderValueProvider(HttpRequestHeaders headers)
        {
            this.headers = headers;
        }

        public bool ContainsPrefix(string prefix)
        {
            return headers.Any(header => header.Key.Contains(prefix));
        }

        public ValueProviderResult GetValue(string key)
        {
            var contains = ContainsPrefix(key);

            if (!contains)
                return null;

            var value = headers.GetValues(key).First();

            var rawValue = JsonConvert.DeserializeObject<T>(value, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Include });

            return new ValueProviderResult(rawValue, value, CultureInfo.InvariantCulture);
        }
    }
}