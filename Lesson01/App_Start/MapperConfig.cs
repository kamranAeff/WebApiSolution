using AutoMapper;
using Lesson01.App_Start.MapperProfiles;
using System.Web.Http;

namespace Lesson01
{
    public class MapperConfig
    {
        static internal void Register(HttpConfiguration config)
        {
            Mapper.Initialize(map => { DictionaryProfile.Configure(map); });
        }
    }
}