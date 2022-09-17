using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.UnitTests.TestSetup
{
    public static class Books
    {
        public static void AddBooks(this BookStoreDbContext context)
        {
            context.Books.AddRange(
                   new Book
                   {
                       title = "Steve Jobs",
                       genreId = 1,
                       pageCount = 452,
                       publishDate = new DateTime(2020, 01, 21)
                   },
                    new Book
                    {
                        title = "Bill Gates",
                        genreId = 2,
                        pageCount = 222,
                        publishDate = new DateTime(2000, 04, 05)
                    },
                    new Book
                    {
                        title = "Sergey Brin",
                        genreId = 2, // PersonalGrowth
                        pageCount = 452,
                        publishDate = new DateTime(1998, 9, 4)
                    }
                );
        }
    }
}