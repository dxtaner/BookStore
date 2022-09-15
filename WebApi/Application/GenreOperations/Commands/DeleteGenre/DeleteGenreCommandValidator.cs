using FluentValidation;

namespace WebApi.Aplication.GenreOperations.DeleteGenre{

    public class DeleteGenreCommandValidator: AbstractValidator<DeleteGenreCommand>
    {
        public DeleteGenreCommandValidator()
        {
            RuleFor(command => command.genreId).GreaterThan(0);
        }
    }
}