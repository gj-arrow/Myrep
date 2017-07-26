//using System;
//using System.Linq;
//using System.Reflection;
//using AutoMapper;
//using Task.BLL.DTO;
//using Task.Web.Models;
//using Task.
//namespace Task.App_Start
//{
//    public class AutoMapperConfigDTO
//    {
//        public static void RegisterMappings()
//        {
//            //Mapper.Initialize(cfg =>
//            //{
//            //    cfg.CreateMap<PerformerDTO, PerformerViewModel>();
//            //    cfg.CreateMap<SongDTO, SongViewModel>();
//            //});
//            //    CreateMap<SongDTO, SongViewModel>().ReverseMap();
//            //    CreateMap<AccordDTO, AccordViewModel>().ReverseMap();
//            //    CreateMap<PerformerDTO, PerformerViewModel>().ReverseMap();
//            //} 

//            //Mapper.Initialize(x =>
//            //{
//            //    var types = Assembly.GetAssembly(typeof(PerformerProfile)).GetTypes()
//            //        .Where(t => t != typeof(Profile) && typeof(Profile).IsAssignableFrom(t) && !t.IsAbstract);

//            //    foreach (var type in types)
//            //    {
//            //        x.AddProfile((Profile)Activator.CreateInstance(type));
//            //    }
//            //});

//            Mapper.Initialize(cfg => cfg.AddProfile(new PerformerProfile()));

//            //Mapper.Initialize(cfg => {
//            //    cfg.CreateMap<SongDTO, SongViewModel>()
//            //       .ReverseMap();
//            //    cfg.CreateMap<AccordDTO, AccordViewModel>()
//            //       .ReverseMap();
//            //    cfg.CreateMap<PerformerDTO, PerformerViewModel>()
//            //       .ReverseMap();
//            //});
//            //    var config = new MapperConfiguration(cfg =>
//            //    {
//            //        cfg.AddProfile(new PerformerProfile());
//            //    });

//            //    Mapper = config.CreateMapper();
//            //    config.AssertConfigurationIsValid();
//            //}

//            // Mapper.Initialize(c => c.AddProfile<MappingProfile>());
//        }
//    }

//    public class SongProfileDTO : Profile
//    {
//        public SongProfileDTO()
//        {
//            CreateMap<Song, SongDTO>();
//            CreateMap<SongDTO, Song>();
//        }
//    }

//    public class AccordProfileDTO : Profile
//    {
//        public AccordProfileDTO()
//        {
//            CreateMap<Accord, AccordDTO>();
//            CreateMap<AccordDTO, Accord>();
//        }
//    }

//    public class PerformerProfileDTO : Profile
//    {
//        public PerformerProfileDTO()
//        {
//            CreateMap<Accord, AccordDTO>().ReverseMap();
//            CreateMap<Performer, PerformerDTO>().ReverseMap();
//            CreateMap<Song, SongDTO>().ReverseMap();
//        }
//    }
//}

////public static void Configure()
////{
////    Mapper.Initialize(x =>
////    {
////        var types = Assembly.GetAssembly(typeof(PerformerProfile)).GetTypes()
////            .Where(t => t != typeof(Profile) && typeof(Profile).IsAssignableFrom(t) && !t.IsAbstract);

////        foreach (var type in types)
////        {
////            x.AddProfile((Profile)Activator.CreateInstance(type));
////        }
////    });
////}