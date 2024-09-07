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
        List<AwardsDTO> GetMoviesDetails();
        #endregion
    }
}
