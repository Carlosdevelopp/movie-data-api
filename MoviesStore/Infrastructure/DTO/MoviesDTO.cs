using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DTO
{
    public class MoviesDTO
    {
        public string TituloM { get; set; }
        public string DescriptionM { get; set; }
        public int RunningM { get; set; }
        public DateTime ReleaseM { get; set; }
        public int Genre { get; set; }
        public int Award { get; set; }
    }
}