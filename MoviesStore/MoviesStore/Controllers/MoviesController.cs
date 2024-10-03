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
        /// Request:
        ///
        ///     GET /api/Movies/GetMovie
        ///     {
        ///         "tituloMovie": "string",
        ///         "descriptionMovie": "string",
        ///         "runningMovie": int,
        ///         "releaseMovie": dataTime,
        ///         "genreId": int,
        ///         "awardId": int
        ///     }
        /// </remarks>
        /// <response code="201">Successful operation and return movie object</response>
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
        ///  Request:
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
        /// <response code="201">Operation successful.</response>
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
        /// Request:
        ///
        ///     GET /api/Movies/GetMovieDetails
        ///     {
        ///         "tituloMovie": "string",
        ///         "descriptionMovie": "string",
        ///         "runningMovie": string,
        ///         "releaseMovie": string,
        ///         "genreId": string,
        ///         "awardId": string
        ///     }
        /// </remarks>
        /// <response code="201">Successful operation and return movieDetails object</response>
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
        /// <response code="201">Operation Successful and returns the list of moviesdetails.</response>
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
        /// Insert a movie into the database.
        /// </summary>
        /// <param name="moviesInsertDTO">Object to insert.</param>
        /// <returns>Answer.</returns>
        /// <remarks>
        /// Request:
        ///
        ///     POST /api/Movies/InsertMovie
        ///     {
        ///         "titleMovie": "string",
        ///         "descriptionMovie": "string",
        ///         "releaseMovie": "datatime",
        ///         "runningTimeMovie": int,
        ///         "genreId": int,
        ///         "awardId": int
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Successful operation.</response>
        /// <response code="400">Client error.</response>
        [HttpPost("InsertMovie")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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
        /// Update a movie into the data base.
        /// </summary>
        /// <param name="moviesUpdateDTO">Object movie to insert.</param>
        /// <returns>Answer.</returns>
        /// <remarks>
        /// Request:
        ///
        ///     PUT /api/Movies/UpdateMovie
        ///     {
        ///         "movieId": int,
        ///         "titleMovie": "string",
        ///         "descriptionMovie": "string",
        ///         "releaseMovie": "datatime",
        ///         "runningTimeMovie": int,
        ///         "genreId": int,
        ///         "awardId": int
        ///     }
        /// </remarks>
        /// <response code="200">Successful operation.</response>
        /// <response code="400">Si hubo un error al insertar la película.</response>
        [HttpPut("UpdateMovie")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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
        /// Delete a movie by its ID.
        /// </summary>
        /// <param name="movieId">ID of the movie to be deleted.</param>
        /// <returns>Answer.</returns>
        /// <remarks>
        /// Request:
        ///
        ///     DELETE /api/Movies/DeleteMovie
        ///     {
        ///         "movieId": int
        ///     }
        /// </remarks>
        /// <response code="200">Successful operation.</response>
        /// <response code="400">Client error.</response>
        [HttpDelete("DeleteMovie")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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
