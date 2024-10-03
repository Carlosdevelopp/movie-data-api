using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models.Tables
{
    public class Movies
    {
        public int MovieId { get; set; }

        [Required]
        public string Title { get; set; } 
        public string Description { get; set; }
        public int RunningTime {  get; set; }
        public DateTime Release { get; set; }
        public int GenreId { get; set; }
        public int AwardId { get; set; }

        public  virtual Awards Awards { get; set; }
        public virtual Genres Genres { get; set; }
    }
}
