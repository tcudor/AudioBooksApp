using System.ComponentModel.DataAnnotations;

namespace AudioBooksApp.Models
{
    public class Publisher
    {
        [Key]
        public int PublisherId { get; set; }
        public string? Name { get; set; }

        public List<Book>? Books { get; set; }        
    }

}
