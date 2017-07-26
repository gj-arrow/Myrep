using System;
using Task.DAL.Entities;

namespace Task.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Performer> Performers { get; }
        IAccord Accords { get; }
        ISong Songs { get; }
        void Save();
    }
}
