
using WebApi.DBOperations;
using AutoMapper;

namespace WebApi.BookOperations.GetBooks
{
    public class GetBooksQuery
    {

        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;


        public GetBooksQuery(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<BooksViewModel> Handle()
        {
            var bookList = _dbContext.Books.OrderBy(b => b.Id).ToList<Book>();
            List<BooksViewModel> vm = _mapper.Map<List<BooksViewModel>>(bookList);
            // new List<BooksViewModel>();
            // foreach (var book in bookList)
            // {
            //     vm.Add(new BooksViewModel()
            //     {
            //         title = book.title,
            //         genreId = ((GenreEnum)book.genreId).ToString(),
            //         publishDate = book.publishDate.Date.ToString("dd/MM/yyy"),
            //         pageCount = book.pageCount
            //     });
            // 
            return vm;
        }

        public class BooksViewModel
        {
            public string title { get; set; }

            public int pageCount { get; set; }

            public string publishDate { get; set; }

            public string genreId { get; set; }

        }

    }


}