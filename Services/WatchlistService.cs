using DollhouseCinema.Models;

namespace DollhouseCinema.Services;

public class WatchlistService
{
    // sotring films in memory
    private readonly List<Film> _savedFilms = new();

    public void Add(Film film)
    {
        // make sure no duplicates
        if (!_savedFilms.Any(f => f.Title == film.Title))
        {
            _savedFilms.Add(film);
        }
    }

    public void Remove(Film film)
    {
        _savedFilms.RemoveAll(f => f.Title == film.Title);
    }

    public List<Film> GetAll()
    {
        return _savedFilms;
    }

    public bool IsSaved(Film film)
    {
        return _savedFilms.Any(f => f.Title == film.Title);
    }
}