using Microsoft.EntityFrameworkCore;
using testCoreApp.Models;
using TestCoreApp.Models;

namespace testCoreApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
            
        }
        public DbSet<Item> Items { get; set; }
        public DbSet<Employee> Employees { get; set; }



    }
}
