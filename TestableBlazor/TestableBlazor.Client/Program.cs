using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TestableBlazor.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IDataService, HttpDataService>();
builder.Services.AddTelerikBlazor();
builder.Services.AddScoped<IRenderModeIndicator, WebassemblyRenderModeIndicator>();
await builder.Build().RunAsync();
