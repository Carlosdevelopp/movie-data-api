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
        #endregion

        #region POST
        //Insert a movie at database 
        void InsertMovie(Movies movie);
        //Insert a genre at database
        void InsertGenre(Genres genre);
        //This a Award at database
        void InsertAward(Awards award);
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
