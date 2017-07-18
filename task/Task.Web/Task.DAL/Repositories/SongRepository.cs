using System.Collections.Generic;
using System.Data.Entity;
using Task.DAL.Interfaces;
using Task.DAL.EF;
using Task.DAL.Entities;
using System.Linq;

namespace Task.DAL.Repositories
{
    public class SongRepository : IRepository<Song>
    {
        private EntityContext db;

        public SongRepository(EntityContext context)
        {
            this.db = context;
        }

        public IEnumerable<Song> GetAll()
        {
            return db.Songs;
        }

        public Song Get(int id)
        {
            return db.Songs.Include("Performer").Include("Accords").Where(p => p.Id == id).FirstOrDefault();
        }

        public void Create(Song song)
        {
            db.Songs.Add(song);
        }

        public void Update(Song song)
        {
            db.Entry(song).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Song song = db.Songs.Find(id);
            if (song != null)
                db.Songs.Remove(song);
        }
    }
}