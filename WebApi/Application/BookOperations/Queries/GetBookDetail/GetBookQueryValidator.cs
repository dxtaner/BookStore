using FluentValidation;

namespace WebApi.Application.BookOperations.Queries.GetBookDetail
{
    public class GetBookQueryValidator : AbstractValidator<GetBookDetailQuery>
    {
        public GetBookQueryValidator()
        {
            RuleFor(command => command.BookId).GreaterThan(0);
          
        }

    }
}