using AudioBooksApp.Data.Base;
using AudioBooksApp.Models;

namespace AudioBooksApp.Data.Services
{
    public class AuthorsService:EntityBaseRepository<Author>, IAuthorsService
	{
        public AuthorsService(AppDbContext context) : base(context) { }
    }
}
