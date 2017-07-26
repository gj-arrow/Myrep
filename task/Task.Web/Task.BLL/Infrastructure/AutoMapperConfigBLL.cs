using System;
using System.Linq;
using System.Reflection;
using AutoMapper;
using Task.BLL.DTO;
using Task.DAL.Entities;

namespace Task.BLL.Infrastructure
{
    public class AutoMapperConfigBLL
    {
        public static MapperConfiguration MapperConfiguration;
        public static void RegisterMappings()
        {
            MapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Performer, PerformerDTO>().ReverseMap();
                cfg.CreateMap<Song, SongDTO>().ReverseMap();
                cfg.CreateMap<Accord, AccordDTO>().ReverseMap();
            });
        }
    }
}
//public static void Configure()
//{
//    Mapper.Initialize(x =>
//    {
//        var types = Assembly.GetAssembly(typeof(PerformerProfile)).GetTypes()
//            .Where(t => t != typeof(Profile) && typeof(Profile).IsAssignableFrom(t) && !t.IsAbstract);

//        foreach (var type in types)
//        {
//            x.AddProfile((Profile)Activator.CreateInstance(type));
//        }
//    });
//}