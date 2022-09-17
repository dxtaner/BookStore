using FluentValidation;

namespace WebApi.Application.AuthorOperations.Commands.UpdateAuthor
{
    public class UpdateAuthorCommandValidator : AbstractValidator<UpdateAuthorCommand>
    {
        public UpdateAuthorCommandValidator()
        {
            RuleFor(command => command.Model.authorName).NotEmpty().MinimumLength(3);
            RuleFor(command => command.Model.authorSurName).NotEmpty().MinimumLength(3);
            RuleFor(command => command.Model.authorBirthdayDate.Date).NotEmpty().LessThan(DateTime.Now.Date);
        }
    }
}