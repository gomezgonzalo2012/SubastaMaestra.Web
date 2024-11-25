using SubastaMaestra.Models.DTOs.Auction;
using SubastaMaestra.Models.DTOs.Bid;
using SubastaMaestra.Models.DTOs;
using SubastaMaestra.Models.DTOs.Product;
using SubastaMaestra.Models.DTOs.User;
using SubastaMaestra.Models.Utils;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text.Json;

namespace SubastaMaestra.WebSite.Services
{
    public class UserService : IUserService
    {

        private readonly HttpClient _httpClient;

        public UserService(HttpClient http)
        {
            _httpClient = http;
        }

        public async Task<OperationResult<int>?> Register(UserCreateDTO userCreateDTO)
        {

            var result = await _httpClient.PostAsJsonAsync("api/User/register", userCreateDTO);
            if (result.IsSuccessStatusCode)
            {

                var content = await result.Content.ReadFromJsonAsync<OperationResult<int>>();
                return content;

            }
            throw new Exception("Error, no se puede registrar");
        }

        public async Task<List<ProductDTO>> GetMyProducts(int userId)
        {
            var response = await _httpClient.GetAsync($"api/User/misProductos/{userId}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var operationResult = JsonSerializer.Deserialize<OperationResult<List<ProductDTO>>>(content, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                if (operationResult.Success || operationResult.Value.Count > 0)
                {
                    return operationResult.Value;

                }

            }
            return new List<ProductDTO>();

        }
        public async Task<List<BidDTO>> GetMyBids(int userId)
        {
            var response = await _httpClient.GetAsync($"api/User/misOfertas/{userId}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var operationResult = JsonSerializer.Deserialize<OperationResult<List<BidDTO>>>(content, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                if (operationResult.Success || operationResult.Value.Count > 0)
                {
                    return operationResult.Value;

                }

            }
            return new List<BidDTO>();

        }
        public async Task<List<NotificationDTO>> GetNotificationsAsync(string userId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"/{userId}/notifications");

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();

                    // Usar JsonDocument para navegar el JSON y extraer solo el campo "value"
                    using var document = JsonDocument.Parse(jsonResponse);
                    var root = document.RootElement;

                    // Extraer y deserializar el campo "value" directamente
                    if (root.TryGetProperty("value", out var valueElement))
                    {
                        return JsonSerializer.Deserialize<List<NotificationDTO>>(valueElement.GetRawText(), new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true
                        }) ?? new List<NotificationDTO>();
                    }
                }
                else
                {
                    Console.WriteLine("Error: " + response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deserializando las notificaciones: {ex.Message}");
            }

            return new List<NotificationDTO>();
        }


    }

}
