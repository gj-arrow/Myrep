﻿using System;
using System.Collections.Generic;
using Task.BLL.DTO;

namespace Task.BLL.Interfaces
{
    public interface IServices
    {
        PerformerDTO GetPerformer(int? id);
        IEnumerable<PerformerDTO> GetPerformers();
        SongDTO GetSong(int? id);
        IEnumerable<SongDTO> GetSongs();
        bool ParsingData();
        void Dispose();
    }
}
