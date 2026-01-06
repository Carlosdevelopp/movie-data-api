using DataAccess.Contract;
using DataAccess.Models.Tables;
using Infrastructure.Contract;
using Infrastructure.DTO;
using Infrastructure.Utils;

namespace Infrastructure.Implementation;

public class MoviesInfrastructure : IMoviesInfrastructure
{
    private readonly IMoviesDataAccess _moviesDA;

    public MoviesInfrastructure(IMoviesDataAccess moviesDA)
    {
        _moviesDA = moviesDA;
    }

    #region GET
    //This method retrives a movie by its ID and converts it into a MoviesDTO object
    public async Task<MoviesDTO> GetMovieAsync(int MovieId)
    {
        // 1. Obtenemos la entidad de la base de datos
        var movie = await _moviesDA.GetMovieByIdAsync(MovieId);

        // 2. VALIDACIÓN CRUCIAL: Verificar si existe antes de mapear
        if (movie == null)
        {
            return null; // O puedes lanzar una excepción personalizada si prefieres
        }

        // 3. Mapeo seguro a DTO
        MoviesDTO movieDTO = new MoviesDTO
        {
            TituloMovie = movie.Title,
            DescriptionMovie = movie.Description,
            RunningMovie = movie.RunningTime,
            ReleaseMovie = movie.Release,
            GenreId = movie.GenreId,
            AwardId = movie.AwardId,
        };

        return movieDTO;
    }

    //This method retrives a list all movies and the convert at MoviesDTO objects
    public async Task<List<MoviesDTO>> GetAllMoviesAsync()
    {
        // 1. Obtenemos todas las entidades de la base de datos
        var movies = await _moviesDA.GetAllMoviesAsync();

        // 2. Si la base de datos devuelve null, devolvemos una lista vacía para evitar errores
        if (movies == null)
        {
            return new List<MoviesDTO>();
        }

        // 3. Mapeamos la lista de entidades a la lista de DTOs
        return movies.Select(m => new MoviesDTO
        {
            TituloMovie = m.Title,
            DescriptionMovie = m.Description,
            RunningMovie = m.RunningTime,
            ReleaseMovie = m.Release,
            GenreId = m.GenreId,
            AwardId = m.AwardId
        }).ToList();
    }

    //This method gets details of a movie by its ID and convert AwardsDTO object 
    public async Task<AwardsDTO?> GetMovieDetailsAsync(int movieId)
    {
        // 1. Obtenemos la película con sus relaciones
        var movie = await _moviesDA.GetMovieDetailsAsync(movieId);

        // 2. Validación de nulidad de la película
        if (movie == null)
        {
            return null;
        }

        // 3. Mapeo seguro usando el operador condicional nulo (?)
        return new AwardsDTO
        {
            TitleMovie = movie.Title?.FormatTitle() ?? "Sin Título",
            DescriptionMovie = movie.Description?.ToUpper() ?? "Sin Descripción",
            RunningTimeMovie = movie.RunningTime.ToString(),
            ReleaseMovie = movie.Release.ToString(),
            // Usamos ?. para evitar errores si la relación es nula
            Genre = movie.Genres?.Genre ?? "N/A",
            Award = movie.Awards?.AwardTitle ?? "Sin Premios"
        };
    }

    //This method gets a list movies with detailded information and the convert at at AwardsDTO objects
    public async Task<List<AwardsDTO>> GetAllMoviesDetailsAsync()
    {
        var movies = await _moviesDA.GetAllMoviesDetailsAsync();

        if (movies == null) return new List<AwardsDTO>();

        return movies.Select(u => new AwardsDTO
        {
            TitleMovie = u.Title.FormatTitle(),
            DescriptionMovie = u.Description?.ToUpper() ?? string.Empty,
            ReleaseMovie = u.Release.ShortDate(),
            RunningTimeMovie = u.RunningTime.FormatTime(),
            Genre = u.Genres?.Genre ?? "N/A",
            Award = u.Awards?.AwardTitle ?? "Sin premio"
        }).ToList();
    }

    //This method retrives a award by its ID and convert in into a AwardsDTO object 
    public async Task<AwardDTO?> GetAwardAsync(int awardId)
    {
        var award = await _moviesDA.GetAwardAsync(awardId);

        if (award is null)
        {
            return null; // O podrías lanzar una excepción personalizada según tu lógica de negocio
        }

        return new AwardDTO
        {
            AwardId = award.AwardId,
            AwardTitle = award.AwardTitle
        };
    }

    //This method gets a list all genres and the convert GenresDTO objects
    public async Task<List<GenresDTO>> GetAllGenresAsync()
    {
        var genres = await _moviesDA.GetAllGenresAsync();

        // Verificamos si la lista es nula para evitar excepciones al iterar
        if (genres == null || !genres.Any())
        {
            return new List<GenresDTO>();
        }

        return genres.Select(g => new GenresDTO
        {
            GenreMovie = g.Genre
        }).ToList();
    }

    //This method retrives a genre by its ID and converts it into a GenresDTO object
    public async Task<GenresDTO?> GetGenreAsync(int genreId)
    {
        var genre = await _moviesDA.GetGenreAsync(genreId);

        if (genre is null)
        {
            return null;
        }

        return new GenresDTO
        {
            GenreMovie = genre.Genre
        };
    }

