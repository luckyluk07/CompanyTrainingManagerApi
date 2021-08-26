using CompanyTrainingManagerApi.Entities;
using CompanyTrainingManagerApi.Interfaces;
using CompanyTrainingManagerApi.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
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
