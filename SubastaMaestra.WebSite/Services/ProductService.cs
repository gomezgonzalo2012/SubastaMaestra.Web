using SubastaMaestra.Entities.Core;
using SubastaMaestra.Models.DTOs.Product;
using SubastaMaestra.Models.Utils;
using SubastaMaestra.WebSite.Pages;
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

        public async Task<List<ProductDTO>> GetProductsByAuction(int auctionId)
        {
            // Asume que la API devuelve un OperationResult<List<ProductDTO>>
            var result = await _httpClient.GetFromJsonAsync<OperationResult<List<ProductDTO>>>($"api/Product/subasta/{auctionId}");

            // Verifica si el resultado no es nulo y si la operación fue exitosa
            if (result != null && result.Success && result.Value != null)
            {
                return result.Value; // Devuelve la lista de productos si está todo bien
            }

            // Manejar el caso de que no haya productos o la operación no haya sido exitosa
            throw new Exception(result?.Message ?? "Error al obtener los productos de la subasta");
        }
    }
}
