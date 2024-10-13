using SubastaMaestra.Models.DTOs.Product;
using SubastaMaestra.Models.Utils;

namespace SubastaMaestra.WebSite.Services
{
    public interface IProductService
    {
        Task<List<ProductDTO>> GetAll();

        Task<HttpContent> CreateProduct(ProductCreateDTO productDTO);
    }
}
