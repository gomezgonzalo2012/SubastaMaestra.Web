using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using SubastaMaestra.Models.DTOs.User;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
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

    public async Task<bool> Login(UserDTO user)
    {
        var response = await _httpClient.PostAsJsonAsync("api/login/authenticate", user);

        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadFromJsonAsync<TokenResponse>(); // Clase para recibir el token

            await _localStorage.SetItemAsync("authToken", content.Token); // Almacenar token en local storage

            ((CustomAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsAuthenticated(content.Token);

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
}

public class TokenResponse
{
    public string Token { get; set; }
}
