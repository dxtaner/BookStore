using WebApi.DBOperations;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace WebApi.Application.BookOperations.Queries.GetBooks
{
    public class GetBooksQuery
    {

        private readonly IBookStoreDbContext _dbContext;
        private readonly IMapper _mapper;


        public GetBooksQuery(IBookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<BooksViewModel> Handle()
        {
            var bookList = _dbContext.Books.Include(x=>x.genre).OrderBy(b => b.Id).ToList<Book>();
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