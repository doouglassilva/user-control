using System.Collections.Generic;
using System.Threading.Tasks;
using UserControl.Domain.Interfaces;

namespace UserControl.Application.Services
{
    public interface IUserService
    {
        Task<IEnumerable<IUser>> GetAllUsersAsync();
        Task<IUser> GetUserByIdAsync(int userId);
        Task AddUserAsync(IUser user);
        Task UpdateUserAsync(IUser user);
        Task DeleteUserAsync(IUser user);
    }
}
