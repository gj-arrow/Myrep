using Task.BLL.DTO;
using Task.DAL.Entities;
using Task.DAL.Interfaces;
using Task.BLL.Infrastructure;
using System.Collections.Generic;
using Task.BLL.Interfaces;
using System.Linq;
using AutoMapper;

namespace Task.BLL.Services
{
    public class PerformerService : IPerformerService
    {
        IUnitOfWork Database { get; set; }
        IMapper _mapper;

        public PerformerService(IUnitOfWork uow)
        {
            Database = uow;
            _mapper = AutoMapperConfigBLL.MapperConfiguration.CreateMapper();
        }

        public IEnumerable<PerformerDTO> GetAll()
        {
            var performers = Database.Performers.GetAll();
            return _mapper.Map<IEnumerable<Performer>, List<PerformerDTO>>(performers);
        }

        public PerformerDTO GetById(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id исполнителя", "");
            var performer = Database.Performers.Get(id.Value);
            if (performer == null)
                throw new ValidationException("Исполнитель не найден", "");
            return _mapper.Map<Performer, PerformerDTO>(performer);
        }

        public IEnumerable<PerformerDTO> Sort(string sort, IEnumerable<PerformerDTO> performers) {
            var query = performers;
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
                case "ascSongs":
                    query = query.OrderBy(v => v.CountOfSongs);
                    break;
                case "descSongs":
                    query = query.OrderByDescending(v => v.CountOfSongs);
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
