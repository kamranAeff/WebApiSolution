using Lesson01.MessageHandlers;
using System.Web.Http;

namespace Lesson01
{
    public class HandlerConfig
    {
        static internal void Register(HttpConfiguration config)
        {
            config.MessageHandlers.Add(new LocalizationMessageHandler());
        }
    }
}