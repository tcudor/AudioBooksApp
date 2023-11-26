
using AudioBooksApp.Data;
using AudioBooksApp.Data.Enums;
using AudioBooksApp.Data.Static;
using AudioBooksApp.Models;
using Microsoft.AspNetCore.Identity;
namespace PetHotel.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                if (!context.Authors.Any())
                {
                    var authorsToAdd = new List<Author>
    {
        new Author
        {
            Name = "Autor 1",
            Biography = "Biografia autorului 1"
        },
        new Author
        {
            Name = "Autor 2",
            Biography = "Biografia autorului 2"
        },
        new Author
        {
            Name = "Autor 3",
            Biography = "Biografia autorului 3"
        },
        new Author
        {
            Name = "Autor 4",
            Biography = "Biografia autorului 4"
        },
        new Author
        {
            Name = "Autor 5",
            Biography = "Biografia autorului 5"
        }
    };

                    context.Authors.AddRange(authorsToAdd);
                    context.SaveChanges();
                }

                if (!context.Publishers.Any())
                {
                    var publishersToAdd = new List<Publisher>
    {
        new Publisher
        {
            Name = "Editura 1"
        },
        new Publisher
        {
            Name = "Editura 2"
        },
        new Publisher
        {
            Name = "Editura 3"
        },
        new Publisher
        {
            Name = "Editura 4"
        },
        new Publisher
        {
            Name = "Editura 5"
        }
    };

                    context.Publishers.AddRange(publishersToAdd);
                    context.SaveChanges();
                }


                if (!context.Readers.Any())
                {
                    var readersToAdd = new List<Reader>
    {
        new Reader
        {
            Name = "Reader 1",
            Biography = "Biografia Reader 1"
        },
        new Reader
        {
            Name = "Reader 2",
            Biography = "Biografia Reader 2"
        },
        new Reader
        {
            Name = "Reader 3",
            Biography = "Biografia Reader 3"
        },
        new Reader
        {
            Name = "Reader 4",
            Biography = "Biografia Reader 4"
        },
        new Reader
        {
            Name = "Reader 5",
            Biography = "Biografia Reader 5"
        }
    };

                    context.Readers.AddRange(readersToAdd);
                    context.SaveChanges();
                }


                if (!context.Books.Any())
                {
                    context.Books.AddRange(new List<Book>
            {
new Book
        {
            Title = "Carte 1",
            Price = 19.99m,
            Length = "5h 30m",
            ImageUrl = "https://audiotribe.ro/wp-content/uploads/2023/05/800-19651.jpg",
            AudioFilePath = "https://filelist.io/download.php?id=626246",
            PublicationDate = DateTime.Now,
            Category = Category.Horror,
            AuthorId = 1,
            PublisherId = 1,
            ReaderId = 1
        },
        new Book
        {
            Title = "Carte 2",
            Price = 24.99m,
            Length = "6h 15m",
            ImageUrl = "https://audiotribe.ro/wp-content/uploads/2023/05/800-14214.jpg",
            AudioFilePath = "https://filelist.io/download.php?id=626246",
            PublicationDate = DateTime.Now,
            Category = Category.Comedy,
            AuthorId = 2,
            PublisherId = 2,
            ReaderId = 2
        },
        new Book
        {
            Title = "Carte 3",
            Price = 29.99m,
            Length = "7h 45m",
            ImageUrl = "https://audiotribe.ro/wp-content/uploads/2023/05/800-16638.jpg",
            AudioFilePath = "https://filelist.io/download.php?id=626246",
            PublicationDate = DateTime.Now,
            Category = Category.Drama,
            AuthorId = 3,
            PublisherId = 3,
            ReaderId = 3
        },
        new Book
        {
            Title = "Carte 4",
            Price = 14.99m,
            Length = "4h 20m",
            ImageUrl = "https://audiotribe.ro/wp-content/uploads/2023/05/800-17844.jpg",
            AudioFilePath = "https://filelist.io/download.php?id=626246",
            PublicationDate = DateTime.Now,
            Category = Category.Romance,
            AuthorId = 4,
            PublisherId = 4,
            ReaderId = 4
        },
        new Book
        {
            Title = "Carte 5",
            Price = 34.99m,
            Length = "8h 10m",
            ImageUrl = "https://audiotribe.ro/wp-content/uploads/2023/05/800-17853.jpg",
            AudioFilePath = "https://filelist.io/download.php?id=626246",
            PublicationDate = DateTime.Now,
            Category = Category.SciFi,
            AuthorId = 5,
            PublisherId = 5,
            ReaderId = 5
        },
        new Book
        {
            Title = "Carte 6",
            Price = 21.99m,
            Length = "6h 50m",
            ImageUrl = "https://audiotribe.ro/wp-content/uploads/2023/05/800-14743.jpg",
            AudioFilePath = "https://filelist.io/download.php?id=626246",
            PublicationDate = DateTime.Now,
            Category = Category.Thriller,
            AuthorId = 1,
            PublisherId = 2,
            ReaderId = 3
        },
        new Book
        {
            Title = "Carte 7",
            Price = 18.99m,
            Length = "5h 55m",
            ImageUrl = "https://audiotribe.ro/wp-content/uploads/2023/05/800-18735.jpg",
            AudioFilePath = "https://filelist.io/download.php?id=626246",
            PublicationDate = DateTime.Now,
            Category = Category.Thriller,
            AuthorId = 3,
            PublisherId = 4,
            ReaderId = 2
        },
        new Book
        {
            Title = "Carte 8",
            Price = 26.99m,
            Length = "7h 20m",
            ImageUrl = "https://audiotribe.ro/wp-content/uploads/2023/05/800-18670.jpg",
            AudioFilePath = "https://filelist.io/download.php?id=626246",
            PublicationDate = DateTime.Now,
            Category = Category.Comedy,
            AuthorId = 4,
            PublisherId = 1,
            ReaderId = 5
        },
        new Book
        {
            Title = "Carte 9",
            Price = 31.99m,
            Length = "8h 45m",
            ImageUrl = "https://audiotribe.ro/wp-content/uploads/2023/05/800-18661.jpg",
            AudioFilePath = "https://filelist.io/download.php?id=626246",
            PublicationDate = DateTime.Now,
            Category = Category.Comedy,
            AuthorId = 2,
            PublisherId = 3,
            ReaderId = 4
        },
        new Book
        {
            Title = "Carte 10",
            Price = 22.99m,
            Length = "6h 30m",
            ImageUrl = "https://audiotribe.ro/wp-content/uploads/2023/05/800-19224.jpg",
            AudioFilePath = "https://filelist.io/download.php?id=626246",
            PublicationDate = DateTime.Now,
            Category = Category.Romance,
            AuthorId = 5,
            PublisherId = 5,
            ReaderId = 1
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

                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                string adminUserEmail = "admin@gmail.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        FullName = "Admin User",
                        UserName = "admin",
                        Email = adminUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAdminUser, "Test12%");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }


                string appUserEmail = "user@gmail.com";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new ApplicationUser()
                    {
                        FullName = "Application User",
                        UserName = "user",
                        Email = appUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAppUser, "Test12%");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }
    }
}