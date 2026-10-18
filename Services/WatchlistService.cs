using DollhouseCinema.Models;

namespace DollhouseCinema.Services;

public class WatchlistService
{
    // sotring films in memory
    private readonly List<Film> _savedFilms = new();
    // watched films
    private readonly List<Film> _watchedFilms = new();

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

    // watched films
    public void MarkWatched(Film film)
        {
            Remove(film);
            
            // no duplicates
            if (!_watchedFilms.Any(f => f.Title == film.Title))
            {
                _watchedFilms.Add(film);
            }
        }
        
        public void UnmarkWatched(Film film)
        {
            _watchedFilms.RemoveAll(f => f.Title == film.Title);
        }
    
        public List<Film> GetWatched()
        {
            return _watchedFilms;
        }
    
        public bool IsWatched(Film film)
        {
            return _watchedFilms.Any(f => f.Title == film.Title);
        }
        
        // storing fav films
        private readonly List<Film> _favoriteFilms = new();

        public void AddFavorite(Film film)
        {
            if (!_favoriteFilms.Any(f => f.Title == film.Title))
            {
                _favoriteFilms.Add(film);
            }
        }

        public void RemoveFavorite(Film film)
        {
            _favoriteFilms.RemoveAll(f => f.Title == film.Title);
        }

        public List<Film> GetFavorites()
        {
            return _favoriteFilms;
        }

        public bool IsFavorite(Film film)
        {
            return _favoriteFilms.Any(f => f.Title == film.Title);
        }
}