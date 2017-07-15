using System.Collections.Generic;
using System.Data.Entity;
using Task.DAL.Interfaces;
using Task.DAL.EF;
using Task.DAL.Entities;

namespace Task.DAL.Repositories
{
    public class AccordRepository : IRepository<Accord>
    {
        private EntityContext db;

        public AccordRepository(EntityContext context)
        {
            this.db = context;
        }

        public IEnumerable<Accord> GetAll()
        {
            return db.Accords;
        }

        public Accord Get(int id)
        {
            return db.Accords.Find(id);
        }

        public void Create(Accord accord)
        {
            db.Accords.Add(accord);
        }

        public void Update(Accord accord)
        {
            db.Entry(accord).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Accord accord = db.Accords.Find(id);
            if (accord != null)
                db.Accords.Remove(accord);
        }
    }
}