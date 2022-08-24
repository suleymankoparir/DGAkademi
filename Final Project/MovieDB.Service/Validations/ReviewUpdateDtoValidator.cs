using FluentValidation;
using MovieDB.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDB.Service.Validations
{
    public class ReviewUpdateDtoValidator : AbstractValidator<ReviewUpdateDto>
    {
        public ReviewUpdateDtoValidator()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("{PropertyName} is requiered").NotEmpty().WithMessage("{PropertyName} is requiered");
            RuleFor(x => x.MovieId).NotNull().WithMessage("{PropertyName} is requiered").NotEmpty().WithMessage("{PropertyName} is requiered");
            RuleFor(x => x.Score).InclusiveBetween(1, 100).WithMessage("Score range is 1 to 100");
            RuleFor(x => x.Comment).NotNull().WithMessage("{PropertyName} is requiered").NotEmpty().WithMessage("{PropertyName} is requiered");
            RuleFor(x => x.Score).NotNull().WithMessage("{PropertyName} is requiered").NotEmpty().WithMessage("{PropertyName} is requiered");
        }
    }
}
