using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace DollhouseCinema.Services;

public class OmdbService : IOmdbService
{
    // url
    private static readonly string OMDB_URL = "https://www.omdbapi.com/";

    // private fields
    private readonly HttpClient _http;
    private readonly string _apiKey;

    // constructor
    public OmdbService(HttpClient http, IConfiguration config)
    {
        _http = http;
        _apiKey = config["Omdb:ApiKey"] ?? throw new Exception("OMDb API key missing from config");
    }

    public async Task<string?> GetImdbRatingAsync(string title, int year)
    {
        // omdb uses query parameters , ahve to safely encode title
        var url = $"{OMDB_URL}?apikey={_apiKey}&t={Uri.EscapeDataString(title)}";
        
        // if we have a year, add it to the url to help omdb pick the right film
        if (year > 0)
        {
            url += $"&y={year}";
        }

        var response = await _http.GetFromJsonAsync<OmdbResponse>(url);

        // returns Response="False" if can't find film
        if (response == null || response.Response == "False")
        {
            return null;
        }

        // if rating is "N/A" , returns null
        if (string.IsNullOrWhiteSpace(response.ImdbRating) || response.ImdbRating == "N/A")
        {
            return null;
        }

        return response.ImdbRating;
    }
}

// mapping for omdb response
internal class OmdbResponse
{
    [JsonPropertyName("Response")]
    public string Response { get; set; } = "";

    [JsonPropertyName("imdbRating")]
    public string? ImdbRating { get; set; }
}