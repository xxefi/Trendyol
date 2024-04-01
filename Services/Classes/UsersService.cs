using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Trendyol.Models;

namespace Trendyol.Services
{
    public class UsersService
    {
        private readonly ApplicationDbContext _context;

        public UsersService(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool UserLogin(string email, string password)
        {
            User user = _context.Users.FirstOrDefault(u => u.Email == email);
            if (user != null)
            {
                return BCrypt.Net.BCrypt.Verify(password, user.Password);
            }
            return false;
        }

        public User? GetUser(string email)
        {
            return _context.Users.FirstOrDefault(user => user.Email == email);
        }

        public User UserRegister(string name, string surname, string login, string email, string password, string FIN, string phone)
        {
            User user = new User
            {
                Name = name,
                Surname = surname,
                Login = login,
                Email = email,
                Password = BCrypt.Net.BCrypt.HashPassword(password),
                FIN = FIN,
                Phone = phone
            };
            return user;
        }
    }
}