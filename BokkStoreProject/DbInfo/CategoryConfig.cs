using BokkStoreProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BokkStoreProject.DbInfo
{
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).IsRequired();
            builder.HasData(AllData());
        }
        public List<Category> AllData()
        {
            return new List<Category>
            {
                new Category { Id = 1,Name="Action" , DsiplayOrder=1 },
                new Category {Id =2 ,Name = "Scifi" , DsiplayOrder = 2},
                new Category {Id=3 , Name="History" , DsiplayOrder=3}
            };
        }
    }
}
