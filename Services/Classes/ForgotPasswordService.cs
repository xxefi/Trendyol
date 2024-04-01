using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trendyol.Models;

namespace Trendyol.Services
{
    public class ForgotPasswordService
    {
        private readonly ApplicationDbContext _context;

        public ForgotPasswordService(ApplicationDbContext context)
        {
            _context = context;
        }

        public User ForgotPassword(string FIN, string phone, string password)
        {
            User? user = _context.Users.SingleOrDefault(u => u.FIN == FIN && u.Phone == phone);
            user.Password = BCrypt.Net.BCrypt.HashPassword(password);
            return user;
        }
    }
}
