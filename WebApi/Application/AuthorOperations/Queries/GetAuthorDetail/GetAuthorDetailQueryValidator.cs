using FluentValidation;

namespace WebApi.Aplication.AuthorOperations.Queries.GetAuthorDetail
{
    public class GetAuthorsDetailQueryValidator : AbstractValidator<GetAuthorDetailQuery>
    {
        public GetAuthorsDetailQueryValidator()
        {
            RuleFor(a => a.authorId).GreaterThan(0).NotEmpty();
        }

    }
}