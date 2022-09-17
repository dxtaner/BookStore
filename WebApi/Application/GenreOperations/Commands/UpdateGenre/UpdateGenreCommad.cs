using WebApi.DBOperations;

namespace WebApi.Application.GenreOperations.Commands.UpdateGenre
{
    public class UpdateGenreCommand
    {
        public int genreId { get; set; }

        private readonly BookStoreDbContext _dbContext;

        public UpdateGenreModel Model;

        public UpdateGenreCommand(BookStoreDbContext context)
        {
            _dbContext = context;
        }
        public void Handle()
        {
            var genre = _dbContext.Genres.SingleOrDefault(g => g.Id == genreId);

            if (genre is null) throw new InvalidOperationException("Kitap türü bulunamadı.");

            if (_dbContext.Genres.Any(x => x.name.ToLower() == Model.name.ToLower() && x.Id != genreId))
                throw new InvalidOperationException("Aynı isimli bir kitap türü zaten mevcut.");

            genre.name = string.IsNullOrEmpty(Model.name.Trim()) ? genre.name : Model.name;
            genre.isActive = Model.isActive;
            _dbContext.SaveChanges();

        }

    }
    public class UpdateGenreModel
    {
        public string name { get; set; }
        public bool isActive { get; set; } = true;
    }
}