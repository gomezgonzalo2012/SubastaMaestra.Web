using SubastaMaestra.WebSite.wwwroot.Modals;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using SubastaMaestra.Models.DTOs.Bid;
using SubastaMaestra.Models.Utils;
namespace SubastaMaestra.WebSite.Services
{


    public class BidService : IBidService
    {
        private readonly HttpClient _httpClient;

        public BidService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<(bool Success, string Message)> CreateBid(BidCreateDTO bid)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("/api/Bid/create", bid);

                // Variables para el mensaje y éxito
                string Message = string.Empty;
                bool success = false;

                if (response.IsSuccessStatusCode)
                {
                    // Si la operación fue exitosa
                    var result = await response.Content.ReadFromJsonAsync<OperationResult<BidCreateDTO>>();
                    // Procesamos el resultado de la operación exitosa
                    success = true;
                    Message = "Oferta realizada exitosamente";  // O el mensaje adecuado que desees mostrar
                }
                else
                {
                    // Si la operación falló, obtenemos el mensaje de error
                    Message = await response.Content.ReadAsStringAsync();
                }

                // Devolvemos el resultado de la operación
                return (success, Message);
            }
            catch (Exception ex)
            {
                // Manejo de excepciones en caso de errores en el cliente.
                return (false, $"Error al realizar la oferta: {ex.Message}");
            }
        }

    }
}
