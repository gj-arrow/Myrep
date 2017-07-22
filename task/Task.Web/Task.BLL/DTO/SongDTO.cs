using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.BLL.DTO
{
    public class SongDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public string Views { get; set; }
        public string UrlVideo { get; set; }

        public PerformerDTO Performer { get; set; }
        public ICollection<AccordDTO> Accords { get; set; }
    }
}
