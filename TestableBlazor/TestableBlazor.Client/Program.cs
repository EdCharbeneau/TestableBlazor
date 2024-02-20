using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TestableBlazor.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IDataService, HttpDataService>();
builder.Services.AddTelerikBlazor();
await builder.Build().RunAsync();
