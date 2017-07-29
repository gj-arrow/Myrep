using System;
using Task.DAL.Entities;
using System.Collections.Generic;

namespace Task.DAL.Interfaces
{
   public interface ISong:IRepository<Song>
    {
        void DeleteAccords(int idSong);
        Song AddAccords(string[] elements, int idSong);
        List<int> GetRangeIdBySort(int idPerformer , string sort);
    }
}
