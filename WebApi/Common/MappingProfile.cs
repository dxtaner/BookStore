using AutoMapper;
using WebApi.Entities;
using WebApi.Application.BookOperations.Commands.CreateBook;
using WebApi.Aplication.GenreOperations.Queries.GetGenres;
using WebApi.Application.GenreOperations.Queries.GetGenreDetail;
using WebApi.Application.AuthorOperations.Commands.CreateAuthor;
using static WebApi.Application.AuthorOperations.Queries.GetAuthors.GetAuthorsQuery;
using WebApi.Application.BookOperations.Queries.GetBookDetail;
using static WebApi.Application.BookOperations.Queries.GetBooks.GetBooksQuery;
using static WebApi.Aplication.UserOperations.Commands.CreateUser.CreateUserCommand;

namespace WebApi.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookModel, Book>();
            CreateMap<Book, GetBookDetailViewModel>().ForMember(dest => dest.genreId, opt => opt.MapFrom(src => src.genre.name));
            CreateMap<Book, BooksViewModel>().ForMember(dest => dest.genreId, opt => opt.MapFrom(src => src.genre.name));
            CreateMap<Genre, GenreViewModel>();
            CreateMap<Genre, GenreDetailViewModel>();
            CreateMap<Author, AuthorsViewModel>();
            CreateMap<CreateAuthorModel, Author>();
            CreateMap<CreateUserModel,User>();


        }
    }
}