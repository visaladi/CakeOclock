using Microsoft.AspNetCore.Identity;

namespace TangyWeb_Server.Service.IService
{
    public interface IUserService
    {
        public interface IUserService
        {
            Task<List<IdentityUser>> GetUsersAsync();
            Task<IdentityUser> GetUserByIdAsync(string userId);
            Task<bool> UpdateUserAsync(IdentityUser user);
            Task<bool> DeleteUserAsync(string userId);
        }
    }
}
