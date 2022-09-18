using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.AuthorOperations.Commands.CreateAuthor
{
    public class CreateAuthorCommand
    {
        public CreateAuthorModel Model { get; set; }
        private readonly IBookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        private IBookStoreDbContext context;

        public CreateAuthorCommand(IBookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public CreateAuthorCommand(IBookStoreDbContext context)
        {
            this.context = context;
        }

        public void Handle()
        {

            var Author = _dbContext.Authors.SingleOrDefault(b => b.authorName == Model.authorName && b.authorSurName == Model.authorSurName && b.authorBirthdayDate == Model.authorBirthdayDate);

            if (Author is not null)
                throw new InvalidOperationException("Yazar Zaten Mevcut!");

            Author = _mapper.Map<Author>(Model);

            _dbContext.Authors.Add(Author);
            _dbContext.SaveChanges();
        }

    }

    public class CreateAuthorModel
    {
        public string authorName { get; set; }
        public string authorSurName { get; set; }
        public DateTime authorBirthdayDate { get; set; }
    }
}