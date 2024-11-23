using SubastaMaestra.Entities.Enums;
using SubastaMaestra.Models.DTOs.Auction;
using SubastaMaestra.Models.DTOs.Product;
using SubastaMaestra.Models.Utils;

namespace SubastaMaestra.WebSite.Services
{
    public interface IProductService
    {
        Task<List<ProductDTO>> GetAll();

        Task<(bool succes, string message)> CreateProduct(ProductCreateDTO productDTO);
        Task<List<ProductDTO>> GetProductsByAuction(int auctionId);
        Task<ProductDTO> GetProductByIdAsync(int id);
    }
}
