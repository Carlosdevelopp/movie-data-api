using Infrastructure.Contract;
using Infrastructure.DTO;
using Microsoft.AspNetCore.Mvc;

namespace MoviesStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly IMoviesInfrastructure _moviesInfrastructure;

        public MoviesController(IMoviesInfrastructure moviesInfrastructure)
        {
            _moviesInfrastructure = moviesInfrastructure;
        }

        #region GET
        [HttpGet("GetMovie")]
        public IActionResult GetMovie(int movieId)
        {
            try
            {
                return Ok(_moviesInfrastructure.GetMovie(movieId));
            }
            catch (Exception)
            {
                return BadRequest("error");
            }
        }

        [HttpGet("GetMovies")]  
        public IActionResult GetMovies()
        {
            try
            {
                return Ok(_moviesInfrastructure.GetMovies());
            }
            catch (Exception)
            {
                return BadRequest("error");
            }
        }

        [HttpGet("GetMovieDetails")]
        public IActionResult GetMovieDetails(int movieId) 
        {
            try
            {
                return Ok(_moviesInfrastructure.GetMovieDetails(movieId));
            }
            catch (Exception)
            {
                return BadRequest("error");
            }
        }

        [HttpGet("GetMoviesDetails")]
        public IActionResult GetMoviesDetails()
        {
            try
            {
                return Ok(_moviesInfrastructure.GetMoviesDetails());
            }
            catch (Exception)
            {

                return BadRequest("error");
            }
        }
        #endregion

        #region POST
        [HttpPost("InsertMovie")]
        public IActionResult InsertMovie(MoviesInsertDTO moviesInsertDTO)
        {
            try
            {
                _moviesInfrastructure.InsertMovie(moviesInsertDTO);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("Error");
            }
        }
        #endregion

        #region PUT
        [HttpPut("UpdateMovie")]
        public IActionResult UpdateMovie(MoviesUpdateDTO moviesUpdateDTO)
        {
            try
            {
                _moviesInfrastructure.UpdateMovie(moviesUpdateDTO);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("Error");
            }
        }
        #endregion

        #region DELETE
        [HttpDelete("DeleteMovie")]
        public IActionResult DeleteMovie(int movieId)
        {
            try
            {
                _moviesInfrastructure.DeleteMovie(movieId);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("Error");
            }
        }
        #endregion
    }
}
