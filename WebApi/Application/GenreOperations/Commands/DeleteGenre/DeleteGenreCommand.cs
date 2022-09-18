using WebApi.DBOperations;

namespace WebApi.Aplication.GenreOperations.Commands.DeleteGenre{

    public class DeleteGenreCommand
    {
        public int genreId { get; set; }
        private readonly IBookStoreDbContext _dbContext;
        public DeleteGenreCommand(IBookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var genre = _dbContext.Genres.SingleOrDefault(x => x.Id == genreId);
            if (genre ==null)
            {
                throw new InvalidOperationException("Kitap türü bulunamadı!");
            }

            _dbContext.Genres.Remove(genre);
            _dbContext.SaveChanges();

        }
    }
}