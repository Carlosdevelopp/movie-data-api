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
        //Get a record Movies by (syntax)
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

        //Get a list of records Movies
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
        
        //Get a record 
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

        //Get a list of records 
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

        #region POST
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
        public void UpdateMovie(MoviesUpdateDTO moviesUpdateDTO)
        { 
            Movies movie = new();
            {
                movie.Title = moviesUpdateDTO.TitleMovie;
                movie.Description = moviesUpdateDTO.DescriptionMovie;
                movie.RunningTime = moviesUpdateDTO.RunningTimeMovie;
                movie.Release = moviesUpdateDTO.ReleaseMovie;
                movie.AwardId = moviesUpdateDTO.AwardId;
                movie.GenreId = moviesUpdateDTO.GenreId;
            }

            _moviesDA.UpdateMovie(movie);
        }
        #endregion
    }
}
