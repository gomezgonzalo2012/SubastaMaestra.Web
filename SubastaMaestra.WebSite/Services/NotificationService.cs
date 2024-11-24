using SubastaMaestra.Entities.Core;
using SubastaMaestra.Models.DTOs;
using SubastaMaestra.Models.DTOs.Product;
using SubastaMaestra.Models.Utils;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;

namespace SubastaMaestra.WebSite.Services
{
    public class NotificationService :  INotificationService
    {
        private readonly HttpClient _httpClient;

        public NotificationService(HttpClient http) 
        {
            _httpClient = http;
        }
        public async Task<OperationResult<bool>> MarkAsRead(int notifId)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync($"api/Notification/marcar/{notifId}", notifId);

                if (response.IsSuccessStatusCode)
                {
                    return new OperationResult<bool>
                    {
                        Success = true,
                        Message = "Notificación marcada como leída con éxito.",
                        Value = true
                    };
                }

                // Manejo del caso en que no sea exitoso
                return new OperationResult<bool>
                {
                    Success = false,
                    Message = $"Error al marcar la notificación como leída: {response.ReasonPhrase}",
                    Value = false
                };
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                return new OperationResult<bool>
                {
                    Success = false,
                    Message = $"Ocurrió un error: {ex.Message}",
                    Value = false
                };
            }
        }

        public async Task<int> CountNotifications(string userId)
        {
            var result = new List<NotificationDTO>();
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
                    result = JsonSerializer.Deserialize<List<NotificationDTO>>(valueElement.GetRawText(), new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    }) ?? new List<NotificationDTO>();
                }
                var noMarkedCount = result.Where(n=>n.State==false).Count();
                return noMarkedCount;
            }
            return 0;
        }

    }
}
