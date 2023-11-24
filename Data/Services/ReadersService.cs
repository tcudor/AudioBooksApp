using AudioBooksApp.Data.Base;
using AudioBooksApp.Models;

namespace AudioBooksApp.Data.Services
{
    public class ReadersService:EntityBaseRepository<Reader>, IReadersService
    {
        public ReadersService(AppDbContext context) : base(context) { }
    }
}
