using SubastaMaestra.Entities.Core;
using SubastaMaestra.Models.Utils;
using System.Net.Http.Json;

namespace SubastaMaestra.WebSite.Services
{
    public class ProductCategoryService : IProductCategoryService
    {

        private readonly HttpClient _httpClient;

        public ProductCategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ProductCategory>> GetCategoriesAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<OperationResult<List<ProductCategory>>>("/api/Category/list");
            if (response?.Value != null)
            {
                return response.Value;
            }

            return new List<ProductCategory>(); // Retornar lista vacía si no hay datos
        }

    }
}
