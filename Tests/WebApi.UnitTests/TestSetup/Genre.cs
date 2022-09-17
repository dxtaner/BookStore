
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.UnitTests.TestSetup
{
    public static class Genres
    {
        public static void AddGenres(this BookStoreDbContext context)
        {
            context.Genres.AddRange(
                  new Genre
                  {
                    name = "Personel Growth"
                  },
                  new Genre
                  {
                    name = "Science Fiction"
                  },
                  new Genre
                  {
                    name = "Romance"
                  }
                  );

        }
    }
}