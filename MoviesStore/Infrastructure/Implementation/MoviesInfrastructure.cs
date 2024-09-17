using DataAccess.Contract;
using DataAccess.Models.Tables;
using Infrastructure.Contract;
using Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        //Get a record (syntax)
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

        //Get a list of record (Method syntax) 
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

        //Get a list of details
        public List<AwardsDTO> GetMoviesDetails()
        {
            List<Movies> movies = _moviesDA.GetMoviesDetails();

            List<AwardsDTO> _movies = (from u in movies
                                       select new AwardsDTO
                                       {
                                           TitleMovie = u.Title,
                                           DescriptionMovie = u.Description,
                                           ReleaseMovie = u.Release.ToString(),
                                           RunningTimeMovie = u.RunningTime.ToString(),
                                           Genre = u.Genres.Genre,
                                           Award = u.Awards.AwardTitle
                                       }).ToList();

            return _movies;
        }
        #endregion
    }
}
