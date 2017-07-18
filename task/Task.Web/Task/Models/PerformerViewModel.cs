using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Task.Web.Models
{
    public class PerformerViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UrlName { get; set; }
        public string Views { get; set; }
        public string CountOfSongs { get; set; }
        public string ShortBiography { get; set; }
        public string Biography { get; set; }
        public string UrlImage { get; set; }

        public IEnumerable<SongViewModel> Song { get; set; }
    }
}