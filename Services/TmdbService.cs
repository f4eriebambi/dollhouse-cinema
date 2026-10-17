using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using DollhouseCinema.Models;

namespace DollhouseCinema.Services;

public class TmdbService : ITmdbService
{
    // private properties
    private readonly HttpClient _http;
    private readonly string _token;

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
            "film", // placeholder genre , map to genre todo
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
            if (!response.IsSuccessStatusCode) continue; // skips if not found

            var data = await response.Content.ReadFromJsonAsync<TmdbMovie>();
            if (data == null) continue;

            films.Add(new Film(
                data.Title,
                ParseYear(data.ReleaseDate),
                "film",
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
    
    [JsonPropertyName("poster_path")]
    public string? PosterPath { get; set; }
}