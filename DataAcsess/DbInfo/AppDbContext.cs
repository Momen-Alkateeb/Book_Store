

using BokkStoreProject.Models;
using Microsoft.EntityFrameworkCore;

namespace BokkStoreProject.DbInfo
{
    public class AppDbContext:DbContext
    {

        public DbSet<Category> Categories { get; set; }
     
        public AppDbContext(DbContextOptions<AppDbContext> option):base(option)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CategoryConfig).Assembly);
        }
    }
}
