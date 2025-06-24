
using BokkStoreProject.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BokkStoreProject.DbInfo
{
    public class AppDbContext:IdentityDbContext<ApplicationUser>
    {

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product>Products { get; set; }

     
        public AppDbContext(DbContextOptions<AppDbContext> option):base(option)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)

        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CategoryConfig).Assembly);
        }
    }
}
