using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.BookOperations.Commands.CreateBook
{
    public class CreateBookCommand
    {
        public CreateBookModel Model { get; set; }
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public CreateBookCommand(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
    
        public void Handle()
        {

            var book = _dbContext.Books.SingleOrDefault(b => b.title == Model.title);
            
            if (book is not null)
                throw new InvalidOperationException("Kitap Zaten Mevcut!");
            
            book= _mapper.Map<Book>(Model); 
            
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