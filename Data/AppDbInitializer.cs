
using AudioBooksApp.Data;
using AudioBooksApp.Data.Enums;
using AudioBooksApp.Models;

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
                    context.Authors.AddRange(new List<Author>
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
                }
                
            });
                    context.SaveChanges();
                }



                if (!context.Publishers.Any())
                {
                    context.Publishers.AddRange(new List<Publisher>
            {
                new Publisher
                {
                    Name = "Editura 1"
                },
                new Publisher
                {
                    Name = "Editura 2"
                }
                // Adaugă alte edituri aici
            });
                    context.SaveChanges();
                }

                if (!context.Readers.Any())
                {
                    context.Readers.AddRange(new List<Reader>
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
                }
                    });
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
                    ImageUrl="https://audiotribe.ro/wp-content/uploads/2023/05/800-19651-500x500.jpg",
                    AudioFilePath = "https://audiotribe.ro/wp-content/uploads/2023/05/800-19651-500x500.jpg",
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
                    ImageUrl="https://audiotribe.ro/wp-content/uploads/2023/05/800-9751-500x500.jpg",
                    AudioFilePath = "https://audiotribe.ro/wp-content/uploads/2023/05/800-9751-500x500.jpg",
                    PublicationDate = DateTime.Now,
                    Category = Category.Comedy,
                    AuthorId = 2,
                    PublisherId = 2,
                    ReaderId = 2 
                }
               
            });
                    context.SaveChanges();
                }
            }
        }
    }
}