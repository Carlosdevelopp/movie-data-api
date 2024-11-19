using Infrastructure.DTO;

namespace Infrastructure.Contract
{
    public interface IMoviesInfrastructure
    {
        #region GET
        //Retrives a movie by its ID and returns it as a MoviesDTO object
        MoviesDTO GetMovie(int MovieId);

        //Retrives a list of all movies and returns them as a collection of MoviesDTO objects
        List<MoviesDTO> GetMovies();

        //Retrives a detailed information about a movie by its ID and returns it as an AwardsDTO object
        AwardsDTO GetMovieDetails(int MovieId);

        //Retrives a list detailed all movies and returns them as a collection of AwardsDTO objects
        List<AwardsDTO> GetMoviesDetails();

        //Retrives a award by its ID and returns it as a AwardDTO object
        AwardDTO GetAward(int AwardId);
        #endregion

        #region POST
        //Inserts a new movie into the database using the MoviesInsertDTO object
        void InsertMovie(MoviesInsertDTO moviesInsertDTO);
        //Inserts a new genre into the database using the GenresInsertDTO object
        void InsertGenre(GenresInsertDTO genreInsertDTO);
        //Inserts a new award into the database using the AwardsInsertDTO object
        void InsertAward(AwardsInsertDTO awardsInsertDTO);
        //Inserts a new a Actor into the database using the ActorsInsertDTO object
        void InsertActor(ActorsInsertDTO actorsInsertDTO);
        #endregion

        #region PUT
        //Updates an existing movie in the database using the MoviesUpdateDTO object
        void UpdateMovie(MoviesUpdateDTO moviesUpdateDTO);
        #endregion

        #region DELETE
        //Deletes a movie from the database using the specified movie ID 
        void DeleteMovie(int movieId);
        #endregion
    }
}
