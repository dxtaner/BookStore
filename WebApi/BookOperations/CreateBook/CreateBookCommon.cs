using WebApi;
using WebApi.DBOperations;

namespace WebApi.BookOperations.Commands.CreateBook
{
    public class CreateBookCommand
    {
        public CreateBookModel Model { get; set; }
        private readonly BookStoreDbContext _dbContext;
        public CreateBookCommand(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            
            var book = _dbContext.Books.SingleOrDefault( b => b.title == Model.title);

            if (book is not null)
                throw new InvalidOperationException("Kitap Zaten Mevcut!");  

            new Book();            
            book.title = Model.title;
            book.genreId = Model.genreId;
            book.pageCount = Model.pageCount;
            book.publishDate = Model.publishDate; 
            
            _dbContext.Books.Add(book);
            _dbContext.SaveChanges();    
        }

    }

    public class CreateBookModel
    {
        public string title { get; set; }
        public int genreId { get; set; }
        public int pageCount { get; set; }
        public DateTime publishDate { get; set; }
    }
}