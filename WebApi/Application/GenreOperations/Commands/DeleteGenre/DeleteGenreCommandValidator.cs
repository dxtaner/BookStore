using FluentValidation;

namespace WebApi.Aplication.GenreOperations.Commands.DeleteGenre{

    public class DeleteGenreCommandValidator: AbstractValidator<DeleteGenreCommand>
    {
        public DeleteGenreCommandValidator()
        {
            RuleFor(command => command.genreId).GreaterThan(0);
        }
    }
}