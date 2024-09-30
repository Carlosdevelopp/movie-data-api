using DataAccess.Contract;
using DataAccess.Models.Tables;
using Infrastructure.Contract;
using Infrastructure.DTO;
using Infrastructure.Utils;

namespace Infrastructure.Implementation
{
    public class MoviesInfrastructure : IMoviesInfrastructure
    {
        private readonly IMoviesDataAccess _moviesDA;

        public MoviesInfrastructure(IMoviesDataAccess moviesDA)
        {
            _moviesDA = moviesDA;
        }

        #region GET
        //This method retrives a movie by its ID and converts it into a MoviesDTO object
        public MoviesDTO GetMovie(int MovieId)
        {
            Movies movie = _moviesDA.GetMovie(MovieId);

            MoviesDTO movieDTO = new MoviesDTO
            {
                TituloMovie = movie.Title,
                DescriptionMovie = movie.Description,
                RunningMovie = movie.RunningTime,
                ReleaseMovie = movie.Release,
                GenreId = movie.GenreId,
                AwardId = movie.AwardId,
            };

            return movieDTO;
        }

        //This method retrives a list all movies and the convert at MoviesDTO objects
        public List<MoviesDTO> GetMovies()
        {
            List<Movies> movies = _moviesDA.GetMovies();

            List<MoviesDTO> moviesDTOs = movies.Select(o => new MoviesDTO
            {
                TituloMovie = o.Title,
                DescriptionMovie = o.Description,
                RunningMovie = o.RunningTime,
                ReleaseMovie = o.Release,
                GenreId = o.GenreId,
                AwardId = o.AwardId
            }).ToList();

            return moviesDTOs;
        }

        //This method gets details of a movie by its ID and convert AwardsDTO object 
        public AwardsDTO GetMovieDetails(int MovieId)
        {
            Movies movies = _moviesDA.GetMovieDetails(MovieId);

            AwardsDTO _movies = new AwardsDTO
            {
                TitleMovie = movies.Title,
                DescriptionMovie = movies.Description,
                RunningTimeMovie = movies.RunningTime.ToString(),
                ReleaseMovie = movies.Release.ToString(),
                Genre = movies.Genres.Genre,
                Award = movies.Awards.AwardTitle
            };

            return _movies;
        }

        //This method gets a list movies with detailded information and the convert at at AwardsDTO objects
        public List<AwardsDTO> GetMoviesDetails()
        {
            List<Movies> movies = _moviesDA.GetMoviesDetails();

            List<AwardsDTO> _movies = (from u in movies
                                       select new AwardsDTO
                                       {
                                           TitleMovie = u.Title.FormatTitle(),
                                           DescriptionMovie = u.Description.ToUpper(),
                                           ReleaseMovie = u.Release.ShortDate(),
                                           RunningTimeMovie = u.RunningTime.FormatTime(),
                                           Genre = u.Genres.Genre,
                                           Award = u.Awards.AwardTitle
                                       }).ToList();

            return _movies;
        }
        #endregion

        #region POST
        //This method insert a movie at the database using data from MoviesInsertDTO object
        public void InsertMovie(MoviesInsertDTO moviesInsertDTO)
        {
            Movies movie = new();
            {
                movie.Title = moviesInsertDTO.TitleMovie;
                movie.Description = moviesInsertDTO.DescriptionMovie;
                movie.RunningTime = moviesInsertDTO.RunningTimeMovie;
                movie.Release = moviesInsertDTO.ReleaseMovie;
                movie.GenreId = moviesInsertDTO.Genre;
                movie.AwardId = moviesInsertDTO.Award;
            }
            _moviesDA.InsertMovie(movie);
        }
        #endregion

        #region PUT
        //This method updates an existing movie in the database using data from the MoviesUpdateDTO object
        public void UpdateMovie(MoviesUpdateDTO moviesUpdateDTO)
        {
            Movies movies = new();
            {
                movies.MovieId = moviesUpdateDTO.MovieId;
                movies.Title = moviesUpdateDTO.TitleMovie;
                movies.Description = moviesUpdateDTO.DescriptionMovie;
                movies.RunningTime = moviesUpdateDTO.RunningTimeMovie;
                movies.Release = moviesUpdateDTO.ReleaseMovie;
                movies.GenreId = moviesUpdateDTO.GenreId;
                movies.AwardId = moviesUpdateDTO.AwardId;

                _moviesDA.UpdateMovie(movies);
            }
        }
        #endregion

        #region DELETE
        // This method deletes a movie from the database using the provided movieId.
        public void DeleteMovie(int movieId)
        {
            _moviesDA.DeleteMovie(movieId);
        }
        #endregion
    }
}
