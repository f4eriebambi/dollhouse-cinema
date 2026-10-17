using DollhouseCinema.Models;

namespace DollhouseCinema.Services;

public interface ITmdbService
{
    // searces tmdb and returns a list of films
    Task<List<Film>> SearchMoviesAsync(string query);
    Task<List<Film>> GetFilmsByIdsAsync(List<int> ids);
}