using AutoMapper;
using WebApi.Entities;
using WebApi.Applications.GenreOperations.GetGenreDetail;

namespace WebApi.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookModel, Book>();
            CreateMap<Book, GetBookDetailViewModel>().ForMember(dest => dest.genreId, opt => opt.MapFrom(src => src.genre.name));
            CreateMap<Book, BooksViewModel>().ForMember(dest => dest.genreId, opt => opt.MapFrom(src =>src.genre.name));
            CreateMap<Genre, GenreViewModel>();
            CreateMap<Genre, GenreDetailViewModel>();

        }
    }
}