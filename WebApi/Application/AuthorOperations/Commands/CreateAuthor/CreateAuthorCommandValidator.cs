using FluentValidation;

namespace WebApi.Application.AuthorOperations.Commands.CreateAuthor
{
    public class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommand>
    {
        public CreateAuthorCommandValidator()
        {
            RuleFor(command => command.Model.authorName).NotEmpty().MinimumLength(3);
            RuleFor(command => command.Model.authorName).NotEmpty().MinimumLength(3);
            RuleFor(command => command.Model.authorBirthdayDate.Date).NotEmpty().LessThan(DateTime.Now.Date);
        }
    }
}