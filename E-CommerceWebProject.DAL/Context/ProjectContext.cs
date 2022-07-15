using E_CommerceWebProject.Models.Entities.Concrete;
using E_CommerceWebProject.Models.EntityTypeConfigurations.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceWebProject.DAL.Context
{
    public class ProjectContext : IdentityDbContext
    {
        public ProjectContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductColor> ProductColors { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<ProductStockSize> ProductStockSizes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new BasketMap());
            builder.ApplyConfiguration(new CategoryMap());
            builder.ApplyConfiguration(new CommentMap());
            builder.ApplyConfiguration(new OrderMap());
            builder.ApplyConfiguration(new OrderDetailsMap());
            builder.ApplyConfiguration(new ProductMap());
            builder.ApplyConfiguration(new ProductCategoryMap());
            builder.ApplyConfiguration(new ProductColorMap());
            builder.ApplyConfiguration(new ProductImageMap());
            builder.ApplyConfiguration(new ProductStockSizeMap());
            builder.ApplyConfiguration(new UserMap());
            builder.ApplyConfiguration(new IdentityRoleMap());
            base.OnModelCreating(builder);
        }
    }
}
