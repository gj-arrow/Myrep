using Task.BLL.DTO;
using Task.DAL.Entities;
using Task.DAL.Interfaces;
using System.Collections.Generic;
using Task.BLL.Interfaces;
using AutoMapper;
using Task.BLL.Infrastructure;

namespace Task.BLL.Services
{
    public class AccordService : IAccordServices
    {
        IUnitOfWork Database { get; set; }

        public AccordService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public IEnumerable<string> GetNameAccrods()
        {
            return Database.Accords.GetAllName();
        }

        public SongDTO SaveAccords(string[] arr, int idSong)
        {
            Database.Songs.DeleteAccords(idSong);
            Song updateSong = Database.Songs.AddAccords(arr, idSong);
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Performer, PerformerDTO>();
                cfg.CreateMap<Song, SongDTO>();
                cfg.CreateMap<Accord, AccordDTO>();
            });
            return Mapper.Map<Song, SongDTO>(updateSong);
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
