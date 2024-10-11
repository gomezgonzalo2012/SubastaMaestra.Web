using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using SubastaMaestra.WebSite;
using SubastaMaestra.WebSite.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5083") });

builder.Services.AddScoped<IAuctionService, AuctionService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddSweetAlert2();
await builder.Build().RunAsync();
