using FluentValidation;

namespace WebApi.Application.GenreOperations.Queries.GetGenreDetail
{
    public class GetGenreDetailQueryValidator : AbstractValidator<GetGenreDetailQuery>
    {
        public GetGenreDetailQueryValidator()
        {
            RuleFor(g => g.genreId).GreaterThan(0).WithMessage("Lütfen 0'dan büyük bir sayı yazınız.");
        }
    }
}