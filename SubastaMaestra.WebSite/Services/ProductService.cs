using SubastaMaestra.Models.DTOs.Product;
using SubastaMaestra.Models.Utils;
using System.Net.Http.Json;

namespace SubastaMaestra.WebSite.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient http )
        {
               _httpClient = http;
        }

        public async Task<List<ProductDTO>> GetAll()
        {
            
            var result = await _httpClient.GetFromJsonAsync<OperationResult<List<ProductDTO>>>("api/Product/list");
            if (result.Success)
            {
               return (result.Value);
            }

            throw new Exception(result.Message);
            


        }
    }
}
