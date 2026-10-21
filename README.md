![.NET](https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![Blazor](https://img.shields.io/badge/Blazor-512BD4?style=for-the-badge&logo=blazor&logoColor=white)
![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)

# dollhouse cinema

*a little home for your cinematic obsessions*

Dollhouse cinema is a personal film discovery, collection and wathclist application. Built with C# and Blazor WebAssembly for SOA CA1.

## features
- search for films using the tmdb api
- view detailed film information, including imdb ratings from the omdb api
- save films to a personal watchlist
- mark films as watched, give personal ratings and write notes
- diary checks the date watched is not before the film's release year
- save favorite films to "keepsakes ♡" in Dollhouse
- browse themed film collections (e.g., "weird girl movies", "comfort <333")

## how to run
1. open the solution in rider or visual studio
2. the app needs a key for each api. create `wwwroot/appsettings.Development.json` with your own keys:
```json
{
  "Tmdb": {
    "Token": "YOUR_TMDB_TOKEN"
  },
  "Omdb": {
    "ApiKey": "YOUR_OMDB_KEY"
  }
}
```
3. run the DollhouseCinema project

## api integration & security
This application uses two third-party APIs:
1. **tmdb (The Movie Database):** Used for film searches, browsing, genre information and poster images
2. **omdb api (Open Movie Database):** Used to get extra film details, icnlduign the IMDb rating

**security note:** Blazor WebAssembly runs in the browser, meaning client-side configuration and application code can be inspected by users. The development configuration file containing my local API keys is excluded from source control using .gitignore, while the committed appsettings.json contains placeholder values.

## unit tests
unit tests are in the `DollhouseCinema.UnitTests` project and use NUnit. run them with Test > Run all tests.
- `WatchlistServiceTests`: adding, removing, duplicates, watched films, favourites, sorting and null checks
- `TmdbServiceTests`: parsing the release year (valid, invalid, missing, empty and too short)

the apis were tested by hand before coding, so the unit tests only cover my own code and never call the apis.

## project structure
- `Models`: Film and the curated collection data
- `Services`: the tmdb, omdb and watchlist services (with interfaces for the api ones)
- `Pages`: the lobby, explore, watchlist, screening room and dollhouse pages
- `Components`: the film details, diary and confirm pop-ups
- `Layout`: the main layout and nav menu
- `DollhouseCinema.UnitTests`: the nunit tests

## references
- **tmdb api:**
  - [Getting Started](https://developer.themoviedb.org/docs/getting-started)
  - [Search Movies Endpoint](https://developer.themoviedb.org/reference/search-movie)
  - [Movie Details Endpoint](https://developer.themoviedb.org/reference/movie-details)
  - [Genre List](https://developer.themoviedb.org/reference/genre-movie-list)
- **omdb api:**
  - [OMDb API Docs](https://www.omdbapi.com/)
- **blazor & .net documentation:**
  - [Blazor Configuration](https://learn.microsoft.com/en-us/aspnet/core/blazor/fundamentals/configuration?view=aspnetcore-10.0)
  - [Blazor JS Interop](https://learn.microsoft.com/en-us/aspnet/core/blazor/javascript-interoperability/call-javascript-from-dotnet?view=aspnetcore-10.0)
  - [Blazor Routing & Navigation](https://learn.microsoft.com/en-us/aspnet/core/blazor/fundamentals/navigation?view=aspnetcore-10.0)
- **unit testing:**
  - [.NET Unit Testing Best Practices](https://learn.microsoft.com/en-us/dotnet/core/testing/unit-testing-best-practices)
  - unit testing lecture slides (NUnit project setup and Assert.That)
- **css:**
  - Star loader adapted from [css-loaders.com](https://css-loaders.com/progress/)

## attribution
This product uses the TMDB API but is not endorsed or certified by TMDB.
Film ratings provided by OMDb API.