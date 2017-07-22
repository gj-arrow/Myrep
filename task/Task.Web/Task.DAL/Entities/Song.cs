using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.DAL.Entities
{
    public class Song
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public string Views { get; set; }
        public string UrlVideo { get; set; }

        public ICollection<Accord> Accords { get; set; }

        public Performer Performer { get; set; }
    }
}
