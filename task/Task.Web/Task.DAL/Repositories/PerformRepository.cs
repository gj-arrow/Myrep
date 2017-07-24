using System.Collections.Generic;
using System.Data.Entity;
using Task.DAL.Interfaces;
using Task.DAL.EF;
using Task.DAL.Entities;
using System.Linq;

namespace Task.DAL.Repositories
{
    public class PerformRepository : IRepository<Performer>
    {
        private EntityContext db;

        public PerformRepository(EntityContext context)
        {
            this.db = context;
        }

        public IEnumerable<Performer> GetAll()
        {
            return db.Performers.Include("Songs");
        }

        public IEnumerable<string> GetAllName()
        {
            return db.Performers.Select(x => x.Name).Distinct();
        }

        public Performer Get(int id)
        {
            Performer performer = db.Performers.Include("Songs").Where(p => p.Id == id).FirstOrDefault();
            return performer;
        }

        public void Create(Performer performer)
        {
            db.Performers.Add(performer);
        }

        public void Update(Performer performer)
        {
            db.Entry(performer).State = EntityState.Modified;
        }

        public void DeleteObjField(int idPerformer)
        {

        }
        public Performer SaveObjField(string[] strElements, int id)
        {
            return new Performer();
        }


        public void Delete(int id)
        {
            Performer performer = db.Performers.Find(id);
            if (performer != null)
                db.Performers.Remove(performer);
        }
    }
}