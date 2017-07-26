using System.Collections.Generic;
using Task.DAL.Entities;

namespace Task.DAL.Interfaces
{
    public interface IAccord:IRepository<Accord>
    {
        IEnumerable<string> GetAllName();
    }
}
