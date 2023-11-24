using AudioBooksApp.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace AudioBooksApp.Models
{
    public class Reader: IEntityBase
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Biography { get; set; }

        public List<Book>? Books { get; set; }
    }
}
