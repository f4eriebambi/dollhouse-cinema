using System.Net.Http.Json;
using System.Text.Json.Serialization;
using DollhouseCinema.Models;

namespace DollhouseCinema.Services;

public class TmdbService : ITmdbService
{
    // private properties
    private readonly HttpClient _http;
    private readonly string _token;
    
    // genre mapping https://developers.themoviedb.org/3/genres/get-movie-list
    private static readonly Dictionary<int, string> GenreMap = new()
    {
        { 28, "action" }, { 12, "adventure" }, { 16, "animation" }, { 35, "comedy" },
        { 80, "crime" }, { 99, "documentary" }, { 18, "drama" }, { 10751, "family" },
        { 14, "fantasy" }, { 36, "history" }, { 27, "horror" }, { 10402, "music" },
        { 9648, "mystery" }, { 10749, "romance" }, { 878, "sci-fi" }, { 10770, "tv movie" },
        { 53, "thriller" }, { 10752, "war" }, { 37, "western" }
    };
    
    private static string GetGenreNames(List<int> genreIds)
    {
        if (genreIds == null || genreIds.Count == 0)
        {
            return "film";
        }
        
        var names = genreIds
            .Where(id => GenreMap.ContainsKey(id))
            .Select(id => GenreMap[id])
            .Take(2); // just take the first 2 so it doesn't get too long

        return string.Join(" · ", names);
    }

    // constructor
    public TmdbService(HttpClient http, IConfiguration config)
    {
        _http = http;
        _token = config["Tmdb:Token"] ?? throw new Exception("TMDB token missing from config");
    }

    public async Task<List<Film>> SearchMoviesAsync(string query)
    {
        // tmdb search https://developers.themoviedb.org/3/search/search-movies
        var request = new HttpRequestMessage(HttpMethod.Get, $"https://api.themoviedb.org/3/search/movie?query={Uri.EscapeDataString(query)}");
        
        request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _token);

        var response = await _http.SendAsync(request);
        response.EnsureSuccessStatusCode();

        var data = await response.Content.ReadFromJsonAsync<TmdbSearchResponse>();

        if (data?.Results == null)
        {
            return new List<Film>();
        }

        // map the results to film model
        return data.Results.Select(r => new Film(
            r.Title,
            ParseYear(r.ReleaseDate),
            GetGenreNames(r.GenreIds),
            r.Overview,
            string.IsNullOrEmpty(r.PosterPath) ? "images/placeholder.jpg" : $"https://image.tmdb.org/t/p/w500{r.PosterPath}" 
            )).ToList();
    }
    
    // get films by ids
    public async Task<List<Film>> GetFilmsByIdsAsync(List<int> ids)
    {
        var films = new List<Film>();

        foreach (var id in ids)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://api.themoviedb.org/3/movie/{id}");
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _token);

            var response = await _http.SendAsync(request);
            if (!response.IsSuccessStatusCode)
            {
                continue; // skips if not found
            }

            var data = await response.Content.ReadFromJsonAsync<TmdbMovie>();
            if (data == null)
            {
                continue;
            }
            
            var genreString = data.Genres.Count > 0 ? string.Join(" · ", data.Genres.Take(2).Select(g => g.Name.ToUpper())) : "film";

            films.Add(new Film(
                data.Title,
                ParseYear(data.ReleaseDate),
                genreString,
                data.Overview,
                string.IsNullOrEmpty(data.PosterPath) ? "images/placeholder.jpg" : $"https://image.tmdb.org/t/p/w500{data.PosterPath}"
            ));
        }

        return films;
    }

    private static int ParseYear(string? releaseDate)
    {
        if (string.IsNullOrEmpty(releaseDate) || releaseDate.Length < 4)
        {
            return 0;
        }

        return int.TryParse(releaseDate.Substring(0, 4), out var year) ? year : 0;
    }
}

// tmdb search response model
internal class TmdbSearchResponse
{
    [JsonPropertyName("results")]
    public List<TmdbMovie>? Results { get; set; }
}

// mapping tmdb movei data to film model
internal class TmdbMovie
{
    [JsonPropertyName("title")]
    public string Title { get; set; } = "";
    
    [JsonPropertyName("release_date")]
    public string? ReleaseDate { get; set; }
    
    [JsonPropertyName("overview")]
    public string Overview { get; set; } = "";

    [JsonPropertyName("genre_ids")]
    public List<int> GenreIds { get; set; } = new();

    // gets genres from movie details endpoitn
    [JsonPropertyName("genres")]
    public List<TmdbGenre> Genres { get; set; } = new();

    [JsonPropertyName("poster_path")]
    public string? PosterPath { get; set; }
}

// helper class forgenres array
internal class TmdbGenre
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = "";
}