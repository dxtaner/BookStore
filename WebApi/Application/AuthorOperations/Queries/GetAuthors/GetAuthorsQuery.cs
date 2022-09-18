using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.AuthorOperations.Queries.GetAuthors
{
    public class GetAuthorsQuery
    {
        private readonly IBookStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetAuthorsQuery(IBookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<AuthorsViewModel> Handle()
        {
            var authorList = _dbContext.Authors.Include(a => a.Books).OrderBy(a => a.authorId).ToList();

            List<AuthorsViewModel> vm = _mapper.Map<List<AuthorsViewModel>>(authorList);

            return vm;
        }
        public class AuthorsViewModel
        {
            public string authorName { get; set; }
            public string authorSurName { get; set; }
            public List<Book> Books { get; set; }
            public DateTime authorBirthdayDate { get; set; }
        }
    }
}