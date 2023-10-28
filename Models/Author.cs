using System.ComponentModel.DataAnnotations;

namespace AudioBooksApp.Models
{
    public class Author
    {
        [Key]
        public int AuthorId { get; set; }
        public string? Name { get; set; }
        public string? Biography { get; set; }

        public List<Book>? Books { get; set; }
    }

}
