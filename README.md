# dollhouse cinema

*a little home for your cinematic obsessions*

Dollhouse cinema is a personal film discovery, collection and wathclist application. Built with C# and Blazor WebAssembly for SOA CA1.

## features
- search for films using the tmdb api
- view detailed film information, including imdb ratings from the omdb api
- save films to a personal watchlist
- mark films as watched, give personal ratings and write notes 
- save favorite films to "keepsakes ♡" in Dollhouse
- browse themed film collections (e.g., "weird girl movies", "comfort <333")

## api integration & security
This application uses two third-party APIs:
1. **tmdb (The Movie Database):** Used for film searches, browsing, genre information and poster images
2. **omdb api (Open Movie Database):** Used to get extra film details, icnlduign the IMDb rating

**security note:** Blazor WebAssembly runs in the browser, meaning client-side configuration and application code can be inspected by users. The development configuration file containing my local API keys is excluded from source control using .gitignore, while the committed appsettings.json contains placeholder values.

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
  - [NUnit Assertions Tutorial](https://dotnetpattern.com/nunit-assert-examples)
- **css:**
  - Star loader adapted from [css-loaders.com](https://css-loaders.com/progress/)

## attribution
This product uses the TMDB API but is not endorsed or certified by TMDB.
Film ratings provided by OMDb API.