using SubastaMaestra.Entities.Core;
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

        public async Task<HttpContent> CreateProduct(ProductCreateDTO productDTO)
        {
            var result = await _httpClient.PostAsJsonAsync<ProductCreateDTO>("api/Product", productDTO);
            if (result.IsSuccessStatusCode)
            {
                return result.Content;
            }
            else
            {
                return result.Content;
            }
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
