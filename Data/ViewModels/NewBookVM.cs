using AudioBooksApp.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace AudioBooksApp.Data.ViewModels
{
    public class NewBookVM
    {
        public int Id { get; set; }

        [Display(Name = "Book Title")]
        [Required(ErrorMessage = "Title is required")]
        public string? Title { get; set; }

        [Display(Name = "Price in $")]
        [Required(ErrorMessage = "Price is required")]
        public decimal Price { get; set; }

        [Display(Name = "Length (in hours and minutes)")]
        public string? Length { get; set; }

        [Display(Name = "Image URL")]
        [Required(ErrorMessage = "Image URL is required")]
        public string? ImageUrl { get; set; }

        [Display(Name = "Audio File Path")]
        public string? AudioFilePath { get; set; }

        [Display(Name = "Publication Date")]
        [Required(ErrorMessage = "Publication Date is required")]
        public DateTime PublicationDate { get; set; }

        [Display(Name = "Category")]
        [Required(ErrorMessage = "Category is required")]
        public Category Category { get; set; }

        // Relationships
        [Display(Name = "Select Author")]
        [Required(ErrorMessage = "Author is required")]
        public int AuthorId { get; set; }

        [Display(Name = "Select Publisher")]
        [Required(ErrorMessage = "Publisher is required")]
        public int PublisherId { get; set; }

        [Display(Name = "Select Reader")]
        [Required(ErrorMessage = "Reader is required")]
        public int ReaderId { get; set; }
    }
}
