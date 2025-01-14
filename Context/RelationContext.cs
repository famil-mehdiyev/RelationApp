using Microsoft.EntityFrameworkCore;
using OneToManyRelation.Model;

namespace OneToManyRelation.Context
{
    public class RelationContext : DbContext
    {
        public RelationContext(DbContextOptions<RelationContext> options) : base(options) { }

      

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
