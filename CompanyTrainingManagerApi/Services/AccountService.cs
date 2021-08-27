using CompanyTrainingManagerApi.Entities;
using CompanyTrainingManagerApi.Exceptions;
using CompanyTrainingManagerApi.Interfaces;
using CompanyTrainingManagerApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CompanyTrainingManagerApi.Services
{
    public class AccountService : IAccountService
    {
        private readonly AppDbContext _context;
        private readonly IPasswordHasher<User> _passwordHasher;

        public AccountService(AppDbContext context, IPasswordHasher<User> passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }

        public string GenerateJwt(LoginAccountDto dto)
        {
            var user = _context.Users
                            .Include(u => u.Role)
                            .FirstOrDefault(u => u.Email == dto.Email);

            if(user is null)
            {
                throw new BadRequestException("Invalid email or password");
            }

            var passwordResult = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, dto.Password);

            if(passwordResult == PasswordVerificationResult.Failed)
            {
                throw new BadRequestException("Invalid email or password");
            }

            var key = Encoding.ASCII.GetBytes(Startup.SECRET);
            var cred = new SigningCredentials(new SymmetricSecurityKey(key),SecurityAlgorithms.HmacSha256Signature);

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier ,user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.Role.Name),
                new Claim(ClaimTypes.Name, $"{user.Name} {user.Surname}")
            };

            var token = new JwtSecurityToken(issuer:"Bearer",
                audience:"Bearer",
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(15),
                signingCredentials: cred);

            var tokenHandler = new JwtSecurityTokenHandler();

            return tokenHandler.WriteToken(token);
        }

        public void RegisterUser(RegisterAccountDto dto)
        {
            var newAccount = new User()
            {
                Name = dto.Name,
                Surname = dto.Surname,
                Email = dto.Email,
                Comment = dto.Comment,
                RoleId = dto.RoleId
            };

            newAccount.PasswordHash = _passwordHasher.HashPassword(newAccount, dto.Password);

            _context.Users.Add(newAccount);
            _context.SaveChanges();
        }
    }
}
