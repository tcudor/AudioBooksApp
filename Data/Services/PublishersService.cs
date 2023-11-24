using AudioBooksApp.Data.Base;
using AudioBooksApp.Models;

namespace AudioBooksApp.Data.Services
{
    public class PublishersService : EntityBaseRepository<Publisher>, IPublishersService
    {
        public PublishersService(AppDbContext context) : base(context) { }
    }
}
