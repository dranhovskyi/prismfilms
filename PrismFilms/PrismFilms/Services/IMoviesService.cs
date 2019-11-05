using System.Collections.Generic;
using System.Threading.Tasks;
using PrismFilms.Models;

namespace PrismFilms.Services
{
    public interface IMoviesService
    {
        Task<List<Movie>> GetMoviesAsync(string uri);
    }
}