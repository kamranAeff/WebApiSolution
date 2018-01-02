using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Lesson01.MessageHandlers
{
    public class LocalizationMessageHandler : DelegatingHandler
    {
        private readonly List<string> _supportedLanguages = new List<string> { "az-Latin", "en-US" };

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            SetCulture(request);

            return base.SendAsync(request, cancellationToken);
        }

        private void SetCulture(HttpRequestMessage request)
        {
            foreach (var language in request.Headers.AcceptLanguage)
            {
                if (_supportedLanguages.Contains(language.Value))
                {
                    Thread.CurrentThread.CurrentCulture = Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(language.Value);
                    break;
                }
            }
        }
    }
}