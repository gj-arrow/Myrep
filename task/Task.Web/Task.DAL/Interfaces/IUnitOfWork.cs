using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.DAL.Entities;

namespace Task.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Accord> Accords { get; }
        IRepository<Performer> Performers { get; }
        IRepository<Song> Songs { get; }
        void Save();
    }
}
