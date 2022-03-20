using Microsoft.EntityFrameworkCore;
using Rookie.Ecom.DataAccessor.Entities;
using System;

namespace Rookie.Ecom.DataAccessor.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<ProductFeedBack> ProductFeedBacks { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Slide> Slides { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
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

            #region Table
            builder.Entity<Category>(entity =>
            {
                entity.ToTable(name: "Category")
                .HasMany(c => c.Children)
                .WithOne(c => c.ParentCategory)
                .HasForeignKey(c => c.ParentId);
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
            builder.Entity<UserRole>(entity =>
            {
                entity.ToTable(name: "UserRole");
            });
            #endregion
            #region Seed Data
            builder.Entity<Role>().HasData(new Role {Id = Guid.Parse("ad4e4ee0-e123-4839-b27e-2a4b79ed826a"), Name = "Admin", CreatedDate = DateTime.Parse("1/1/2022"), Pubished = true, Status = 1, UpdatedDate= DateTime.Parse("1/1/2022") });
            builder.Entity<Role>().HasData(new Role {Id = Guid.Parse("593887de-f117-44b5-a2f0-f2048d056bb9"), Name = "Customer", CreatedDate = DateTime.Parse("1/1/2022"), Pubished = true, Status = 1, UpdatedDate= DateTime.Parse("1/1/2022") });
            builder.Entity<Role>().HasData(new Role {Id = Guid.Parse("1f9f4525-99ba-4280-bbd9-d81694b1ff47"), Name = "Employee", CreatedDate = DateTime.Parse("1/1/2022"), Pubished = true, Status = 1, UpdatedDate= DateTime.Parse("1/1/2022") });
            builder.Entity<User>().HasData(new User {Id = Guid.Parse("d0ac3342-b8b2-474b-bc39-404812481411"), Name = "Admin", Email="admin@gmail.com", UserName = "Admin", Password="123456", CreatedDate = DateTime.Parse("1/1/2022"), Pubished = true, Status = 1, UpdatedDate = DateTime.Parse("1/1/2022") });
            builder.Entity<UserRole>().HasData(new UserRole { Id = Guid.Parse("d0ac3342-b8b2-474b-bc39-404812481411"), RoleId = Guid.Parse("ad4e4ee0-e123-4839-b27e-2a4b79ed826a"), UserId = Guid.Parse("d0ac3342-b8b2-474b-bc39-404812481411"), CreatedDate = DateTime.Parse("1/1/2022"), Pubished = true, Status = true, UpdatedDate = DateTime.Parse("1/1/2022") });
            #endregion
        }
    }
}
