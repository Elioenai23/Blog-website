using backend.Data;
using backend.DTOs;
using backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace backend.Services
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;

        public AuthService(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<string> RegisterAsync(RegisterDto dto) // Register a new user
        {
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(dto.Password); // Hash the password using BCrypt

            var exists = await _context.Users.AnyAsync(u => u.Email == dto.Email); // Check if a user with the same email already exists in the database
            if (exists) 
                throw new Exception("Email already in use"); // If a user with the same email exists, throw an exception

            var user = new User
            {
                Name = dto.Name,
                Email = dto.Email,
                PasswordHash = hashedPassword,
                Bios = dto.Bios
            };

            _context.Users.Add(user); // Add the new user to the database context
            await _context.SaveChangesAsync(); // Save the new user to the database

            return "User registered successfully"; // Return a success message


        }


        public async Task<AuthResponseDto?> LoginAsync(LoginDto dto) // Login an existing user
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == dto.Email); // Find the user in the database by email

            if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash)) // Verify the password using BCrypt
                return null;
            var token = GenerateJwtToken(user); // Generate a JWT token for the authenticated user

            return new AuthResponseDto
            {
                Token = token,
                Name = user.Name,
                Email = user.Email,
                Bios = user.Bios
            };
        }

        private string GenerateJwtToken(User user) // Generate a JWT token for the authenticated user
        {
            var jwtSettings = _configuration.GetSection("Jwt");
            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(jwtSettings["Key"]!));

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Email, user.Email)
            };

            var token = new JwtSecurityToken(
                issuer: jwtSettings["Issuer"],
                audience: jwtSettings["Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(
                    double.Parse(jwtSettings["ExpiryMinutes"]!)),
                signingCredentials: new SigningCredentials(
                    key, SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(token); // Return the generated JWT token as a string
        }
    }
}