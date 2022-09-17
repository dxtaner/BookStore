using FluentValidation;

namespace WebApi.Application.GenreOperations.Commands.UpdateGenre
{
    public class UpdateGenreCommandValidator : AbstractValidator<UpdateGenreCommand>
    {
        public UpdateGenreCommandValidator()
        {
            RuleFor(x=> x.Model.name).MinimumLength(4).When(g=>g.Model.name.Trim() != string.Empty);
        }
    }
}