using SubastaMaestra.WebSite.wwwroot.Components;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using SubastaMaestra.Models.DTOs.Bid;
namespace SubastaMaestra.WebSite.Services
{


    public class BidService : IBidService
    {
        private readonly HttpClient _httpClient;

        public BidService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> CreateBid(BidCreateDTO bid)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/Bid/create", bid);
            return response.IsSuccessStatusCode;
        }
    }
}
