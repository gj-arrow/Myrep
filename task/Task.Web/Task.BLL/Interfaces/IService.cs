using System;
using System.Collections.Generic;
using Task.BLL.DTO;

namespace Task.BLL.Interfaces
{
    public interface IService<T>
    {
        T GetById(int? id);
        IEnumerable<T> GetAll();
        void Dispose();
    }
}
