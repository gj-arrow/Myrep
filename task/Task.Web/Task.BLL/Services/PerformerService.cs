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

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
