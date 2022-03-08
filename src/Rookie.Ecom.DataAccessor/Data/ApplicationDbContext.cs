using Microsoft.EntityFrameworkCore;
using Rookie.Ecom.DataAccessor.Entities;

namespace Rookie.Ecom.DataAccessor.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<ProductFeedBack> ProductFeedBacks { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Slide> Slides { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            //code first
            //db first
            //model first
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Category>(entity =>
            {
                entity.ToTable(name: "Category");
            });

            builder.Entity<Product>(entity =>
            {
                entity.ToTable(name: "Product");
            });

            builder.Entity<Role>(entity =>
            {
                entity.ToTable(name: "Role");
            });

            builder.Entity<User>(entity =>
            {
                entity.ToTable(name: "User");
            });

            builder.Entity<Cart>(entity =>
            {
                entity.ToTable(name: "Cart");
            });

            builder.Entity<City>(entity =>
            {
                entity.ToTable(name: "City");
            }); 
            builder.Entity<Address>(entity =>
            {
                entity.ToTable(name: "Address");
            });
            builder.Entity<ProductFeedBack>(entity =>
            {
                entity.ToTable(name: "ProductFeedBack");
            });
            builder.Entity<Order>(entity =>
            {
                entity.ToTable(name: "Order");
            });
            builder.Entity<OrderItem>(entity =>
            {
                entity.ToTable(name: "OrderItem");
            }); 
            builder.Entity<Slide>(entity =>
            {
                entity.ToTable(name: "Slide");
            });
            builder.Entity<Brand>(entity =>
            {
                entity.ToTable(name: "Brand");
            });
        }
    }
}
