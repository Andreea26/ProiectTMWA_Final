using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ProiectTMWA_Final.Model;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;
using SQLite;
using ProiectTMWA_Final.Helpers;

namespace ProiectTMWA_Final.Services
{
    class MoviesService : IMoviesService
    {
        const string allMoviesUrl = "https://www.episodate.com/api/most-popular?page=1";
        const string showDetailsUrl = "https://www.episodate.com/api/show-details?q={0}";

        public async Task<IList<ApiMovie>> ShowAllMovies()
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetStringAsync(string.Format(allMoviesUrl));
                dynamic moviesData = JsonConvert.DeserializeObject<JObject>(response);

                var results = new List<Model.ApiMovie>();

                foreach (var movie in moviesData?.tv_shows) {
                    results.Add(new ApiMovie
                    {
                        Id = movie.id,
                        Name = movie.name,
                        ImageThumbnailPath = movie.image_thumbnail_path
                    });
                }

                return results;
   
            }

        }

        public async Task<ApiMovieWithDetails> ShowMovieDetails(int id)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetStringAsync(string.Format(showDetailsUrl, id));
                dynamic movieDetails = JsonConvert.DeserializeObject<JObject>(response);

                var movie = movieDetails?.tvShow;

                List<string> genres = JsonConvert.DeserializeObject<List<string>>(movie.genres.ToString());
                return new ApiMovieWithDetails
                {
                    Id = movie.id,
                    Name = movie.name,
                    Description = movie.description,
                    Rating = movie.rating,
                    Genres = genres,
                    ImageThumbnailPath = movie.image_thumbnail_path
                };

            }
        }

        public ResponseStatus AddMovieToMyList(string movieName, StatusType status)
        {

            ResponseStatus response;

            ApiMovie newMovie = new ApiMovie
            {
                Name = movieName,
                Status = status
            };

            return AddMovie(out response, newMovie);
        }

        public ResponseStatus AddMovieToMyList(string movieName, StatusType status, int id)
        {
            ResponseStatus response;

            ApiMovie newMovie = new ApiMovie
            {
                Id = id,
                Name = movieName,
                Status = status
            };
            return AddMovie(out response, newMovie);
        }

        private static ResponseStatus AddMovie(out ResponseStatus response, ApiMovie newMovie)
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.DB_PATH))
            {
                try
                {
                    conn.CreateTable<ApiMovie>();
                    int nb = conn.Insert(newMovie);

                    response = nb > 0 ? ResponseStatus.OK : ResponseStatus.NOT_OK;
                }
                catch (SQLiteException ex)
                {
                    response = ResponseStatus.EXIST;
                }

                return response;
            }
        }

        public ResponseStatus RemoveMovie(int movieId)
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.DB_PATH))
            {

                int nb = conn.Delete<ApiMovie>(movieId);

                return nb > 0 ? ResponseStatus.OK : ResponseStatus.NOT_OK;
            }
        }

        public ResponseStatus UpdateProgress(int movieId, StatusType newStatus)
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.DB_PATH))
            {
                var movie = conn.Get<ApiMovie>(movieId);
                movie.Status = newStatus;

                int nb = conn.Update(movie);

                return nb > 0 ? ResponseStatus.OK : ResponseStatus.NOT_OK;
            }
        }

    }
}
