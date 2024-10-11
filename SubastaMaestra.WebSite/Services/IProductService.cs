using SubastaMaestra.Models.DTOs.Product;

namespace SubastaMaestra.WebSite.Services
{
    public interface IProductService
    {
        Task<List<ProductDTO>> GetAll();
    }
}
