using DataAccess.Models.Tables;
using Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Contract
{
    public interface IMoviesInfrastructure
    {
        #region GET
        MoviesDTO GetMovie(int MovieId);
        List<MoviesDTO> GetMovies();
        AwardsDTO GetMovieDetails(int MovieId);
        List<AwardsDTO> GetMoviesDetails();
        #endregion

        #region POST
        void InsertMovie(MoviesInsertDTO moviesInsertDTO);
        #endregion

        #region PUT
        void UpdateMovie(MoviesUpdateDTO moviesUpdateDTO);
        #endregion
    }
}
