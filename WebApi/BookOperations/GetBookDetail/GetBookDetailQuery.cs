using WebApi.Common;
using WebApi.DBOperations;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.BookOperations.GetBookDetail
{
    public class GetBookDetailQuery
    {
        private readonly BookStoreDbContext _dbContext;
        public int BookId { get; set; }

        public GetBookDetailQuery(BookStoreDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public GetBookDetailViewModel Handle()
        {
            var book = _dbContext.Books.Where(book => book.Id == BookId).SingleOrDefault();
            if (book is null)
                throw new InvalidOperationException("Böyle Bir Kitap Bulunamadı!");

            GetBookDetailViewModel vm = new GetBookDetailViewModel();
            vm.title = book.title;
            vm.genreId = ((GenreEnum)book.genreId).ToString();
            vm.pageCount = book.pageCount;
            vm.publishDate = book.publishDate.Date.ToString("dd/MM/yyyy");

            return vm;
        }
    }
    public class GetBookDetailViewModel
    {
        public string title { get; set; }
        public string genreId { get; set; }
        public int pageCount { get; set; }
        public string publishDate { get; set; }

    }    
}
