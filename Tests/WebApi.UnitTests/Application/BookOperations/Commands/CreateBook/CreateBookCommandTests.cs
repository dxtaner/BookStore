using AutoMapper;
using FluentAssertions;
using TestSetup;
using WebApi.Application.BookOperations.Commands.CreateBook;
using WebApi.DBOperations;
using WebApi.Entities;
using Xunit;

namespace WebApi.UnitTests.Application.BookOperations.Commands.CreateBook
{
    public class CreateBookCommandTests : IClassFixture<CommonTestFixture>
    {

        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public CreateBookCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenAlreadyExistBookTitleIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            //Arrange (Hazırlık)
            var book = new Book()
            {
                title = "Test_WhenAlreadyExistBookTitleIsGiven_InvalidOperationException_ShouldBeReturn",
                pageCount = 120,
                publishDate = new DateTime(1992, 01, 15),
                genreId = 1
            };
            _context.Books.Add(book);
            _context.SaveChanges();

            CreateBookCommand command = new CreateBookCommand(_context, _mapper);
            command.Model = new CreateBookModel() { title = book.title };

            //Act  & Assert(Çalıştırma -Doğrulama)
            FluentActions.
                Invoking(() => command.Handle()).
                Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kitap zaten mevcut");

            //Assert (Doğrulama)
        }

        [Fact]
        public void WhenValidInputAreGiven_Book_ShouldBeGreated()
        {
            //Arrange
            CreateBookCommand command = new CreateBookCommand(_context, _mapper);
            CreateBookModel model = new CreateBookModel()
            {
                title = "Kv vadisi pusu",
                pageCount = 250,
                publishDate = DateTime.Now.Date.AddYears(-5),
                genreId = 1
            };

            command.Model = model;

            //Act
            FluentActions.Invoking(() => command.Handle()).Invoke();

            //Assert
            var book = _context.Books.SingleOrDefault(book => book.title == model.title);
            book.Should().NotBeNull();
            book.pageCount.Should().Be(model.pageCount);
            book.publishDate.Should().Be(model.publishDate);
            // book.title.Should().Be(model.title); 
            book.genreId.Should().Be(model.genreId);
        }


    }

}