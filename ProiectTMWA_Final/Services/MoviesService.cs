using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ProiectTMWA_Final.Model;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;

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

                return new ApiMovieWithDetails
                {
                    Id = movie.id,
                    Name = movie.name,
                    Description = movie.description,
                    Rating = movie.rating,
                    Genres = movie.genres,
                    ImageThumbnailPath = movie.image_thumbnail_path
                };

            }
        }
    }
}
