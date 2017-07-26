using System;
using Task.DAL.Entities;

namespace Task.DAL.Interfaces
{
   public interface ISong:IRepository<Song>
    {
        void DeleteAccords(int idSong);
        Song AddAccords(string[] elements, int idSong);
    }
}
