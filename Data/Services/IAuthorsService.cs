using AudioBooksApp.Data.Base;
using AudioBooksApp.Models;

namespace AudioBooksApp.Data.Services
{
    public interface IAuthorsService : IEntityBaseRepository<Author>
    {
    }
}