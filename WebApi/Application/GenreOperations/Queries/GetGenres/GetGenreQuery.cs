using AutoMapper;
using FluentValidation;
using WebApi.DBOperations;

namespace WebApi.Aplication.GenreOperations.Queries.GetGenres
{
    public class GetGenreQuery
    {

        private readonly BookStoreDbContext _context;
        public readonly IMapper _mapper;

        public GetGenreQuery(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<GenreViewModel> Handle()
        {
            var genres = _context.Genres.Where(x => x.isActive == true).OrderBy(x => x.Id);
            List<GenreViewModel> returnObj = _mapper.Map<List<GenreViewModel>>(genres);
            return returnObj;

        }
    }

    public class GenreViewModel
    {
        public int Id { get; set; }
        public string name { get; set; }
    }


}