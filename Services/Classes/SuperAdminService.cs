using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trendyol.Models;

namespace Trendyol.Services
{
    public class SuperAdminService
    {
        private readonly ApplicationDbContext _context;

        public SuperAdminService(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool SuperAdminLogin(string name, string password)
        {
            SuperAdmin superAdmin = _context.SuperAdmin.FirstOrDefault(a => a.Name == name);
            if (superAdmin != null)
            {
                return password == superAdmin.Password;
            }
            return false;
        }
    }
}
