using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace WebApi.DBOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookStoreDbContext(
            serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                // Look for any book.
                if (context.Books.Any())
                {
                    return;   // Data was already seeded
                }

                context.Books.AddRange(
                   new Book()
                   {
                    //    id=1     
                       title = "Lean Startup",
                       genreId = (int)1, // Personal Growth
                       pageCount = 200,
                       publishDate = new DateTime(2001, 06, 12)
                   });
                   

                context.SaveChanges();
            }
        }
    }
}