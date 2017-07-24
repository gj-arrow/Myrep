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

        public IEnumerable<string> GetAllName()
        {
            return db.Accords.Select(x => x.Name).Distinct();
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

        public Song SaveObjField(string[] strElements, int idSong)
        {
            List<Accord> temp = new List<Accord>();
            Song song = db.Songs.Include("Performer").Include("Accords").Where(i => i.Id == idSong).FirstOrDefault();
            if (song != null && strElements != null)
            {
                foreach (var item in strElements)
                {
                    temp.Add(db.Accords.Where(n => n.Name == item.TrimStart()).FirstOrDefault());
                }
                foreach (var item in temp)
                    {
                    Accord accord = new Accord();
                        accord.Name = item.Name;
                        accord.UrlImage = item.UrlImage;
                        accord.Song = song;
                        db.Accords.Add(accord);
                     }
                    db.SaveChanges();       
            }
            return song;
        }

        public void DeleteObjField(int idSong)
        {
            IEnumerable<Accord> deletedAcc = db.Accords.Where(i => i.Song.Id == idSong);
            if (deletedAcc != null)
            {
                foreach (var item in deletedAcc)
                {
                    db.Accords.Remove(item);
                }
                db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            Song song = db.Songs.Find(id);
            if (song != null)
                db.Songs.Remove(song);
        }
    }
}