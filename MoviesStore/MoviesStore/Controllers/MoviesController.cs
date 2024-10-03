using Infrastructure.Contract;
using Infrastructure.DTO;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
        /// Get a movie by its ID
        /// </summary>
        /// <param name="movieId">ID of movie</param>
        /// <returns>Object of movie</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET / A Movie
        ///     {
        ///         "tituloMovie": "string",
        ///         "descriptionMovie": "string",
        ///         "runningMovie": int,
        ///         "releaseMovie": dataTime,
        ///         "genreId": int,
        ///         "awardId": int
        ///     }
        /// </remarks>
        /// <response code="200">Successful operation and return movie object</response>
        /// <response code="400">Client error</response>
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
        /// Get a list all movies.
        /// </summary>
        /// <returns>A list objetos of movies.</returns>
        /// <remarks>
        ///     Ejemplo de solicitud:
        ///     
        ///         GET /api/Movies/GetMovies
        ///         {
        ///            "titleMovie": "string",
        ///            "descriptionMovie": "string",
        ///            "runningMovie": int,
        ///            "releaseMovie": "datatime",
        ///            "genre": int,
        ///            "award": int
        ///         }
        /// </remarks>
        /// <response code="200">Operation successful and returns the list of movies.</response>
        /// <response code="400">Client error.</response>
        [HttpGet("GetMovies")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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
        /// Get a moviedetails by its ID
        /// </summary>
        /// <param name="movieId">ID of moviedetails</param>
        /// <returns>Object of moviedetails</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET / A Movie
        ///     {
        ///         "tituloMovie": "string",
        ///         "descriptionMovie": "string",
        ///         "runningMovie": string,
        ///         "releaseMovie": string,
        ///         "genreId": string,
        ///         "awardId": string
        ///     }
        /// </remarks>
        /// <response code="200">Successful operation and return movieDetails object</response>
        /// <response code="400">Client error</response>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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
        /// Get a list all moviesdetails.
        /// </summary>
        /// <returns>A list objects of movies.</returns>
        /// <remarks>
        ///     Ejemplo de solicitud:
        ///     
        ///         GET /api/Movies/GetMoviesDetails
        ///         {
        ///            "titleMovie": "string",
        ///            "descriptionMovie": "string",
        ///            "runningMovie": string,
        ///            "releaseMovie": "string",
        ///            "genre": string,
        ///            "award": string
        ///         }
        /// </remarks>
        /// <response code="200">Operation Successful and returns the list of movies.</response>
        /// <response code="400">Client error.</response>
        [HttpGet("GetMoviesDetails")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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
