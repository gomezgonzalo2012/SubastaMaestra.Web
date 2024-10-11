using SubastaMaestra.Models.DTOs.Auction;
using SubastaMaestra.Models.DTOs.Product;
using SubastaMaestra.Models.Utils;
using System.Net.Http.Json;

namespace SubastaMaestra.WebSite.Services
{
    public class AuctionService : IAuctionService
    {
        private readonly HttpClient _httpClient;
        public AuctionService(HttpClient http)
        {
            _httpClient = http;
        }
        public async Task<List<AuctionDTO>> GetAll()
        {
            var result = await _httpClient.GetFromJsonAsync<OperationResult<List<AuctionDTO>>>("api/Auction/list");
            if (result.Success)
            {
                return result.Value;
            }
            throw new Exception(result.Message);
        }
    }
}
