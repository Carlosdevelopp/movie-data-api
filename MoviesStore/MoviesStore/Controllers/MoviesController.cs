using Infrastructure.Contract;
using Infrastructure.DTO;
using Microsoft.AspNetCore.Mvc;

namespace MoviesStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class MoviesController : ControllerBase
    {
        private readonly IMoviesInfrastructure _moviesInfrastructure;

        public MoviesController(IMoviesInfrastructure moviesInfrastructure)
        {
            _moviesInfrastructure = moviesInfrastructure;
        }

        #region GET
        /// <summary>
        /// Gets a movie by its ID
        /// </summary>
        /// <param name="movieId">Númber of movie</param>
        /// <returns>Object of movie</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /Todo
        ///     {
        ///        "id": 1,
        ///        "name": "Item #1",
        ///        "isComplete": true
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Devuelve la el objeto</response>
        /// <response code="400">Si el parámetro movieId no se encontró</response>
        [HttpGet("GetMovie")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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

        /// <summary>
        /// Obtiene el pronóstico del tiempo para un número específico de días.
        /// </summary>
        /// <returns>Una lista de peliculas.</returns>
        /// <response code="200">Devuelve la lista de películas solicitada.</response>
        /// <response code="400">Error</response>
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

        /// <summary>
        /// Gets a movie by its ID
        /// </summary>
        /// <param name="movieId">Númber of movie</param>
        /// <returns>Object of movie</returns>
        /// <response code="200">Devuelve la el objeto</response>
        /// <response code="400">Si el parámetro movieId no se encontró</response>
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

        /// <summary>
        /// Obtiene el pronóstico del tiempo para un número específico de días.
        /// </summary>
        /// <returns>Una lista de peliculas.</returns>
        /// <response code="200">Devuelve la lista de películas solicitada.</response>
        /// <response code="400">Error</response>
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
        /// <summary>
        /// Inserta una nueva película en la base de datos.
        /// </summary>
        /// <param name="moviesInsertDTO">Objeto que contiene la información de la película a insertar.</param>
        /// <returns>Un resultado de la acción.</returns>
        /// <response code="200">Si la película se insertó correctamente.</response>
        /// <response code="400">Si hubo un error al insertar la película.</response>
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
        /// <summary>
        /// Actualiza una nueva película en la base de datos.
        /// </summary>
        /// <param name="moviesUpdateDTO">Objeto que contiene la información de la película a insertar.</param>
        /// <returns>Un resultado de la acción.</returns>
        /// <response code="200">Si la película se insertó correctamente.</response>
        /// <response code="400">Si hubo un error al insertar la película.</response>
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
        /// <summary>
        /// Deletes a movie of the database.
        /// </summary>
        /// <param name="movieId"></param>
        /// <returns>request</returns>
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
