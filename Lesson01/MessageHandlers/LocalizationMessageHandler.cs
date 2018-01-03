using Lesson01.Constants;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Lesson01.MessageHandlers
{
    public class LocalizationMessageHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            SetCulture(request);

            return base.SendAsync(request, cancellationToken);
        }

        private void SetCulture(HttpRequestMessage request)
        {
            var supportedLanguages = Configurations.SupportedLanguages;
            foreach (var language in request.Headers.AcceptLanguage)
                if (supportedLanguages.Contains(language.Value))
                {
                    Thread.CurrentThread.CurrentCulture = Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(language.Value);
                    break;
                }
        }
    }
}