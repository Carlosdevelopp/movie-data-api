using DataAccess.Contract;
using DataAccess.Implementation.Base;
using DataAccess.Models.Tables;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Implementation
{
    public class MoviesDataAccess : IMoviesDataAccess
    {
        private readonly ApplicationDbContext _dbContext; 

        public MoviesDataAccess(ApplicationDbContext dbContex)
        {
            _dbContext = dbContex;
        }

        #region GET
        //This method retrieves a movie from the database using the provided movieId.
        public Movies GetMovie(int movieId)
        {
            return _dbContext.Movies.FirstOrDefault(u => u.MovieId == movieId);
        }

        //This method to retrieve all movies from the database
        public List<Movies> GetMovies()
        {
            return _dbContext.Movies.ToList();
        }

        //This method retrieves detailed information about a specific movie, including its genres and awards, using the provided movieId.
        public Movies GetMovieDetails(int movieId)
        {
            return _dbContext.Movies
                             .Include(e => e.Genres)
                             .Include(e => e.Awards)
                             .FirstOrDefault(e => e.MovieId == movieId);
        }

        //This method retrieves detailed information about all movies from the database
        public List<Movies> GetMoviesDetails()
        {
            return _dbContext.Movies
                             .Include(e => e.Genres)
                             .Include(e => e.Awards)
                             .ToList();
        }
        #endregion

        #region POST
        //This method inserts a new movie into the database
        public void InsertMovie(Movies movie)
        {
            _dbContext.Movies.Add(movie);
            _dbContext.SaveChanges();
        }
        #endregion


        #region PUT
        //This method updates an existing movie in the database
        public void UpdateMovie(Movies movie)
        {
            _dbContext.Movies.Update(movie);
            _dbContext.SaveChanges();
        }
        #endregion

        #region DELETE
        //This method deletes a movie from the database based on the provide movieId
        public void DeleteMovie(int movieId)
        {
            var movie = _dbContext.Movies.Find(movieId);

            _dbContext.Remove(movie);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}
