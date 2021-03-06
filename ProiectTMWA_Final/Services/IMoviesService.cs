using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using ProiectTMWA_Final.Model;
using ProiectTMWA_Final.Helpers;

namespace ProiectTMWA_Final.Services
{
    public interface IMoviesService
    {
        Task<IList<Model.ApiMovie>> ShowAllMovies();

        Task<Model.ApiMovieWithDetails> ShowMovieDetails(int id);

        ResponseStatus AddMovieToMyList(string movieName, StatusType status);

        IList<ApiMovie> GetAllMovies();

        ResponseStatus AddMovieToMyList(string movieName, StatusType status, int id);

        ResponseStatus RemoveMovie(int movieId);

        ResponseStatus UpdateProgress(int movieId, StatusType newStatus);
    }
}
