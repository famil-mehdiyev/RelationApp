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
                .HasOne(p => p.Categories) // Bir Product bir Category ilə əlaqəlidir
                .WithMany(c => c.Products) // Bir Category-nin çoxsaylı Products-u var
                .HasForeignKey(p => p.CategoryId); // Foreign key olaraq CategoryId istifadə olunur

            // Burada başqa əlaqələr, məsələn, soft delete tətbiqi, query filter və s. əlavə edilə bilər
            // modelBuilder.Entity<Product>().HasQueryFilter(x => x.IsActive);
        }

    }
}
