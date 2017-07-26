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
        public static void RegisterMappings()
        {
            Mapper.Initialize(cfg => {
                cfg.CreateMap<Accord, AccordDTO>().ReverseMap();
                cfg.CreateMap<Performer, PerformerDTO>().ReverseMap();
                cfg.CreateMap<Song, SongDTO>().ReverseMap();
            });
        }
    }

    public class SongProfileDTO : Profile
    {
        public SongProfileDTO()
        {
            CreateMap<Song, SongDTO>();
            CreateMap<SongDTO, Song>();
        }
    }

    public class AccordProfileDTO : Profile
    {
        public AccordProfileDTO()
        {
            CreateMap<Accord, AccordDTO>();
            CreateMap<AccordDTO, Accord>();
        }
    }

    public class PerformerProfileDTO : Profile
    {
        public PerformerProfileDTO()
        {
            CreateMap<Accord, AccordDTO>().ReverseMap();
            CreateMap<Performer, PerformerDTO>().ReverseMap();
            CreateMap<Song, SongDTO>().ReverseMap();
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