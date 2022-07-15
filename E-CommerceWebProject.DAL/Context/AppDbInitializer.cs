using E_CommerceWebProject.Models.Entities.Concrete;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceWebProject.DAL.Context
{
    public class AppDbInitializer
    {

        public static string guid = Guid.NewGuid().ToString();
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ProjectContext>();
                context.Database.EnsureCreated();
                if (!context.Users.Any())
                {
                    context.Users.AddRange(new List<User>
                    {
                        new User()
                        {
                            FirstName = "Yusup",
                        LastName = "Charyyev",
                        UserName = "yusupcharyyev",
                        Password = "Yusup1996.",
                        IdentityId = guid,
                        BoutiqueName = "Konuşarak Öğren",
                        Adres = "Türkiye Antalya Konyaaltı"
                        }
                    });
                    context.SaveChanges();
                }
                if (!context.Categories.Any())
                {
                    context.Categories.AddRange(new List<Category>
                    {
                        new Category()
                        {
                            Name="Teknoloji",
                            Description="Teknoloji ile ilgili ürünler"
                        }
                    });
                    context.SaveChanges();
                }
                if (!context.Products.Any())
                {
                    context.Products.AddRange(new List<Product>
                    {
                        new Product()
                        {
                            Name="Samsung Galaxy A32 128GB Lavanta Cep Telefonu",
                            Code="A326128",
                            Price=5056.79,
                            DiscountPrice=0,
                            DiscountPercent=0,
                            UserID=context.Users.First(a=>a.UserName=="yusupcharyyev").ID,
                            User=context.Users.First(a=>a.UserName=="yusupcharyyev")
                        }
                    });
                    context.SaveChanges();
                }
                if (!context.ProductColors.Any())
                {
                    context.ProductColors.AddRange(new List<ProductColor>
                    {
                        new ProductColor()
                        {
                            Color="#fcf9f9",
                            ProductID=context.Products.First().ID,
                            Product=context.Products.First()
                        }
                    });
                    context.SaveChanges();
                }
                if (!context.ProductCategories.Any())
                {
                    context.ProductCategories.AddRange(new List<ProductCategory>
                    {
                        new ProductCategory()
                        {
                            ProductID=context.Products.First().ID,
                            Product=context.Products.First(),
                            CategoryID=context.Categories.First().ID,
                            Category=context.Categories.First()
                        }
                    });
                    context.SaveChanges();
                }
                if (!context.ProductImages.Any())
                {
                    context.ProductImages.AddRange(new List<ProductImage>
                    {
                        new ProductImage()
                        {
                            Image=$"/images/samsung.jpg",
                            ProductColorID=context.ProductColors.First().ID,
                            ProductColor=context.ProductColors.First()
                        }
                    });
                    context.SaveChanges();
                }
                if (!context.ProductStockSizes.Any())
                {
                    context.ProductStockSizes.AddRange(new List<ProductStockSize>
                    {
                        new ProductStockSize()
                        {
                            Stock=20,
                            BodySize="Ebat",
                            ProductColorID=context.ProductColors.First().ID,
                            ProductColor=context.ProductColors.First()
                        }
                    });
                    context.SaveChanges();
                }
            }
        }

        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync("Customer")) ;
                await roleManager.CreateAsync(new IdentityRole("Customer"));
                if (!await roleManager.RoleExistsAsync("Admin"))
                    await roleManager.CreateAsync(new IdentityRole("Admin"));
                if (!await roleManager.RoleExistsAsync("SysAdmin"))
                    await roleManager.CreateAsync(new IdentityRole("SysAdmin"));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
                string adminUserEmail = "yusupcharyyevv@gmail.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    IdentityUser newAdminUser = new IdentityUser()
                    {
                        Id = guid,
                        Email = adminUserEmail,
                        UserName = "yusupcharyyev"
                    };
                    await userManager.CreateAsync(newAdminUser, "Yusup1996.");
                    await userManager.AddToRoleAsync(newAdminUser, "Customer");
                }

            }
        }
    }
}
