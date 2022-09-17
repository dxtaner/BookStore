using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

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

                var authors = new List<Author>{
                new Author
                {
                    authorId = 1,
                    authorName = "Andrew",
                    authorSurName = "Tate",
                    authorBirthdayDate = new DateTime(1995, 02, 12),
                    Books = new List<Book>()
                    {
                    new Book { title = "Introduction to Machine Learning"},
                    new Book { title = "Advanced Topics in Machine Learning"},
                    new Book { title = "Introduction to Computing"}
                    }
                },
                new Author
                {
                    authorId = 2,
                    authorName = "William",
                    authorSurName = "Hitch",
                    authorBirthdayDate = new DateTime(1965, 05, 07),
                    Books = new List<Book>()
                    {
                    new Book { title = "Introduction to Machine Learning"},
                    new Book { title = "Advanced Topics in Machine Learning"},
                    new Book { title = "Introduction to Computing"}
                    }
                },
                new Author
                {
                    authorId = 3,
                    authorName = "Henry",
                    authorSurName = "Ford",
                    authorBirthdayDate = new DateTime(1986, 07, 09),
                    Books = new List<Book>()
                    {
                    new Book { title = "Introduction to Machine Learning"},
                    new Book { title = "Advanced Topics in Machine Learning"},
                    new Book { title = "Introduction to Computing"}
                    }
                }
                };

                context.Genres.AddRange(
                  new Genre
                  {
                      name = "PersonalGrowth"
                  },
                  new Genre
                  {
                      name = "ScienceFiction"
                  },
                  new Genre
                  {
                      name = "Noval"
                  }
                );

                context.Books.AddRange(
                new Book()
                {
                    title = "Lean Startup",
                    genreId = (int)1, // Personal Growth
                    authorId = 1,
                    pageCount = 200,
                    publishDate = new DateTime(2001, 06, 12)
                });

                context.Authors.AddRange(authors);
                

                context.SaveChanges();
            }
        }
    }
}