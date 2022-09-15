using AutoMapper;
using WebApi.DBOperations;

namespace WebApi.Aplication.GenreOperations.Queries.GetGenreDetail
{
    public class GetGenreQuery
    {

        public int genreId { get; set; }
        private readonly BookStoreDbContext _context;
        public readonly IMapper _mapper;

        public GetGenreQuery(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public GenreDetailViewModel  Handle()
        {
            var genre = _context.Genres.SingleOrDefault(x => x.isActive == true && x.Id == genreId);
            if (genre == null)
                throw new InvalidOperationException("Kitap türü bulunamadı");
            GenreDetailViewModel returnObj = _mapper.Map<GenreDetailViewModel>(genre);
           
            return returnObj;

        }
    }

    public class GenreDetailViewModel
    {
        public int Id { get; set; }
        public string name { get; set; }
    }


}