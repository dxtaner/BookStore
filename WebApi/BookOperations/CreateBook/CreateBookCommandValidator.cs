using System;
using FluentValidation;

namespace WebApi.BookOperations.Commands.CreateBook
{
    public class CreateBookCommandValidator: AbstractValidator<CreateBookCommand>
    {
        public CreateBookCommandValidator()
        {
            RuleFor(command => command.Model.genreId).GreaterThan(0);
            RuleFor(command => command.Model.pageCount).GreaterThan(0);
            RuleFor(command => command.Model.publishDate.Date).NotEmpty().LessThan(DateTime.Now.Date);
            RuleFor(command => command.Model.title).NotEmpty().MinimumLength(4);
        }   
    }
}