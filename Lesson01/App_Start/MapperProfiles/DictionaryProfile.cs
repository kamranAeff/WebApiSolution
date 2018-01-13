using AutoMapper;
using Lesson01.Models;
using Lesson01.Models.Dto;

namespace Lesson01.App_Start.MapperProfiles
{
    public class DictionaryProfile
    {
        static public void Configure(IMapperConfigurationExpression map)
        {
            MapDto(map);
            MapDso(map);
        }

        static void MapDto(IMapperConfigurationExpression map)
        {
            map.CreateMap<BookletOfTalking, BookletOfTalkingDto>().ReverseMap();
        }

        static void MapDso(IMapperConfigurationExpression map)
        {
        }
    }
}