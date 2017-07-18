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
        public string Views { get; set; }

        public PerformerViewModel Performer { get; set; }
        public ICollection<AccordViewModel> Accords { get; set; }
    }
}