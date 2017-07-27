using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.BLL.DTO;

namespace Task.BLL.Interfaces
{
   public interface ISongService : IService<SongDTO>
    {
        IEnumerable<SongDTO> Sort(string sort, IEnumerable<SongDTO> songs);
    }
}
