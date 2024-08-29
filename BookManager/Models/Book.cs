
using System.ComponentModel.DataAnnotations;


namespace BookManager.Models
{
    public class Book
    {
     
        public int? Id { get; internal set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string ISPN { get; set; }

        public DateTime PublicationDate { get; set; }

        public int PublisherId { get; set;}

        public Publisher Publisher { get; set;}

        public ICollection<BookAuthor> BookAuthors { get; set;}
        public string ISBN { get; internal set; }
    }
}
