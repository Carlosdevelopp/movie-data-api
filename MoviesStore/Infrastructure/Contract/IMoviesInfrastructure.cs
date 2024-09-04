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
        List<MoviesDTO> GetMovies();
        MoviesDTO GetMovie(int MovieId);
        #endregion
    }
}
