using SubastaMaestra.Models.DTOs;
using SubastaMaestra.Models.DTOs.Bid;
using SubastaMaestra.Models.DTOs.Product;
using SubastaMaestra.Models.DTOs.User;
using SubastaMaestra.Models.Utils;
using System.Net.Http;

namespace SubastaMaestra.WebSite.Services
{
    public interface IUserService
    {

        Task<OperationResult<int>?> Register(UserCreateDTO userCreateDTO);

        Task<List<ProductDTO>> GetMyProducts(int userId);
        Task<List<BidDTO>> GetMyBids(int userId);
        Task<List<NotificationDTO>> GetNotificationsAsync(string userId);

    }
}
