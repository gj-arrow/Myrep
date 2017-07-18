using System;
using System.Collections.Generic;
using Task.BLL.DTO;

namespace Task.BLL.Interfaces
{
    public interface IServices
    {
        PerformerDTO GetPerformer(int? id);
        SongDTO GetSong(int? id);
        IEnumerable<PerformerDTO> GetPerformers();
        bool ParsingData();
        void Dispose();
    }
}
