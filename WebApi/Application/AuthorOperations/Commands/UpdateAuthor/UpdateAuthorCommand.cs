using WebApi.DBOperations;

namespace WebApi.Application.AuthorOperations.Commands.UpdateAuthor
{
    public class UpdateAuthorCommand
    {
        public int authorId { get; set; }

        private readonly IBookStoreDbContext _dbContext;

        public UpdateAuthorModel Model;

        public UpdateAuthorCommand(IBookStoreDbContext context)
        {
            _dbContext = context;
        }
        public void Handle()
        {
            var author = _dbContext.Authors.SingleOrDefault(a => a.authorId == authorId);

            if (author is null) throw new InvalidOperationException("Yazar türü bulunamadı.");

            if (_dbContext.Authors.Any(x => x.authorName.ToLower() == Model.authorName.ToLower() && x.authorId != authorId))
                throw new InvalidOperationException("Aynı isimli bir yazar zaten mevcut.");

            author.authorName = string.IsNullOrEmpty(Model.authorName.Trim()) ? author.authorName : Model.authorName;
            author.authorSurName = string.IsNullOrEmpty(Model.authorSurName.Trim()) ? author.authorSurName : Model.authorSurName;
            author.authorBirthdayDate = Model.authorBirthdayDate != default ? Model.authorBirthdayDate : author.authorBirthdayDate;

            _dbContext.SaveChanges();

        }

    }
    public class UpdateAuthorModel
    {
        public string authorName { get; set; }
        public string authorSurName { get; set; }
        public DateTime authorBirthdayDate { get; set; }
    }
}