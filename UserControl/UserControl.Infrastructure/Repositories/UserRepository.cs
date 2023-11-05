using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserControl.Domain.Interfaces;

namespace UserControl.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<IUser>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<IUser> GetUserByIdAsync(int userId)
        {
            return await _context.Users.FindAsync(userId);
        }

        public async Task AddUserAsync(IUser user)
        {
            _context.Users.Add(user as User); // Conversão necessária
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUserAsync(IUser user)
        {
            _context.Entry(user as User).State = EntityState.Modified; // Conversão necessária
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(IUser user)
        {
            _context.Users.Remove(user as User); // Conversão necessária
            await _context.SaveChangesAsync();
        }
    }
}
