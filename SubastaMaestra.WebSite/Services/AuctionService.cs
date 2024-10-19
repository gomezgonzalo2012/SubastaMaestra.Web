using SubastaMaestra.Entities.Enums;
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

        public async Task<AuctionDTO> GetByIdAsync(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<OperationResult<AuctionDTO>>($"api/Auction/{id}");

            if (result.Success)
            {
                return result.Value;
            }
            throw new Exception(result.Message);
        }

        public async Task<List<AuctionDTO>> GetAuctionsByState(AuctionState state)
        {

            var result = await _httpClient.GetFromJsonAsync<OperationResult<List<AuctionDTO>>>($"api/Auction/list?state={(int)state}");

            if (result.Success)
            {
                return result.Value.Where(a => a.State == state).ToList();
            }
            throw new Exception(result.Message);

        }
    }
}
