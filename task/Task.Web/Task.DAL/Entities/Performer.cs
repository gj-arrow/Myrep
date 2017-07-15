﻿using System;
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
        public int Views { get; set; }
        public int CountOfSongs { get; set; }

        public ICollection<Song> Song { get; set; }
    }

}
