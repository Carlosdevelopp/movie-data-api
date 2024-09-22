using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DTO
{
    public class MoviesUpdateDTO
    {
        public int MovieId { get; set; }
        public string TitleMovie { get; set; }
        public string DescriptionMovie { get; set; }
        public DateTime ReleaseMovie { get; set; }
        public int RunningTimeMovie { get; set; }
        public int GenreId { get; set; }
        public int AwardId { get; set; }
    }
}
