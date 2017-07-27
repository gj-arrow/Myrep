using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.BLL.DTO
{
    public class PerformerDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UrlName { get; set; }
        public int Views { get; set; }
        public int CountOfSongs { get; set; }
        public string ShortBiography { get; set; }
        public string Biography { get; set; }
        public string UrlImage { get; set; }

        public IEnumerable<SongDTO> Songs { get; set; }

    }
}
