using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace RestSample.Model
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public int Price { get; set; }

        public int BrandId { get; set; }

        public Brand Brand { get; set; }

    }

    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Product> Products { get;set; }

    }

    public class ProductDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Brand> Brands { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Initial Catalog=ProductDb; User Id=sa; Password=12345678;  TrustServerCertificate=True");
        }
    }
}