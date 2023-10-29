using AudioBooksApp.Data.Enums;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using System.ComponentModel.DataAnnotations;

namespace AudioBooksApp.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        public string? Title { get; set; }
        public decimal Price { get; set; }
        public string? Length { get; set; } //exrpimare in ora si minute
        public string? ImageUrl { get; set; }
        public string? AudioFilePath { get; set; }
        public DateTime PublicationDate { get; set; }
        public Category Category { get; set; }

        public int AuthorId { get; set; }
        public Author? Author { get; set; } 
        public int PublisherId { get; set; }
        public Publisher? Publisher { get; set; }
        public int ReaderId { get; set; }
        public Reader? Reader { get; set; }
    }

}
