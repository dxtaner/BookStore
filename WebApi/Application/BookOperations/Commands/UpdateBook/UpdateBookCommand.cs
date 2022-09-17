using WebApi.DBOperations;

namespace WebApi.Application.BookOperations.Commands.UpdateBook
{
    public class UpdateBookCommand
    {
        private readonly BookStoreDbContext _context;
        public int BookId { get; set; }
        public UpdateBookModel Model
        {
            get; set;
        }

        public UpdateBookCommand(BookStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {

            var book = _context.Books.SingleOrDefault(b => b.Id == BookId);

            if (book is null)
                throw new InvalidOperationException("Güncellenecek Kitap Bulunamadı!");

            book.genreId = Model.genreId != default ? Model.genreId : book.genreId;
            book.title = Model.title != default ? Model.title : book.title;
        }
    }

    public class UpdateBookModel
    {
        public string title { get; set; }
        public int genreId { get; set; }

    }

}