using System;
using Task.DAL.Interfaces;
using Task.DAL.EF;
using Task.DAL.Entities;

namespace Task.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private EntityContext db;
        private PerformRepository performRepository;
        private SongRepository songRepository;
        private AccordRepository accordRepository;

        public EFUnitOfWork(string connectionString)
        {
            db = new EntityContext(connectionString);
        }
        public IRepository<Performer> Performers
        {
            get
            {
                if (performRepository == null)
                    performRepository = new PerformRepository(db);
                return performRepository;
            }
        }

        public IRepository<Song> Songs
        {
            get
            {
                if (songRepository == null)
                    songRepository = new SongRepository(db);
                return songRepository;
            }
        }

        public IRepository<Accord> Accords
        {
            get
            {
                if (accordRepository == null)
                    accordRepository = new AccordRepository(db);
                return accordRepository;
            }
        }


        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}