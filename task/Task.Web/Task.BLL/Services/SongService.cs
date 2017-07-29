using Task.BLL.DTO;
using Task.DAL.Entities;
using Task.DAL.Interfaces;
using Task.BLL.Infrastructure;
using System.Collections.Generic;
using Task.BLL.Interfaces;
using AutoMapper;
using System.Linq;


namespace Task.BLL.Services
{
    public class SongService : ISongService
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
             //   song = Database.Songs.GetFirst(id.Value);
            throw new ValidationException("Исполнитель не найден", "");
            return _mapper.Map<Song, SongDTO>(song);
        }


       public List<int> GetRangeById(int idSong, string sort) {
            var idPerformer = Database.Songs.Get(idSong).Performer.Id;
            var lsRangeId = Database.Songs.GetRangeIdBySort(idPerformer,sort);
            return lsRangeId;
        }

        public IEnumerable<SongDTO> GetAll()
        {
            return _mapper.Map<IEnumerable<Song>, List<SongDTO>>(Database.Songs.GetAll());
        }

        public IEnumerable<SongDTO> Sort(string sort, IEnumerable<SongDTO> songs)
        {
            var query = songs;
            switch (sort)
            {
                case "ascName":
                    query = query.OrderBy(n => n.Name);
                    break;
                case "descName":
                    query = query.OrderByDescending(n => n.Name);
                    break;
                case "ascView":
                    query = query.OrderBy(v => v.Views);
                    break;
                case "descView":
                    query = query.OrderByDescending(v => v.Views);
                    break;
                default:
                    break;
            }
            return query;
        }



        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
