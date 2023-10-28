using System.ComponentModel.DataAnnotations;

namespace AudioBooksApp.Models
{
    public class Reader
    {
        [Key]
        public int ReaderId { get; set; }
        public string? Name { get; set; }
        public string? Biography { get; set; }

        public List<Book>? Books { get; set; }
    }
}
