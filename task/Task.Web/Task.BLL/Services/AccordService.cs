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
        IMapper _mapper;

        public AccordService(IUnitOfWork uow)
        {
            Database = uow;
            _mapper = AutoMapperConfigBLL.MapperConfiguration.CreateMapper();
        }

        public IEnumerable<string> GetNameAccrods()
        {
            return Database.Accords.GetAllName();
        }

        public SongDTO SaveAccords(string[] arr, int idSong)
        {
            Database.Songs.DeleteAccords(idSong);
            Song updateSong = Database.Songs.AddAccords(arr, idSong);
            return _mapper.Map<Song, SongDTO>(updateSong);
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
