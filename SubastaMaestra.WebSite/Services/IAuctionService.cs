using SubastaMaestra.Models.DTOs.Auction;

namespace SubastaMaestra.WebSite.Services
{
    public interface IAuctionService
    {
        Task<List<AuctionDTO>> GetAll();
        Task<AuctionDTO> GetByIdAsync(int id);

    }
}
