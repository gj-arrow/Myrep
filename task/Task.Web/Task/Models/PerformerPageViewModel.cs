using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Task.Web.Models
{
    public class PerformerPageViewModel
    {
        public IEnumerable<PerformerViewModel> Performers {get; set;}
        public PageInfo PageInfo { get; set; }
        public string CurrentSort { get; set; }
    }
}