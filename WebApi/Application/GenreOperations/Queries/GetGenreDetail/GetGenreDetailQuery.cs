using AutoMapper;
using WebApi.DBOperations;

namespace WebApi.Application.GenreOperations.Queries.GetGenreDetail
{
    public class GetGenreDetailQuery
    {
        public int genreId { get; set; }
        public readonly BookStoreDbContext _dbContext;
        public readonly IMapper _mapper;
        public GetGenreDetailQuery(BookStoreDbContext context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }

        public GenreDetailViewModel Handle()
        {
            var genres = _dbContext.Genres.SingleOrDefault(g => g.isActive && g.Id == genreId);

            if(genres is null) 
                throw new InvalidOperationException("Kitap Türü bulunamadı.");

            return _mapper.Map<GenreDetailViewModel>(genres);
            
        }
    }

    public class GenreDetailViewModel
    {
        public int Id { get; set; }
        public string name { get; set; }
    }
}