using Infrastructure.DTO;

namespace Infrastructure.Contract;

public interface IMoviesInfrastructure
{
    #region GET
    //This method retrives a movie by its ID and converts it into a MoviesDTO object
    Task<MoviesDTO> GetMovieAsync(int MovieId);

    //This method retrives a list all movies and the convert at MoviesDTO objects
    Task<List<MoviesDTO>> GetAllMoviesAsync();

    //This method gets details of a movie by its ID and convert AwardsDTO object 
    Task<AwardsDTO?> GetMovieDetailsAsync(int movieId);

    //This method gets a list movies with detailded information and the convert at at AwardsDTO objects
    Task<List<AwardsDTO>> GetAllMoviesDetailsAsync();

    //This method retrives a award by its ID and convert in into a AwardsDTO object 
    Task<AwardDTO?> GetAwardAsync(int awardId);

    //This method gets a list all genres and the convert GenresDTO objects
    Task<List<GenresDTO>> GetAllGenresAsync();

    //This method retrives a genre by its ID and converts it into a GenresDTO object
    Task<GenresDTO?> GetGenreAsync(int genreId);

    //This method gets a list all Actors and the convert ActorsDTO objects
    // Versión ultra eficiente (si el DA lo permite)
    Task<List<ActorsDTO>> GetAllActorsAsync();

    //This method retrives a Award by its ID and converts it into a ActorsDTO object
    Task<ActorsDTO?> GetActorAsync(int actorId);
    #endregion

    #region POST
    //This method insert a movie at the database using data from MoviesInsertDTO object
    Task<int> InsertMovieAsync(MoviesInsertDTO moviesInsertDTO);

    //This method inerts a Genre at the database using data from GernresInsertDTO object
    Task InsertGenreAsync(GenresInsertDTO genreInsertDTO);

    //This method inserts a Award at the database using data from AwardInsertDTO
    Task InsertAwardAsync(AwardsInsertDTO awardsInsertDTO);

    //This method inserts a Actor at the datbase using data from ActorsInsertDTO
    Task InsertActorAsync(ActorsInsertDTO actorsInsertDTO);
    #endregion

    #region PUT
    //This method updates an existing movie in the database using data from the MoviesUpdateDTO object
    Task<bool> UpdateMovieAsync(MoviesUpdateDTO moviesUpdateDTO);
    #endregion

    #region DELETE
    // This method deletes a movie from the database using the provided movieId.
    Task<bool> DeleteMovieAsync(int movieId);
    #endregion
}
