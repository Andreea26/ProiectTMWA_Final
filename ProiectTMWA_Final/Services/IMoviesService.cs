using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ProiectTMWA_Final.Services
{
    public interface IMoviesService
    {
        Task<IList<Model.ApiMovie>> ShowAllMovies();

        Task<Model.ApiMovieWithDetails> ShowMovieDetails(int id);
    }
}
