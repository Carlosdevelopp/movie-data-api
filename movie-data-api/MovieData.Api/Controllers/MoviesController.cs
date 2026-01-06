using Infrastructure.Contract;
using Infrastructure.DTO;
using Microsoft.AspNetCore.Mvc;

namespace MoviesStore.Controllers;

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

    /// <summary>
    /// Get a movie by its ID
    /// </summary>
    /// <param name="movieId">ID of movie</param>
    /// <returns>Movie object</returns>
    /// <response code="200">Returns the movie object</response>
    /// <response code="404">Movie not found</response>
    /// <response code="500">Internal server error</response>
    [HttpGet("{movieId}")]
    [ProducesResponseType(typeof(MoviesDTO), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetMovieAsync(int movieId)
    {
        try
        {
            var movie = await _moviesInfrastructure.GetMovieAsync(movieId);

            if (movie == null)
            {
                return NotFound($"La película con ID {movieId} no existe.");
            }

            return Ok(movie);
        }
        catch (Exception ex)
        {
            // TODO: Implementar logging (_logger.LogError)
            return StatusCode(StatusCodes.Status500InternalServerError,
                "Ocurrió un error interno al procesar la solicitud.");
        }
    }

    /// <summary>
    /// Get all movies
    /// </summary>
    /// <returns>List of movies</returns>
    /// <response code="200">Returns the list of movies</response>
    /// <response code="500">Internal server error</response>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<MoviesDTO>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAllMoviesAsync()
    {
        try
        {
            var movies = await _moviesInfrastructure.GetAllMoviesAsync();
            return Ok(movies ?? Enumerable.Empty<MoviesDTO>());
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                "Error al obtener el listado de películas.");
        }
    }

    /// <summary>
    /// Get movie details by ID
    /// </summary>
    /// <param name="movieId">ID of the movie</param>
    /// <returns>Movie details object</returns>
    /// <response code="200">Returns movie details</response>
    /// <response code="404">Movie not found</response>
    /// <response code="500">Internal server error</response>
    [HttpGet("{movieId}/details")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetMovieDetailsAsync(int movieId)
    {
        try
        {
            var details = await _moviesInfrastructure.GetMovieDetailsAsync(movieId);

            if (details == null)
            {
                return NotFound(new { message = $"No se encontraron detalles para la película con ID {movieId}." });
            }

            return Ok(details);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                "Error interno al recuperar los detalles.");
        }
    }

    /// <summary>
    /// Get all movies with details
    /// </summary>
    /// <returns>List of movie details</returns>
    /// <response code="200">Returns list of movie details</response>
    /// <response code="500">Internal server error</response>
    [HttpGet("details")]
    [ProducesResponseType(typeof(List<AwardsDTO>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAllMoviesDetailsAsync()
    {
        try
        {
            var details = await _moviesInfrastructure.GetAllMoviesDetailsAsync();
            return Ok(details ?? new List<AwardsDTO>());
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                "Error interno al obtener los detalles.");
        }
    }

    /// <summary>
    /// Get all actors
    /// </summary>
    /// <returns>List of actors</returns>
    /// <response code="200">Returns list of actors</response>
    /// <response code="500">Internal server error</response>
    [HttpGet("actors")]
    [ProducesResponseType(typeof(List<ActorsDTO>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAllActorsAsync()
    {
        try
        {
            var actors = await _moviesInfrastructure.GetAllActorsAsync();
            return Ok(actors ?? new List<ActorsDTO>());
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                "Error al recuperar el listado de actores.");
        }
    }

    /// <summary>
    /// Get actor by ID
    /// </summary>
    /// <param name="actorId">ID of the actor</param>
    /// <returns>Actor object</returns>
    /// <response code="200">Returns the actor</response>
    /// <response code="404">Actor not found</response>
    /// <response code="500">Internal server error</response>
    [HttpGet("actors/{actorId}")]
    [ProducesResponseType(typeof(ActorsDTO), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetActorAsync(int actorId)
    {
        try
        {
            var actor = await _moviesInfrastructure.GetActorAsync(actorId);

            if (actor == null)
            {
                return NotFound(new { message = $"El actor con ID {actorId} no existe." });
            }

            return Ok(actor);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                "Error interno al recuperar los datos del actor.");
        }
    }

    /// <summary>
    /// Get all genres
    /// </summary>
    /// <returns>List of genres</returns>
    /// <response code="200">Returns list of genres</response>
    /// <response code="500">Internal server error</response>
    [HttpGet("genres")]
    [ProducesResponseType(typeof(List<GenresDTO>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAllGenresAsync()
    {
        try
        {
            var genres = await _moviesInfrastructure.GetAllGenresAsync();
            return Ok(genres ?? new List<GenresDTO>());
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                "Error al recuperar los géneros.");
        }
    }

    /// <summary>
    /// Get genre by ID
    /// </summary>
    /// <param name="genreId">ID of the genre</param>
    /// <returns>Genre object</returns>
    /// <response code="200">Returns the genre</response>
    /// <response code="404">Genre not found</response>
    /// <response code="500">Internal server error</response>
    [HttpGet("genres/{genreId}")]
    [ProducesResponseType(typeof(GenresDTO), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetGenreAsync(int genreId)
    {
        try
        {
            var genre = await _moviesInfrastructure.GetGenreAsync(genreId);

            if (genre == null)
            {
                return NotFound(new { message = $"El género con ID {genreId} no existe." });
            }

            return Ok(genre);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                "Error interno al recuperar el género.");
        }
    }

    /// <summary>
    /// Get award by ID
    /// </summary>
    /// <param name="awardId">ID of the award</param>
    /// <returns>Award object</returns>
    /// <response code="200">Returns the award</response>
    /// <response code="404">Award not found</response>
    /// <response code="500">Internal server error</response>
    [HttpGet("awards/{awardId}")]
    [ProducesResponseType(typeof(AwardDTO), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAwardAsync(int awardId)
    {
        try
        {
            var award = await _moviesInfrastructure.GetAwardAsync(awardId);

            if (award == null)
            {
                return NotFound($"No se encontró el premio con ID {awardId}.");
            }

            return Ok(award);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                "Error interno al recuperar el premio.");
        }
    }

    /// <summary>
    /// Insert a genre
    /// </summary>
    /// <param name="genresInsertDTO">Genre data</param>
    /// <returns>Status message</returns>
    /// <response code="201">Genre created successfully</response>
    /// <response code="400">Invalid data</response>
    /// <response code="500">Internal server error</response>
    [HttpPost("genres")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> InsertGenreAsync([FromBody] GenresInsertDTO genresInsertDTO)
    {
        if (genresInsertDTO == null)
        {
            return BadRequest("El género no puede ser nulo.");
        }

        try
        {
            await _moviesInfrastructure.InsertGenreAsync(genresInsertDTO);
            return StatusCode(StatusCodes.Status201Created, "Género creado con éxito.");
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                "Error al insertar el género.");
        }
    }

    /// <summary>
    /// Insert a movie
    /// </summary>
    /// <param name="moviesInsertDTO">Movie data</param>
    /// <returns>Created movie</returns>
    /// <response code="201">Movie created successfully</response>
    /// <response code="400">Invalid data</response>
    /// <response code="500">Internal server error</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> InsertMovieAsync([FromBody] MoviesInsertDTO moviesInsertDTO)
    {
        if (moviesInsertDTO == null)
        {
            return BadRequest("Los datos de la película son obligatorios.");
        }

        try
        {
            int newMovieId = await _moviesInfrastructure.InsertMovieAsync(moviesInsertDTO);
            return CreatedAtAction(nameof(GetMovieAsync), new { movieId = newMovieId }, moviesInsertDTO);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                "Error al guardar la película en el servidor.");
        }
    }

    /// <summary>
    /// Insert an award
    /// </summary>
    /// <param name="awardInsertDTO">Award data</param>
    /// <returns>Status message</returns>
    /// <response code="201">Award created successfully</response>
    /// <response code="400">Invalid data</response>
    /// <response code="500">Internal server error</response>
    [HttpPost("awards")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> InsertAwardAsync([FromBody] AwardsInsertDTO awardInsertDTO)
    {
        if (awardInsertDTO == null)
        {
            return BadRequest("Los datos del premio son requeridos.");
        }

        try
        {
            await _moviesInfrastructure.InsertAwardAsync(awardInsertDTO);
            return StatusCode(StatusCodes.Status201Created,
                new { message = "Premio registrado correctamente." });
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                "Error al intentar registrar el premio.");
        }
    }

    /// <summary>
    /// Insert an actor
    /// </summary>
    /// <param name="actorsInsertDTO">Actor data</param>
    /// <returns>Status message</returns>
    /// <response code="201">Actor created successfully</response>
    /// <response code="400">Invalid data</response>
    /// <response code="500">Internal server error</response>
    [HttpPost("actors")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> InsertActorAsync([FromBody] ActorsInsertDTO actorsInsertDTO)
    {
        if (actorsInsertDTO == null)
        {
            return BadRequest("Los datos del actor son obligatorios.");
        }

        try
        {
            await _moviesInfrastructure.InsertActorAsync(actorsInsertDTO);
            return StatusCode(StatusCodes.Status201Created,
                new { message = "Actor registrado exitosamente." });
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                "Error interno al registrar el actor.");
        }
    }

    /// <summary>
    /// Update a movie
    /// </summary>
    /// <param name="moviesUpdateDTO">Updated movie data</param>
    /// <returns>Status message</returns>
    /// <response code="200">Movie updated successfully</response>
    /// <response code="400">Invalid data</response>
    /// <response code="404">Movie not found</response>
    /// <response code="500">Internal server error</response>
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpdateMovieAsync([FromBody] MoviesUpdateDTO moviesUpdateDTO)
    {
        if (moviesUpdateDTO == null || moviesUpdateDTO.MovieId <= 0)
        {
            return BadRequest("Datos de película inválidos.");
        }

        try
        {
            bool isUpdated = await _moviesInfrastructure.UpdateMovieAsync(moviesUpdateDTO);

            if (!isUpdated)
            {
                return NotFound($"No se encontró la película con ID {moviesUpdateDTO.MovieId} para actualizar.");
            }

            return Ok(new { message = "Película actualizada correctamente." });
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                "Error interno al actualizar la película.");
        }
    }

    /// <summary>
    /// Delete a movie by ID
    /// </summary>
    /// <param name="movieId">ID of the movie</param>
    /// <returns>Status message</returns>
    /// <response code="200">Movie deleted successfully</response>
    /// <response code="400">Invalid ID</response>
    /// <response code="404">Movie not found</response>
    /// <response code="500">Internal server error</response>
    [HttpDelete("{movieId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeleteMovieAsync(int movieId)
    {
        if (movieId <= 0)
        {
            return BadRequest("El ID de la película no es válido.");
        }

        try
        {
            bool deleted = await _moviesInfrastructure.DeleteMovieAsync(movieId);

            if (!deleted)
            {
                return NotFound($"No se pudo eliminar: La película con ID {movieId} no existe.");
            }

            return Ok(new { message = "Película eliminada correctamente." });
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                "Error interno al eliminar la película.");
        }
    }
}