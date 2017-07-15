using Task.BLL.DTO;
using Task.DAL.Entities;
using Task.DAL.Interfaces;
using Task.BLL.Infrastructure;
using Task.BLL.Interfaces;
using System.Collections.Generic;
using AutoMapper;

namespace Task.BLL.Services
{
    public class PerformerService : IPerformerService
    {
        IUnitOfWork Database { get; set; }

        public PerformerService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public IEnumerable<PerformerDTO> GetPerformers()
        {
            // применяем автомаппер для проекции одной коллекции на другую
            Mapper.Initialize(cfg => cfg.CreateMap<Performer, PerformerDTO>());
            return Mapper.Map<IEnumerable<Performer>, List<PerformerDTO>>(Database.Performers.GetAll());
        }

        public PerformerDTO GetPerformer(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id исполнителя", "");
            var performer = Database.Performers.Get(id.Value);
            if (performer == null)
                throw new ValidationException("Исполнитель не найден", "");
            // применяем автомаппер для проекции Performer на PerformerDTO
            Mapper.Initialize(cfg => cfg.CreateMap<Performer, PerformerDTO>());
            return Mapper.Map<Performer, PerformerDTO>(performer);
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}