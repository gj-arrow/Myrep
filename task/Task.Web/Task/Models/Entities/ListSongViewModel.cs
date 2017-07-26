using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Task.Web.Models
{
    public class ListSongViewModel
    {
        public PerformerViewModel Performer { get; set; }
        public IEnumerable<SongViewModel> Songs { get; set; }
        public PageInfo PageInfo { get; set; }   
    }
}