// BooksService.cs
using AudioBooksApp.Data;
using AudioBooksApp.Data.Base;
using AudioBooksApp.Data.Services;
using AudioBooksApp.Data.ViewModels;
using AudioBooksApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AudioBooksApp.Services
{
    public class BooksService : EntityBaseRepository<Book>, IBooksService
    {
        private readonly AppDbContext _context;

        public BooksService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            return await _context.Books
                .Include(b => b.Author)
                .Include(b => b.Publisher)
                .Include(b => b.Reader)
                .ToListAsync();
        }

        public async Task AddNewBookAsync(NewBookVM data)
        {
            var newBook = new Book()
            {
                Title = data.Title,
                Price = data.Price,
                Length = data.Length,
                ImageUrl = data.ImageUrl,
                AudioFilePath = data.AudioFilePath,
                PublicationDate = data.PublicationDate,
                Category = data.Category,
                AuthorId = data.AuthorId,
                PublisherId = data.PublisherId,
                ReaderId = data.ReaderId
            };

            await _context.Books.AddAsync(newBook);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateBookAsync(NewBookVM data)
        {
            var dbBook = await _context.Books.FirstOrDefaultAsync(n => n.Id == data.Id);

            if (dbBook != null)
            {
                dbBook.Title = data.Title;
                dbBook.Price = data.Price;
                dbBook.Length = data.Length;
                dbBook.ImageUrl = data.ImageUrl;
                dbBook.AudioFilePath = data.AudioFilePath;
                dbBook.PublicationDate = data.PublicationDate;
                dbBook.Category = data.Category;
                dbBook.AuthorId = data.AuthorId;
                dbBook.PublisherId = data.PublisherId;
                dbBook.ReaderId = data.ReaderId;

                await _context.SaveChangesAsync();
            }
        }

        public async Task<Book> GetBookByIdAsync(int id)
        {
            var bookDetails = await _context.Books
                 .Include(a => a.Author)
                 .Include(p => p.Publisher)
                 .Include(r => r.Reader)
                 .FirstOrDefaultAsync(n => n.Id == id);

            return bookDetails;
        }

        public async Task<NewBookDropdownsVM> GetNewBookDropdownsValues()
        {
            var response = new NewBookDropdownsVM()
            {
                Readers = await _context.Readers.OrderBy(n => n.Name).ToListAsync(),
                Publishers = await _context.Publishers.OrderBy(n => n.Name).ToListAsync(),
                Authors = await _context.Authors.OrderBy(n => n.Name).ToListAsync()
            };
            return response;
        }
    }
}
