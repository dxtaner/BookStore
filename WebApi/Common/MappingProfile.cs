using AutoMapper;
using WebApi.BookOperations.Commands.CreateBook;
using WebApi.BookOperations.GetBookDetail;
using static WebApi.BookOperations.GetBooks.GetBooksQuery;

namespace WebApi.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookModel, Book>();
            CreateMap<Book, GetBookDetailViewModel>().ForMember(dest => dest.genreId, opt => opt.MapFrom(src => ((GenreEnum)src.genreId).ToString()));
            CreateMap<Book,BooksViewModel>().ForMember(dest => dest.genreId, opt => opt.MapFrom(src => ((GenreEnum)src.genreId).ToString()));
        }
    }
}