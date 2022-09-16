using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{

    public class Book
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }
        public string title { get; set; }
        public int genreId { get; set; }
        public int authorId { get; set; }
        public Genre genre { get; set; }
        public Author author { get; set; }
        public int pageCount { get; set; }
        public DateTime publishDate { get; set; }

    }
}