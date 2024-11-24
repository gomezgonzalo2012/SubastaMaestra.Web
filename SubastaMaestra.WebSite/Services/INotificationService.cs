using SubastaMaestra.Models.Utils;

namespace SubastaMaestra.WebSite.Services
{
    public interface INotificationService
    {
        Task<OperationResult<bool>> MarkAsRead(int notifId);
        Task<int> CountNotifications(string userId);
    }
}
