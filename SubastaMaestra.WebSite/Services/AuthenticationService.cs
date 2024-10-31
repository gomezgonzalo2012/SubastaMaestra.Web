using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using SubastaMaestra.Models.DTOs.User;
using SubastaMaestra.WebSite.Shared.Providers;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SubastaMaestra.WebSite.Services;
public class AuthenticationService
{
    private readonly HttpClient _httpClient;
    private readonly ILocalStorageService _localStorage;
    private readonly AuthenticationStateProvider _authenticationStateProvider;

    public AuthenticationService(HttpClient httpClient, ILocalStorageService localStorage, AuthenticationStateProvider authenticationStateProvider)
    {
        _httpClient = httpClient;
        _localStorage = localStorage;
        _authenticationStateProvider = authenticationStateProvider;
    }

    public async Task<bool> Login(LoginRequestDTO loginRequest)
    {
        var response = await _httpClient.PostAsJsonAsync("/login", loginRequest);


        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadFromJsonAsync<TokenResponse>(); // Clase para recibir el token

            await _localStorage.SetItemAsync("authToken", content.Token); // Almacenar token en local storage

            ((CustomAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsAuthenticated(content.Token);
            ((CustomAuthenticationStateProvider)_authenticationStateProvider).NotifyAuthState();


            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", content.Token);

            return true;
        }

        return false;
    }

    public async Task Logout()
    {
        await _localStorage.RemoveItemAsync("authToken");
        ((CustomAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsLoggedOut();
        _httpClient.DefaultRequestHeaders.Authorization = null;
    }

    public async Task<string> GetUserId()
    {
        var token = await _localStorage.GetItemAsync<string>("authToken");

        if (token == null)
            return null;

        var handler = new JwtSecurityTokenHandler();
        var jwtToken = handler.ReadJwtToken(token);

        var userIdClaim = jwtToken.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier);

        return userIdClaim?.Value; // Devuelve el UserId o null si no se encuentra
    }
}

public class TokenResponse
{
    public string Token { get; set; }
}
