using FluentValidation;

namespace WebApi.BookOperations.GetBookDetail
{
    public class GetBookQueryValidator : AbstractValidator<GetBookDetailQuery>
    {
        public GetBookQueryValidator()
        {
            RuleFor(command => command.BookId).GreaterThan(0);
          
        }

    }
}