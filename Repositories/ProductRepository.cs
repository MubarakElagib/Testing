using System.Collections.Generic;
using System.Threading.Tasks;
using Demo.Backend.Data;
using Demo.Backend.Interfaces;
using Demo.Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo.Backend.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContextApp _context;
        public ProductRepository(DataContextApp context)
        {
            _context = context;
        }
        public void Add(Product product)
        {
            if (_context != null)
                _context.Add(product);
        }

        public void Delete(Product product)
        {
            if (_context != null)
                _context.Remove(product);
        }

        public async Task<Product> GetProduct(int? id)
        {
            if (_context != null)
            {
                var product = await _context.Products.FirstOrDefaultAsync(prodcutId => prodcutId.Id == id);
                return product;
            }

            return null;
        }

        public async Task<List<Product>> GetProducts()
        {
            if (_context != null)
            {
                var products = await _context.Products.ToListAsync();
                return products;
            }
            return null;
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}