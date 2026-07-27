using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Demo.BlazorWasm;
using MudBlazor.Services;
using Demo.BlazorWasm.Services;

WebAssemblyHostBuilder builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(_ => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddMudServices();
builder.Services.AddScoped<IMarketDataService, SyntheticMarketDataService>();
builder.Services.AddScoped<ITechnicalAnalysisService, TechnicalAnalysisService>();
builder.Services.AddSingleton<ThemeState>();

await builder.Build().RunAsync();