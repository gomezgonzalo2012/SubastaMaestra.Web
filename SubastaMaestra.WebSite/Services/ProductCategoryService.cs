using SubastaMaestra.Models.DTOs.Product;
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

        public async Task<List<CategoryDTO>> GetCategoriesAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<OperationResult<List<CategoryDTO>>>("/api/Category/list");
            if (response?.Value != null)
            {
                return response.Value;
            }

            return new List<CategoryDTO>(); // Retornar lista vacía si no hay datos
        }

    }
}
