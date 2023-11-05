using System.Collections.Generic;
using System.Threading.Tasks;

namespace UserControl.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<IUser>> GetAllUsersAsync();
        Task<IUser> GetUserByIdAsync(int userId);
        Task AddUserAsync(IUser user);
        Task UpdateUserAsync(IUser user);
        Task DeleteUserAsync(IUser user);
    }
}
