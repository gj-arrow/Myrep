using System.Collections.Generic;
using System.Data.Entity;
using Task.DAL.Interfaces;
using Task.DAL.EF;
using Task.DAL.Entities;
using System.Linq;

namespace Task.DAL.Repositories
{
    public class SongRepository : ISong
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

        public Song Get(int idSong)
        {
            return db.Songs.Include("Performer").Include("Accords").Where(p => p.Id == idSong).FirstOrDefault();
        }

        public List<int> GetRangeIdBySort(int idPerformer , string sort)
        {
            if (sort == null) sort = "ascName";
             List<int> range = new List<int>();
            var query = db.Songs.Where(s => s.Performer.Id == idPerformer);

            switch (sort)
            {
                case "ascName":
                    query = query.OrderBy(n => n.Name);
                    break;
                case "descName":
                    query = query.OrderByDescending(n => n.Name);
                    break;
                case "ascView":
                    query = query.OrderBy(v => v.Views);
                    break;
                case "descView":
                    query = query.OrderByDescending(v => v.Views);
                    break;
                default:
                    break;
            }
            range = query.Select(i => i.Id).ToList();
            return range;
        }

        public void Create(Song song)
        {
            db.Songs.Add(song);
        }

        public void Update(Song song)
        {
            db.Entry(song).State = EntityState.Modified;
        }

        public Song AddAccords(string[] elements, int idSong)
        {
            List<Accord> temp = new List<Accord>();
            Song song = db.Songs.Include("Performer").Include("Accords").Where(i => i.Id == idSong).FirstOrDefault();
            if (song != null && elements[0] !="" )
            {
                foreach (var item in elements)
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

        public void DeleteAccords(int idSong)
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