using BCrypt.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trendyol.Models;

namespace Trendyol.Services
{
    public class AdminService
    {
        private readonly ApplicationDbContext _context;

        public AdminService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Admin AdminRegister(string login, string password)
        {
            Admin admin = new Admin
            {
                Name = login,
                Password = BCrypt.Net.BCrypt.HashPassword(password)
            };
            return admin;
        }

        public bool AdminLogin(string name, string password)
        {
            Admin admin = _context.Admin.FirstOrDefault(a => a.Name == name);
            if (admin != null)
            {
                return BCrypt.Net.BCrypt.Verify(password, admin.Password);
            }
            return false;
            
            
            
        }

    }
}
