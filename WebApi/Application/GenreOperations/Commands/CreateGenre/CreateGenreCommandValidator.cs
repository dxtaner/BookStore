using FluentValidation;
using WebApi.Applications.GenreOperations.Commands.CreateGenre;

namespace WebApi.Aplication.GenreOperations.Commands.CreateGenre
{
    public class CreateGenreCommandValidator:AbstractValidator<CreateGenreCommand>
    {
        public CreateGenreCommandValidator()
        {
            RuleFor(command => command.Model.name).NotEmpty().MinimumLength(3);
        }
    }
}