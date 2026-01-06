using DataAccess.Models.Tables;

namespace DataAccess.Contract;

public interface IMoviesDataAccess
{
    #region GET
    //This method retrieves a movie from the database using the provided movieId.
    Task<Movies?> GetMovieByIdAsync(int movieId);

    //This method to retrieve all movies from the database
    Task<List<Movies>> GetAllMoviesAsync();

    //This method retrieves detailed information about a specific movie, including its genres and awards, using the provided movieId.
    Task<Movies?> GetMovieDetailsAsync(int movieId);
    //This method retrieves detailed information about all movies from the database
    Task<List<Movies>> GetAllMoviesDetailsAsync();

    //This method returns information about a specific award
    Task<Awards?> GetAwardAsync(int AwardId);

    //This method returns information about all genres from the database
    Task<List<Genres>> GetAllGenresAsync();

    //This method returns information about a specific genre
    Task<Genres?> GetGenreAsync(int genreId);

    //This method returns information about all actors from the database 
    Task<List<Actors>> GetAllActorsAsync();

    //This method returns information about all genres from the database
    Task<Actors?> GetActorAsync(int actorId);
    #endregion

    #region POST
    //This method inserts a new movie into the database
    Task<int> InsertMovieAsync(Movies movie);

    //This method inserts a new record into the database
    Task InsertGenreAsync(Genres genre);

    //This method inserts a new record into the database
    Task InsertAwardAsync(Awards award);

    //This method inserts a new record into the database
    Task InsertActorAsync(Actors actor);
    #endregion

    #region PUT
    //This method updates an existing movie in the database
    Task<bool> UpdateMovieAsync(Movies movie);
    #endregion

    #region DELETE
    //This method deletes a movie from the database based on the provide movieId
    Task<bool> DeleteMovieAsync(Movies movie);
    #endregion
}
