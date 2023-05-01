using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net_ef_videogame
{
    [Table("videogame")]
    internal class Videogame
    {
        [Key]
        public int VideogameId { get; set; }

        public string Name { get; set; }
        public string? Overview { get; set; }
    }
}
