using AudioBooksApp.Data;
using AudioBooksApp.Data.Cart;
using AudioBooksApp.Data.Services;
using AudioBooksApp.Services;
using Microsoft.EntityFrameworkCore;
using PetHotel.Data;

namespace AudioBooksApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString")));

            // Add services to the container.
            builder.Services.AddScoped<IAuthorsService, AuthorsService>();
            builder.Services.AddScoped<IBooksService,BooksService>();
            builder.Services.AddScoped<IPublishersService, PublishersService>();
            builder.Services.AddScoped<IReadersService, ReadersService>();
            builder.Services.AddScoped<IOrdersService,OrdersService>();
            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            builder.Services.AddScoped(sc => ShoppingCart.GetShoppingCart(sc));

            builder.Services.AddSession();

            builder.Services.AddControllersWithViews();


            var app = builder.Build();



            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            AppDbInitializer.Seed(app);
            app.Run();
        }
    }
}