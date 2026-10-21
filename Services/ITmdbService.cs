using DollhouseCinema.Models;

namespace DollhouseCinema.Services;

public interface ITmdbService
{
    // searces tmdb and returns a list of films
    Task<List<Film>> SearchMoviesAsync(string query);

    // gets list of films from tmdb ids
    Task<List<Film>> GetFilmsByIdsAsync(List<int> ids);
}