using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models.Tables
{
    public class Movies
    {
        public int MovieId { get; set; }
        public string Title { get; set; } 
        public string Description { get; set; }
        public int RunningTime {  get; set; }
        public DateTime Release { get; set; }
        public int AwardId { get; set; }
        public int GenreId { get; set; }
    }
}
