using Demo.Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo.Backend.Data
{
    public class DataContextApp : DbContext
    {
        public DataContextApp(DbContextOptions<DataContextApp> options) : base(options) { }
        public DbSet<Product> Products { get; set; }

    }
}