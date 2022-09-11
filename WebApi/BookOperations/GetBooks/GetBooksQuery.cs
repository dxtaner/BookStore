using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.DBOperations;
using Microsoft.EntityFrameworkCore;
using WebApi;
using WebApi.Common;

namespace WebApi.BookOperations.GetBooks
{
    public class GetBooksQuery
    {

        private readonly BookStoreDbContext _dbContext;

        public GetBooksQuery(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;

        }

        public List<BooksViewModel> Handle()
        {
            var bookList = _dbContext.Books.OrderBy(b=> b.Id).ToList<Book>();
            List<BooksViewModel> vm = new List<BooksViewModel>();
            new List<BooksViewModel>();
            foreach (var book in bookList)
            {
                vm.Add(new BooksViewModel()
                {
                    title = book.title,
                    genreId = ((GenreEnum) book.genreId).ToString(),
                    publishDate = book.publishDate.Date.ToString("dd/MM/yyy"),
                    pageCount = book.pageCount
                });
            } 
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