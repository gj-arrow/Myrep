using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.BLL.DTO;

namespace Task.BLL.Interfaces
{
    public interface IPerformerService : IService<PerformerDTO>
    {
       IEnumerable<PerformerDTO> Sort(string sort, IEnumerable<PerformerDTO> performers);
    }
}
