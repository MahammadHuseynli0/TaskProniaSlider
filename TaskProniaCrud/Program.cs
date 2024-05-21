using Microsoft.EntityFrameworkCore;
using TaskProniaCrud.Business.Services.Abstracts;
using TaskProniaCrud.Business.Services.Concretes;
using TaskProniaCrud.Core.RepositoryAbstarcts;
using TaskProniaCrud.Data.DAL;
using TaskProniaCrud.Data.RepositoryConcretes;

namespace TaskProniaCrud
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });



            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<IFeatureService, FeatureService>();
            builder.Services.AddScoped<ITagService, TagService>();

            builder.Services.AddScoped<ICategoryRepository, CategoryRepositroy>();
            builder.Services.AddScoped<IFeatureRepositroy, FeatureRepository>();
            builder.Services.AddScoped<IProductRepositroy, ProductRepository>();
            builder.Services.AddScoped<ITagRepository, TagRepositroy>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
          );

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}