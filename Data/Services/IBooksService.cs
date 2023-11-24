using AudioBooksApp.Data.Base;
using AudioBooksApp.Data.ViewModels;
using AudioBooksApp.Models;

namespace AudioBooksApp.Data.Services
{
    public interface IBooksService:IEntityBaseRepository<Book>
    {
        Task<IEnumerable<Book>> GetAllBooks();
        Task<Book> GetBookByIdAsync(int id);
        Task<NewBookDropdownsVM> GetNewBookDropdownsValues();
        Task AddNewBookAsync(NewBookVM data);
        Task UpdateBookAsync(NewBookVM data);
    }
}