using SubastaMaestra.Models.DTOs.Auction;
using SubastaMaestra.Models.DTOs.User;
using SubastaMaestra.Models.Utils;
using System.Net.Http.Json;

namespace SubastaMaestra.WebSite.Services
{
    public class UserService : IUserService
    {

        private readonly HttpClient _httpClient;

        public UserService(HttpClient http)
        {
            _httpClient = http;
        }

        public async Task<OperationResult<int>?>Register(UserCreateDTO userCreateDTO)
        {

            var result = await _httpClient.PostAsJsonAsync("api/User/register", userCreateDTO);
            if (result.IsSuccessStatusCode)
            {

                var content = await result.Content.ReadFromJsonAsync<OperationResult<int>>();
                return content;

            }
            throw new Exception("Error, no se puede registrar");
        }



}
}
