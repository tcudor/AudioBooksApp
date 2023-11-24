using System.ComponentModel.DataAnnotations;
using AudioBooksApp.Data.Base;

namespace AudioBooksApp.Models
{
    public class Author : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Biography { get; set; }

        public List<Book>? Books { get; set; }
    }

}
