using SubastaMaestra.Entities.Enums;
using SubastaMaestra.Models.DTOs.Auction;
using SubastaMaestra.Models.DTOs.Product;
using SubastaMaestra.Models.Utils;

namespace SubastaMaestra.WebSite.Services
{
    public interface IProductService
    {
        Task<List<ProductDTO>> GetAll();

        Task<HttpContent> CreateProduct(ProductCreateDTO productDTO);
        Task<List<ProductDTO>> GetProductsByAuction(int auctionId);
    }
}
