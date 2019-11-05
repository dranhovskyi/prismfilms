using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PrismFilms.Models;
using PrismFilms.RestClient;

namespace PrismFilms.Services
{
    public class MoviesService : IMoviesService
    {
        public async Task<List<Movie>> GetMoviesAsync(string uri)
        {
            RestClient<Movie> restClient = new RestClient<Movie>();
            var moviesList = await restClient.GetAsync(uri);
            return moviesList;
        }
    }
}
