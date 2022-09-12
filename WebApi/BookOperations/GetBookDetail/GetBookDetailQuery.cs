using WebApi.Common;
using WebApi.DBOperations;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace WebApi.BookOperations.GetBookDetail
{
    public class GetBookDetailQuery
    {
        private readonly BookStoreDbContext _dbContext;
        public int BookId { get; set; }
        private readonly IMapper _mapper;

        public GetBookDetailQuery(BookStoreDbContext dbContext, IMapper mapper)
        {
            this._dbContext = dbContext;
            _mapper = mapper;
        }

        public GetBookDetailViewModel Handle()
        {
            var book = _dbContext.Books.Where(book => book.Id == BookId).SingleOrDefault();
            if (book is null)
                throw new InvalidOperationException("Böyle Bir Kitap Bulunamadı!");

            GetBookDetailViewModel vm = _mapper.Map<GetBookDetailViewModel>(book);

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
