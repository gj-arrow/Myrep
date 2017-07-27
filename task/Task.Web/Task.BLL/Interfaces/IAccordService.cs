using System;
using System.Collections.Generic;
using Task.BLL.DTO;

namespace Task.BLL.Interfaces
{
   public interface IAccordService
    {
        IEnumerable<string> GetNameAccrods();
        SongDTO SaveAccords(string[] accords, int idSong);
        void Dispose();
    }
}
