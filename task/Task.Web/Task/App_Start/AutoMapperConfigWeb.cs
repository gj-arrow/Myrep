using System;
using System.Linq;
using System.Reflection;
using AutoMapper;
using Task.BLL.DTO;
using Task.Web.Models;

namespace Task.App_Start
{
    public static class AutoMapperConfigWeb
    {
        public static void RegisterMappings()
        {
            //Mapper.Initialize(cfg =>
            //{
            //    cfg.CreateMap<PerformerDTO, PerformerViewModel>();
            //    cfg.CreateMap<SongDTO, SongViewModel>();
            //});
            //    CreateMap<SongDTO, SongViewModel>().ReverseMap();
            //    CreateMap<AccordDTO, AccordViewModel>().ReverseMap();
            //    CreateMap<PerformerDTO, PerformerViewModel>().ReverseMap();
            //} 

            //Mapper.Initialize(x =>
            //{
            //    var types = Assembly.GetAssembly(typeof(PerformerProfile)).GetTypes()
            //        .Where(t => t != typeof(Profile) && typeof(Profile).IsAssignableFrom(t) && !t.IsAbstract);

            //    foreach (var type in types)
            //    {
            //        x.AddProfile((Profile)Activator.CreateInstance(type));
            //    }
            //});

            Mapper.Initialize(cfg => cfg.AddProfile(new PerformerProfile()));

            //Mapper.Initialize(cfg => {
            //    cfg.CreateMap<SongDTO, SongViewModel>()
            //       .ReverseMap();
            //    cfg.CreateMap<AccordDTO, AccordViewModel>()
            //       .ReverseMap();
            //    cfg.CreateMap<PerformerDTO, PerformerViewModel>()
            //       .ReverseMap();
            //});
            //    var config = new MapperConfiguration(cfg =>
            //    {
            //        cfg.AddProfile(new PerformerProfile());
            //    });

            //    Mapper = config.CreateMapper();
            //    config.AssertConfigurationIsValid();
            //}

            // Mapper.Initialize(c => c.AddProfile<MappingProfile>());
        }
    }

        public class SongProfile : Profile
        {
            public SongProfile()
            {
                CreateMap<SongDTO, SongViewModel>();
                CreateMap<SongViewModel, SongDTO>();
            }
        }

        public class AccordProfile : Profile
        {
            public AccordProfile()
            {
                CreateMap<AccordDTO, AccordViewModel>();
                CreateMap<AccordViewModel, AccordDTO>();
            }
        }

        public class PerformerProfile : Profile
        {
            public PerformerProfile()
            {
                CreateMap<AccordDTO, AccordViewModel>().ReverseMap();
                CreateMap<PerformerDTO, PerformerViewModel>().ReverseMap();
                CreateMap<SongDTO, SongViewModel>().ReverseMap();
            }
        }
}