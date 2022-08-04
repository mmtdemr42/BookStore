using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.BookOperations.UpdateBook
{
    public class UpdateBookValidation : AbstractValidator<UpdateBook>
    {
        public UpdateBookValidation()
        {
            RuleFor(command => command.Model.GenreId).GreaterThan(0);
            RuleFor(command => command.Model.Title).NotEmpty().MinimumLength(10);
        }
    }
}
