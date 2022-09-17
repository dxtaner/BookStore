using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{
    public class Author
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int authorId { get; set; }
        public string authorName { get; set; }
        public string authorSurName { get; set; }
        public DateTime authorBirthdayDate { get; set; }
        public List<Book> Books { get; set; }

    }
}