    //This method gets a list all Actors and the convert ActorsDTO objects
    // Versión ultra eficiente (si el DA lo permite)
    public async Task<List<ActorsDTO>> GetAllActorsAsync()
    {
        // Primero obtienes la lista desde el DA
        var actors = await _moviesDA.GetAllActorsAsync();

        // Luego haces el mapeo
        return actors.Select(a => new ActorsDTO
        {
            FullNameActor = a.FullName
        }).ToList();
    }

    //This method retrives a Award by its ID and converts it into a ActorsDTO object
    public async Task<ActorsDTO?> GetActorAsync(int actorId)
    {
        // Cambiamos a asíncrono para mejor rendimiento en aplicaciones web
        var actor = await _moviesDA.GetActorAsync(actorId);

        if (actor is null)
        {
            return null;
        }

        return new ActorsDTO
        {
            FullNameActor = actor.FullName
        };
    }
    #endregion

    #region POST
    //This method insert a movie at the database using data from MoviesInsertDTO object
    public async Task<int> InsertMovieAsync(MoviesInsertDTO moviesInsertDTO)
    {
        if (moviesInsertDTO == null)
            throw new ArgumentNullException(nameof(moviesInsertDTO));

        var movie = new Movies
        {
            Title = moviesInsertDTO.TitleMovie,
            Description = moviesInsertDTO.DescriptionMovie,
            Release = moviesInsertDTO.ReleaseMovie,
            RunningTime = moviesInsertDTO.RunningTimeMovie,
            GenreId = moviesInsertDTO.Genre,
            AwardId = moviesInsertDTO.Award
        };

        // Retornamos el ID que nos da el DA
        return await _moviesDA.InsertMovieAsync(movie);
    }

    //This method inerts a Genre at the database using data from GernresInsertDTO object
    public async Task InsertGenreAsync(GenresInsertDTO genreInsertDTO)
    {
        // 1. Validación de seguridad
        if (genreInsertDTO == null || string.IsNullOrWhiteSpace(genreInsertDTO.Genre))
        {
            throw new ArgumentException("El nombre del género es obligatorio.");
        }

        // 2. Mapeo y creación del objeto de dominio
        var genre = new Genres
        {
            Genre = genreInsertDTO.Genre
        };

        // 3. Persistencia asíncrona
        await _moviesDA.InsertGenreAsync(genre);
    }

    //This method inserts a Award at the database using data from AwardInsertDTO
    public async Task InsertAwardAsync(AwardsInsertDTO awardsInsertDTO)
    {
        // 1. Validación de entrada
        if (awardsInsertDTO == null || string.IsNullOrWhiteSpace(awardsInsertDTO.AwardTitle))
        {
            throw new ArgumentException("El título del premio no puede estar vacío.");
        }

        // 2. Mapeo correcto (sin el punto y coma erróneo antes de las llaves)
        var award = new Awards
        {
            AwardTitle = awardsInsertDTO.AwardTitle
        };

        // 3. Llamada asíncrona a la capa de datos
        await _moviesDA.InsertAwardAsync(award);
    }

    //This method inserts a Actor at the datbase using data from ActorsInsertDTO
    public async Task InsertActorAsync(ActorsInsertDTO actorsInsertDTO)
    {
        // 1. Validación de seguridad
        if (actorsInsertDTO == null || string.IsNullOrWhiteSpace(actorsInsertDTO.FullName))
        {
            throw new ArgumentException("El nombre del actor es obligatorio.");
        }

        // 2. Mapeo de DTO a Entidad (Sintaxis corregida)
        var actor = new Actors
        {
            FullName = actorsInsertDTO.FullName
        };

        // 3. Ejecución asíncrona
        await _moviesDA.InsertActorAsync(actor);
    }
    #endregion

    #region PUT
    //This method updates an existing movie in the database using data from the MoviesUpdateDTO object
    public async Task<bool> UpdateMovieAsync(MoviesUpdateDTO moviesUpdateDTO)
    {
        if (moviesUpdateDTO == null || moviesUpdateDTO.MovieId <= 0)
        {
            return false; // En lugar de lanzar excepción, devolvemos false para el Controller
        }

        var movie = new Movies
        {
            MovieId = moviesUpdateDTO.MovieId,
            Title = moviesUpdateDTO.TitleMovie,
            Description = moviesUpdateDTO.DescriptionMovie,
            RunningTime = moviesUpdateDTO.RunningTimeMovie,
            Release = moviesUpdateDTO.ReleaseMovie,
            GenreId = moviesUpdateDTO.GenreId,
            AwardId = moviesUpdateDTO.AwardId
        };

        // Retornamos el booleano que viene desde el Data Access
        return await _moviesDA.UpdateMovieAsync(movie);
    }
    #endregion

    #region DELETE
    // This method deletes a movie from the database using the provided movieId.
    public async Task<bool> DeleteMovieAsync(int movieId)
    {
        // 1. Buscamos la entidad completa en la base de datos a través del DA
        // Necesitamos el objeto 'movie' para que Entity Framework sepa qué borrar
        var movie = await _moviesDA.GetMovieByIdAsync(movieId);

        // 2. Si la película no existe, retornamos false (esto ayudará al Controller a dar un 404)
        if (movie == null)
        {
            return false;
        }

        // 3. Ahora sí, llamamos al método del DA que recibe la ENTIDAD para eliminarla
        return await _moviesDA.DeleteMovieAsync(movie);
    }
    #endregion
}
