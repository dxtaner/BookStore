using FluentValidation;

namespace WebApi.Aplication.GenreOperations.Queries.GetGenreDetail
{
    public class GetGenreDetailQueryValidator: AbstractValidator<GetGenreQuery>
    {
        public GetGenreDetailQueryValidator()
        {
            RuleFor(query => query.genreId).GreaterThan(0);
        }
    }
}