using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        IEnumerable<string> GetAllName();
        T Get(int id);
        void DeleteObjField(int id);
        T SaveObjField(string[] strElements , int idSong);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
    }
}
