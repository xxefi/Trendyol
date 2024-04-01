using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trendyol.Models;

namespace Trendyol.Services.Classes
{
    public class AddOrderService
    {
        private readonly ApplicationDbContext _context;

        public AddOrderService(ApplicationDbContext context)
        {
            _context = context;
        }

        public ProductsForOrder AddProductOrder(string name, string description, decimal price, int count, string category, byte[] _image)
        {
            ProductsForOrder productsForOrder = new ProductsForOrder()
            {
                Name = name,
                Description = description,
                Price = price,
                Count = count,
                Category = category,
                Image = _image
            };
            return productsForOrder;
        }
    }
}
