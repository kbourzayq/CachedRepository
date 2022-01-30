using CachedRepositorySample.Models;
using Microsoft.EntityFrameworkCore;

namespace CachedRepositorySample.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Customer> Cutomers { get; set; }
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            List<Customer> customers = initCustomers();
            modelBuilder.Entity<Customer>().HasData(customers.ToArray());
        }

        private List<Customer> initCustomers()
        {
            List<Customer> customers = new();
            for(int i = 0; i < 10000; i++)
            {
                customers.Add(new Customer {Id = i+1, Name = $"Customer {i}", LastName = $"Customer Lastname {i}", Address = $"Address {i}" });
            }
            return customers;
        }
    }
}
