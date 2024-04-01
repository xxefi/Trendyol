using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trendyol.Models;

namespace Trendyol.Services
{
    public class AddCargoService
    {
        private readonly ApplicationDbContext _context;

        public AddCargoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Products AddProduct(int userId, string name, string description, decimal price, string category, int count)
        {
            Products products = new Products
            {
                UserId = userId,
                Name = name,
                Description = description,
                Price = price,
                Category = category,
                Count = count
            };
            return products;
        }
    }
}
