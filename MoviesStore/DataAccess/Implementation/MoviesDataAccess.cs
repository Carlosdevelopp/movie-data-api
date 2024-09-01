using DataAccess.Contract;
using DataAccess.Implementation.Base;
using DataAccess.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        //Traer una lista de todos los registros
        public List<Movies> GetMovies()
        {
            List<Movies> movies = (from u in _dbContext.Movies
                             select u).ToList();

            return movies;
        }
        #endregion
    }
}
