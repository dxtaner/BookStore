using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.UnitTests.TestSetup
{
    public static class Authors
    {
        public static void AddAuthors(this BookStoreDbContext context)
        {
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

            context.Authors.AddRange(authors);

        }
    }
}