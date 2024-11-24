using Blazored.LocalStorage;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using SubastaMaestra.WebSite;
using SubastaMaestra.WebSite.Services;
using SubastaMaestra.WebSite.Shared.Providers;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>(); // Nuestro proveedor de estado de autenticaci�n

builder.Services.AddScoped<AuthenticationService>(); // Servicio para manejar autenticaci�n

builder.Services.AddAuthorizationCore();

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://subastamaestraapi.azurewebsites.net") });
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7093") });

builder.Services.AddScoped<IAuctionService, AuctionService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductCategoryService, ProductCategoryService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IBidService, BidService>();
builder.Services.AddSweetAlert2();
builder.Services.AddMudServices();
await builder.Build().RunAsync();
