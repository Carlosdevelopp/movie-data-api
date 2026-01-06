namespace DataAccess.Models.Tables;

public class Movies
{
    public int MovieId { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int RunningTime {  get; set; }

    public DateTime Release { get; set; }
 
    public int GenreId { get; set; }

    public int AwardId { get; set; }

    public virtual Awards Awards { get; set; } = null!;
    public virtual Genres Genres { get; set; } = null!;
}
