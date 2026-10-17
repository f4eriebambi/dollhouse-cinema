namespace DollhouseCinema.Services;

public interface IOmdbService
{
    // gets imdb rating for film based on title and year
    Task<string?> GetImdbRatingAsync(string title, int year);
}