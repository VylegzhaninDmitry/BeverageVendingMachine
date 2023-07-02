using Microsoft.EntityFrameworkCore;

namespace BeverageVendingMachine.Models.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public DbSet<Beverage> Beverages { get; set; }
    }
}
