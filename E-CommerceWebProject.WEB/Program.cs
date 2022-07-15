using E_CommerceWebProject.DAL.Context;
using E_CommerceWebProject.DAL.Repositories.Concrete;
using E_CommerceWebProject.DAL.Repositories.Interfaces.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ProjectContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionTWO"));
    options.UseLazyLoadingProxies(true);
});
builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<ProjectContext>();
builder.Services.AddScoped<IBasketRepository, BasketRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IProductColorRepository, ProductColorRepository>();
builder.Services.AddScoped<IProductImageRepository, ProductImageRepository>();
builder.Services.AddScoped<IProductStockSizeRepository, ProductStockSizeRepository>();
builder.Services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();


builder.Services.ConfigureApplicationCookie(a =>
{
    a.LoginPath = new PathString("/User/Login");
    a.ExpireTimeSpan = TimeSpan.FromDays(1);
    a.Cookie = new CookieBuilder { Name = "UserCokie", SecurePolicy = CookieSecurePolicy.Always };
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapAreaControllerRoute(
  name: "areas",
  areaName: "Customer",
  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
);

AppDbInitializer.SeedUsersAndRolesAsync(app).Wait();
AppDbInitializer.Seed(app);
app.Run();


