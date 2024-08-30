using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace BookManager.Models
{
    public class BookViewModel
    {
        public int Id { get; set; }
        [Required]
        public string? Title { get; set; }
        [Required]
        public string? ISBN { get; set; }
        public DateTime PublicationDate { get; set; }
        [Required]
        public int PublisherId { get; set; }
        public string? PublisherName { get; set; }
        public int[]? AuthorIds { get; set; }
        public List<SelectListItem>? Publishers { get; set; }
        public List<SelectListItem> ?Authors { get; set; }
        public Author[]? AuthorsId { get; internal set; }
    }
}
