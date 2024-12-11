using DataAccess.Models.Tables;

namespace DataAccess.Contract
{
    public interface IMoviesDataAccess
    {
        #region GET
        //Retrives a movie by its ID
        Movies GetMovie(int movieId);

        //Retrives a list of all records 
        List<Movies> GetMovies();

        //Get the details of a specific movie by its ID 
        Movies GetMovieDetails(int movieId);

        //Get a list details of all available movie 
        List<Movies> GetMoviesDetails();

        //Get the details of a specific award by its ID
        Awards GetAward(int AwardId);

        //Get a list of all available genres
        List<Genres> GetGenres();

        // Get a list of all available actors
        List<Actors> GetActors();
        #endregion

        #region POST
        //Insert a movie at database 
        void InsertMovie(Movies movie);
        //Insert a genre at database
        void InsertGenre(Genres genre);
        //Insert a Award at database
        void InsertAward(Awards award);
        //Insert a Actor at database
        void InsertActor(Actors actor);
        #endregion

        #region PUT
        //Update information of a movie existint in the database
        void UpdateMovie(Movies movie);
        #endregion

        #region DELETE
        //Delete a movie of the database 
        void DeleteMovie(int movieId);
        #endregion
    }
}
