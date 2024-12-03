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
            modelBuilder.Entity<Product>().HasOne(x => x.Categories).WithMany(x => x.Products).HasForeignKey(x => x.CategoryId);
            //modelBuilder.Entity<Product>().HasQueryFilter(x=>x.);

        }
    }
}
