using Task.BLL.DTO;
using Task.DAL.Entities;
using Task.DAL.Interfaces;
using Task.BLL.Infrastructure;
using System.Collections.Generic;
using Task.BLL.Interfaces;
using AutoMapper;

namespace Task.BLL.Services
{
    public class PerformerService : IServices<PerformerDTO>
    {
        IUnitOfWork Database { get; set; }

        public PerformerService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public IEnumerable<PerformerDTO> GetAll()
        {
            var performers = Database.Performers.GetAll();
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Performer, PerformerDTO>();
                cfg.CreateMap<Song, SongDTO>();
            });
            return Mapper.Map<IEnumerable<Performer>, List<PerformerDTO>>(performers);
        }

        public PerformerDTO GetById(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id исполнителя", "");
            var performer = Database.Performers.Get(id.Value);
            if (performer == null)
                throw new ValidationException("Исполнитель не найден", "");
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Performer, PerformerDTO>();
                cfg.CreateMap<Song, SongDTO>();
            });
            return Mapper.Map<Performer, PerformerDTO>(performer);
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
