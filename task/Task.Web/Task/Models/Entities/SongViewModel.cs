using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Task.Web.Models
{
    public class SongViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public int Views { get; set; }
        public string UrlVideo { get; set; }

        public PerformerViewModel Performer { get; set; }
        public IEnumerable<AccordViewModel> Accords { get; set; }
    }
}