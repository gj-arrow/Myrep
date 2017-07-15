using System;
using System.Collections.Generic;
using Task.BLL.DTO;

namespace Task.BLL.Interfaces
{
   public interface IPerformerService
    {
        PerformerDTO GetPerformer(int? id);
        IEnumerable<PerformerDTO> GetPerformers();
        void Dispose();
    }
}
