using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.BookOperations.CreateBook;

namespace WebApi.BookOperations.GetBooks
{
    public class GetBooksQueryValidation : AbstractValidator<GetBookQuery>
    {
        public GetBooksQueryValidation()
        {
            RuleFor(command => command.BookId).NotEmpty().GreaterThan(0);
        }
    }
}
