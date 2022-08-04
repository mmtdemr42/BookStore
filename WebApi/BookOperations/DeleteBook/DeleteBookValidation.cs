using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.BookOperations.DeleteBook
{
    public class DeleteBookValidation : AbstractValidator<DeleteBook>
    {
        public DeleteBookValidation()
        {
            RuleFor(command => command.BookId).GreaterThan(0);
        }
    }
}
