using Task.BLL.DTO;
using Task.DAL.Entities;
using Task.DAL.Interfaces;
using Task.BLL.Infrastructure;
using System.Collections.Generic;
using Task.BLL.Interfaces;
using AutoMapper;


namespace Task.BLL.Services
{
    public class SongService : IServices<SongDTO>
    {
        IUnitOfWork Database { get; set; }
        IMapper _mapper;

        public SongService(IUnitOfWork uow)
        {
            Database = uow;
            _mapper = AutoMapperConfigBLL.MapperConfiguration.CreateMapper();
        }

        public SongDTO GetById(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id исполнителя", "");
            var song = Database.Songs.Get(id.Value);
            if (song == null)
                throw new ValidationException("Исполнитель не найден", "");
            return _mapper.Map<Song, SongDTO>(song);
        }

        public IEnumerable<SongDTO> GetAll()
        {
            return _mapper.Map<IEnumerable<Song>, List<SongDTO>>(Database.Songs.GetAll());
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
