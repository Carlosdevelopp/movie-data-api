using DataAccess.Contract;
using DataAccess.Implementation.Base;
using DataAccess.Models.Tables;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Implementation;

public class MoviesDataAccess : IMoviesDataAccess
{
    private readonly ApplicationDbContext _dbContext;

    public MoviesDataAccess(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    #region GET
    //This method retrieves a movie from the database using the provided movieId.
    public async Task<Movies?> GetMovieByIdAsync(int movieId)
    {
        return await  _dbContext.Movies.FirstOrDefaultAsync(u => u.MovieId == movieId);
    }

    //This method to retrieve all movies from the database
    public async Task<List<Movies>> GetAllMoviesAsync()
    {
        return await _dbContext.Movies.ToListAsync();
    }

    //This method retrieves detailed information about a specific movie, including its genres and awards, using the provided movieId.
    public async Task<Movies?> GetMovieDetailsAsync(int movieId)
    {
        return await _dbContext.Movies
                         .Include(e => e.Genres)
                         .Include(e => e.Awards)
                         .FirstOrDefaultAsync(e => e.MovieId == movieId);
    }

    //This method retrieves detailed information about all movies from the database
    public async Task<List<Movies>> GetAllMoviesDetailsAsync()
    {
        return await _dbContext.Movies
                         .Include(e => e.Genres)
                         .Include(e => e.Awards)
                         .ToListAsync();
    }

    //This method returns information about a specific award
    public async Task<Awards?> GetAwardAsync(int AwardId)
    {
        return await _dbContext.Awards.FirstOrDefaultAsync(u => u.AwardId == AwardId);
    }

    //This method returns information about all genres from the database
    public async Task<List<Genres>> GetAllGenresAsync()
    {
        return await _dbContext.Genres.ToListAsync();
    }

    //This method returns information about a specific genre
    public async Task<Genres?> GetGenreAsync(int genreId)
    {
        return await _dbContext.Genres.FirstOrDefaultAsync(o => o.GenreId == genreId);
    }

    //This method returns information about all actors from the database 
    public async Task<List<Actors>> GetAllActorsAsync()
    {
        return await _dbContext.Actors.ToListAsync();
    }

    //This method returns information about all genres from the database
    public async Task<Actors?> GetActorAsync(int actorId)
    {
        return await _dbContext.Actors.FirstOrDefaultAsync( u => u.ActorId == actorId);
    }
    #endregion

    #region POST
    //This method inserts a new movie into the database
    public async Task<int> InsertMovieAsync(Movies movie)
    {
        _dbContext.Movies.Add(movie);
        await _dbContext.SaveChangesAsync();
        return movie.MovieId; // Retornamos el ID generado
    }

    //This method inserts a new record into the database
    public async Task InsertGenreAsync(Genres genre)
    {
        _dbContext.Genres.Add(genre);
        await _dbContext.SaveChangesAsync();
    }

    //This method inserts a new record into the database
    public async Task InsertAwardAsync(Awards award)
    {
        _dbContext.Awards.Add(award);
        await _dbContext.SaveChangesAsync();
    }

    //This method inserts a new record into the database
    public async Task InsertActorAsync(Actors actor)
    {
        _dbContext.Actors.Add(actor);
        await _dbContext.SaveChangesAsync();
    }
    #endregion

    #region PUT
    //This method updates an existing movie in the database
    public async Task<bool> UpdateMovieAsync(Movies movie)
    {
        _dbContext.Movies.Update(movie);
        // SaveChangesAsync devuelve la cantidad de registros afectados
        return await _dbContext.SaveChangesAsync() > 0;
    }
    #endregion


    #region DELETE
    //This method deletes a movie from the database based on the provide movieId
    public async Task<bool> DeleteMovieAsync(Movies movie)
    {
        _dbContext.Movies.Remove(movie);
        // Devuelve true si se guardaron cambios en al menos una fila
        return await _dbContext.SaveChangesAsync() > 0;
    }
    #endregion
}
