using WebApi.DBOperations;

namespace WebApi.Application.AuthorOperations.Commands.DeleteAuthor
{
    public class DeleteAuthorCommand
    {
        private readonly IBookStoreDbContext _dbContext;
        public int AuthorId { get; set; }
        public DeleteAuthorCommand(IBookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            
            var Author = _dbContext.Authors.SingleOrDefault(b => b.authorId == AuthorId);

            if (Author is null)
                throw new InvalidOperationException("Silinecek Yazar Bulunamadı!");

            _dbContext.Authors.Remove(Author);
            _dbContext.SaveChanges();
        }
    }
}