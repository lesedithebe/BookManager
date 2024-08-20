using System.ComponentModel.DataAnnotations;

namespace BookManager.Models
{
    public class Author
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Biography { get; set; }
        public ICollection<BookAuthor> BookAuthors { get; set; }
    }
}
