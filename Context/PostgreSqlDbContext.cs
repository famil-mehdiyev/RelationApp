using Microsoft.EntityFrameworkCore;
using OneToManyRelation.Model;
using System.Xml;

namespace OneToManyRelation.Context
{
    public class PostgreSqlDbContext :DbContext
    {
        public PostgreSqlDbContext(DbContextOptions<PostgreSqlDbContext> options) :base (options) { } 
        

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Product ilə Category arasında Many-to-One əlaqəsinin qurulması
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Categories)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId);


            // modelBuilder.Entity<Product>().HasQueryFilter(x => x.IsActive);
        }
    }
}
