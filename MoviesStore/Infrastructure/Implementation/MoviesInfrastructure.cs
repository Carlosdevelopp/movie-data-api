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
        //Lista (Method) para traer todos los registros
        public List<MoviesDTO> GetMovies()
        {
            List<Movies> movies = _moviesDA.GetMovies();

            List<MoviesDTO> moviesDTOs = movies.Select(o => new MoviesDTO
            {
                TituloM = o.Title,
                DescriptionM = o.Description,
                RunningM = o.RunningTime,
                ReleaseM = o.Release
            }).ToList();

            return moviesDTOs;
        }
        #endregion
    }
}
