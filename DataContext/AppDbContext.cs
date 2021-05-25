using Microsoft.EntityFrameworkCore;
using SanriJP.API.Models;

namespace SanriJP.API.DataContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}
         
        public DbSet<Client> Clients { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeRole> EmployeeRoles { get; set; }
        public DbSet<CarOrder> CarOrders { get; set; }
        public DbSet<CarModel> CarModels { get; set; }
        public DbSet<Auction> Auctions { get; set; }
        public DbSet<CarSale> CarSales { get; set; }
        public DbSet<CarResale> CarResales { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.DBInitializer();
        }
    }
}
