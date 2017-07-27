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