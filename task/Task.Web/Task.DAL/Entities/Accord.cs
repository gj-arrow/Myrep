using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.DAL.Entities
{
    public class Accord
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UrlImage { get; set; }

        public Song Song { get; set; }

    }
}
