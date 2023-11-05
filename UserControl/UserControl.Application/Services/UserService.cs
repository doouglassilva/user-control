using System.Collections.Generic;
using System.Threading.Tasks;
using UserControl.Domain.Interfaces;

namespace UserControl.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<IUser>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllUsersAsync();
        }

        public async Task<IUser> GetUserByIdAsync(int userId)
        {
            return await _userRepository.GetUserByIdAsync(userId);
        }

        public async Task AddUserAsync(IUser user)
        {
            await _userRepository.AddUserAsync(user);
        }

        public async Task UpdateUserAsync(IUser user)
        {
            await _userRepository.UpdateUserAsync(user);
        }

        public async Task DeleteUserAsync(IUser user)
        {
            await _userRepository.DeleteUserAsync(user);
        }
    }
}
