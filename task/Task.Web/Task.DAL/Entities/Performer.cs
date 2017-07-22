using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.DAL.Entities
{
    public class Performer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UrlName { get; set; }
        public string Views { get; set; }
        public string CountOfSongs { get; set; }
        public string ShortBiography { get; set; }
        public string Biography { get; set; }
        public string UrlImage { get; set; }

        public ICollection<Song> Songs { get; set; }
    }

}
