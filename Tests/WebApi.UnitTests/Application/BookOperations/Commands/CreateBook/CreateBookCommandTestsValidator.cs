using FluentAssertions;
using WebApi.Application.BookOperations.Commands.CreateBook;
using Xunit;

namespace WebApi.UnitTests.Application.BookOperations.Commands.CreateBook
{
    public class CreateBookCommandValidatorTests
    {
        [Theory]
        [InlineData("Lotr", 0, 0)]
        [InlineData("Gad", 0, 1)]
        [InlineData("Kvp", 100, 0)]
        [InlineData("", 0, 0)]
        [InlineData("", 100, 1)]
        [InlineData("", 0, 1)]
        [InlineData("Lor", 100, 1)]
        [InlineData("Bad V", 100, 0)]
        [InlineData("How B B", 0, 1)]
        [InlineData(" ", 100, 1)]
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(string title, int pageCount, int genreId)
        {
            //Arrange
            CreateBookCommand command = new CreateBookCommand(null, null);
            command.Model = new CreateBookModel()
            {
                title = title,
                pageCount = pageCount,
                publishDate = DateTime.Now.Date.AddYears(-1),
                genreId = genreId
            };

            //Act
            CreateBookCommandValidator validator = new CreateBookCommandValidator();
            var result = validator.Validate(command);

            //Assert
            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenDateTimeEqualNowIsGiven_Validator_ShouldBeReturnError()
        {
            CreateBookCommand command = new CreateBookCommand(null, null);
            command.Model = new CreateBookModel()
            {
                title = "Brekkanig Var",
                pageCount = 1550,
                publishDate = DateTime.Now.Date,
                genreId = 1
            };

            CreateBookCommandValidator validator = new CreateBookCommandValidator();
            var result = validator.Validate(command);
            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenValidInputAreGiven_Validator_ShouldNotBeReturnError()
        {
            CreateBookCommand command = new CreateBookCommand(null, null);
            command.Model = new CreateBookModel()
            {
                title = "Breakin Bad",
                pageCount = 1500,
                publishDate = DateTime.Now.Date.AddYears(-2),
                genreId = 1
            };

            CreateBookCommandValidator validator = new CreateBookCommandValidator();
            var result = validator.Validate(command);
            result.Errors.Count.Should().Equals(0);

        }
    }
}
