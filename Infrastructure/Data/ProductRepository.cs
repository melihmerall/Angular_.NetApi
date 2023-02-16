using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Abtracts;
using Core.Entities;

namespace Infrastructure.Data
{
    public class ProductRepository : IProductRepository
    {
        public Task<Product> GetProductByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Product>> GetProductsAsync()
        {
            throw new NotImplementedException();
        }
    }
}