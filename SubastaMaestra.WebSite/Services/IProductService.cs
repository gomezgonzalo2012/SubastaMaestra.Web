using SubastaMaestra.Models.DTOs.Product;
using SubastaMaestra.Models.Utils;

namespace SubastaMaestra.WebSite.Services
{
    public interface IProductService
    {
        Task<List<ProductDTO>> GetAll();

        Task<(bool succes, string message)> CreateProduct(ProductCreateDTO productDTO);
        Task<HttpResponseMessage> CreateProduct2(MultipartFormDataContent content);

    }
}
