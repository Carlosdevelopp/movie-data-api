namespace Infrastructure.DTO
{
    public class MoviesDTO
    {
        public string TituloMovie { get; set; }
        public string DescriptionMovie { get; set; }
        public int RunningMovie { get; set; }
        public DateTime ReleaseMovie { get; set; }
        public int GenreId { get; set; }
        public int AwardId { get; set; }
    }
}