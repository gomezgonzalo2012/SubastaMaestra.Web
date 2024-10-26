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

        public async Task<(bool succes , string message)> CreateProduct(ProductCreateDTO productDTO)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Product", productDTO);
            string message;
            bool succes = false;
            if (response.IsSuccessStatusCode)
            {
                message= "Exitosamente cargado";
                succes = true;
            }
            // Si la respuesta no fue exitosa, leer el contenido como string
            var errorContent = await response.Content.ReadAsStringAsync();

            // Si el contenido no es nulo o vacío, usarlo como mensaje de error
            if (!string.IsNullOrEmpty(errorContent))
            {
                message = $"Error from server: {errorContent}";
            }
            else
            {
                // Si no hay contenido, usar un mensaje de error genérico
                message = $"Error: {response.StatusCode} {response.ReasonPhrase}";
            }
            return  (succes,message);

        }

        public async Task<HttpResponseMessage> CreateProduct2(MultipartFormDataContent content)
        { 

            var response = await _httpClient.PostAsync("api/Product", content);

            return response;

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
