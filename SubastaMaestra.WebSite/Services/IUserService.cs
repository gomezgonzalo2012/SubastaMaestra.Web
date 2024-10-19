using SubastaMaestra.Models.DTOs.User;
using SubastaMaestra.Models.Utils;
using System.Net.Http;

namespace SubastaMaestra.WebSite.Services
{
    public interface IUserService
    {

        Task<OperationResult<int>?>Register(UserCreateDTO userCreateDTO);



    }
}
