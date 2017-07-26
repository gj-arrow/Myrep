using System;
using System.Collections.Generic;
using Task.BLL.DTO;

namespace Task.BLL.Interfaces
{
   public interface IAccordServices
    {
        IEnumerable<string> GetNameAccrods();
        SongDTO SaveAccords(string[] arr, int idSong);
        void Dispose();
    }
}
