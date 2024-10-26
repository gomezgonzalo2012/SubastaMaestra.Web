using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using SubastaMaestra.WebSite;
using SubastaMaestra.WebSite.Services;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor.Services;
using SubastaMaestra.WebSite.Shared.Providers;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
// agregar servicio de local storage
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>(); // Nuestro proveedor de estado de autenticación

builder.Services.AddScoped<AuthenticationService>(); // Servicio para manejar autenticación

builder.Services.AddAuthorizationCore();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7093") });

builder.Services.AddScoped<IAuctionService, AuctionService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddSweetAlert2();
builder.Services.AddMudServices();
await builder.Build().RunAsync();
