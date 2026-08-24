using backend.DTOs;
using backend.Models;
using Microsoft.EntityFrameworkCore;
using backend.Data;


//User services to delete and create users and get all users from the database
namespace backend.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _db;
        public UserService(AppDbContext db)
        {
            _db = db;
        }
        public async Task<List<UserResponseDto>> GetUsersAsync()
        {
            return await _db.Users
                .Select(u => new UserResponseDto
                {
                    Id = u.Id,
                    Name = u.Name,
                    Email = u.Email,
                    
                })
                .ToListAsync();
        }
        public async Task<UserResponseDto> CreateUserAsync(UserDto dto)
        {
            var user = new User
            {
                Name = dto.Name,
                Email = dto.Email
            };
            _db.Users.Add(user);
            await _db.SaveChangesAsync();
            return new UserResponseDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email
            };
        }
        public async Task<bool> DeleteUserAsync(int id)
        {
            var user = await _db.Users.FindAsync(id);
            if (user == null)
                return false;
            _db.Users.Remove(user);
            await _db.SaveChangesAsync();
            return true;
        }
    }

}