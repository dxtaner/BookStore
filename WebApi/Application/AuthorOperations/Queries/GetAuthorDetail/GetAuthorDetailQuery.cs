using WebApi.DBOperations;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Aplication.AuthorOperations.Queries.GetAuthorDetail
{
    public class GetAuthorDetailQuery
    {
        private readonly IBookStoreDbContext _dbContext;
        public int authorId { get; set; }
        private readonly IMapper _mapper;

        public GetAuthorDetailQuery(IBookStoreDbContext dbContext, IMapper mapper)
        {
            this._dbContext = dbContext;
            _mapper = mapper;
        }

        public GetAuthorDetailViewModel Handle()
        {
            var Author = _dbContext.Authors.Include(a => a.Books).Where(Author => Author.authorId == authorId).SingleOrDefault();
            if (Author is null)
                throw new InvalidOperationException("Böyle Bir Yazar Bulunamadı!");

            GetAuthorDetailViewModel vm = _mapper.Map<GetAuthorDetailViewModel>(Author);

            return vm;
        }
    }
    public class GetAuthorDetailViewModel
    {
        public string authorName { get; set; }
        public string authorSurName { get; set; }
        public DateTime authorBirthdayDate { get; set; }

    }
}
