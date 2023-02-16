using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Abtracts;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class  ProductRepository : IProductRepository
    {
        private readonly TradeContext _context;
        public ProductRepository(TradeContext context){
            _context = context;
        }
        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }
    }
}