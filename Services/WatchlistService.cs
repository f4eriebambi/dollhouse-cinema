using DollhouseCinema.Models;

namespace DollhouseCinema.Services;

public class WatchlistService
{
    // sotring films in memory
    private readonly List<Film> _savedFilms = new();
    // watched films
    private readonly List<Film> _watchedFilms = new();
    // storing fav films
    private readonly List<Film> _favoriteFilms = new();

    // saved films
    public void Add(Film film)
    {
        ArgumentNullException.ThrowIfNull(film);

        // make sure no duplicates
        if (!_savedFilms.Any(f => string.Equals(f.Title, film.Title, StringComparison.OrdinalIgnoreCase)))
        {
            _savedFilms.Add(film);
        }
    }

    // remove film from saved list
    public void Remove(Film film)
    {
        ArgumentNullException.ThrowIfNull(film);
        _savedFilms.RemoveAll(f => string.Equals(f.Title, film.Title, StringComparison.OrdinalIgnoreCase));
    }

    // get all saved films
    public IReadOnlyList<Film> GetAll()
    {
        return _savedFilms;
    }

    // check if film is saved
    public bool IsSaved(Film film)
    {
        ArgumentNullException.ThrowIfNull(film);
        return _savedFilms.Any(f => string.Equals(f.Title, film.Title, StringComparison.OrdinalIgnoreCase));
    }

    // mark film as watched
    public void MarkWatched(Film film)
    {
        ArgumentNullException.ThrowIfNull(film);

        Remove(film);

        // no duplicates
        if (!_watchedFilms.Any(f => string.Equals(f.Title, film.Title, StringComparison.OrdinalIgnoreCase)))
        {
            _watchedFilms.Add(film);
        }
    }

    // unmark film as watched
    public void UnmarkWatched(Film film)
    {
        ArgumentNullException.ThrowIfNull(film);
        _watchedFilms.RemoveAll(f => string.Equals(f.Title, film.Title, StringComparison.OrdinalIgnoreCase));
    }

    // get all watched films
    public IReadOnlyList<Film> GetWatched()
    {
        return _watchedFilms;
    }

    // check if film is watched
    public bool IsWatched(Film film)
    {
        ArgumentNullException.ThrowIfNull(film);
        return _watchedFilms.Any(f => string.Equals(f.Title, film.Title, StringComparison.OrdinalIgnoreCase));
    }

    // add film to keppsakes
    public void AddFavorite(Film film)
    {
        ArgumentNullException.ThrowIfNull(film);

        if (!_favoriteFilms.Any(f => string.Equals(f.Title, film.Title, StringComparison.OrdinalIgnoreCase)))
        {
            _favoriteFilms.Add(film);
        }
    }

    // remove film from keppsakes
    public void RemoveFavorite(Film film)
    {
        ArgumentNullException.ThrowIfNull(film);
        _favoriteFilms.RemoveAll(f => string.Equals(f.Title, film.Title, StringComparison.OrdinalIgnoreCase));
    }

    // get all fav films 
    public IReadOnlyList<Film> GetFavorites()
    {
        return _favoriteFilms;
    }

    // check if film is favorited 
    public bool IsFavorite(Film film)
    {
        ArgumentNullException.ThrowIfNull(film);
        return _favoriteFilms.Any(f => string.Equals(f.Title, film.Title, StringComparison.OrdinalIgnoreCase));
    }
}