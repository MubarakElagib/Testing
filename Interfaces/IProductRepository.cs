using System.Collections.Generic;
using System.Threading.Tasks;
using Demo.Backend.Models;

namespace Demo.Backend.Interfaces
{
    public interface IProductRepository
    {
        void Add(Product product);
        void Delete(Product product);
        Task<List<Product>> GetProducts();
        Task<Product> GetProduct(int? id);
        Task<bool> SaveAll();
    }
}