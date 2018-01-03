using Newtonsoft.Json.Serialization;
using System.Net.Http.Formatting;
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

            //CamelCasePropertyNamesContractResolver -pascalcase
            //camelCasePropertyNamesContractResolver -camelcase

            //json formatter ucun naming convertion kimi camelcase* tetbiq edilir
            config.Formatters.JsonFormatter
                .SerializerSettings.ContractResolver
                = new CamelCasePropertyNamesContractResolver();


            return;


            //normalda XmlMediaTypeFormatter DataContractSerializer-den istifade olunur
            //Bunu XmlSerializer`le evez etmek ucun asagidaki kodu yaza bilerik
            //muqayiseye geldikde ise DataContractSerializer suret baximindan daha ustundur
            config.Formatters.XmlFormatter.UseXmlSerializer = true;

        }
    }
}