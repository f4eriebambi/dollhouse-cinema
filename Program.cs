using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using DollhouseCinema;
using DollhouseCinema.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// add services to the container.
builder.Services.AddScoped<ITmdbService, TmdbService>();
builder.Services.AddScoped<IOmdbService, OmdbService>();
builder.Services.AddSingleton<WatchlistService>();

await builder.Build().RunAsync();