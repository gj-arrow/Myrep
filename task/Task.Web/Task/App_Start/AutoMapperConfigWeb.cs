using System;
using System.Linq;
using System.Reflection;
using AutoMapper;
using Task.BLL.DTO;
using Task.Web.Models;

namespace Task.App_Start
{
    public class AutoMapperConfigWeb
    {
        public static MapperConfiguration MapperConfiguration;
        public static void RegisterMappings()
        {
            MapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AccordDTO, AccordViewModel>().ReverseMap();
                cfg.CreateMap<PerformerDTO, PerformerViewModel>().ReverseMap();
                cfg.CreateMap<SongDTO, SongViewModel>().ReverseMap();
            });
        }
    }
}