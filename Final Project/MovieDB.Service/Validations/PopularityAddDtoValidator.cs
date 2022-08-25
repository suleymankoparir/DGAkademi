using FluentValidation;
using MovieDB.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDB.Service.Validations
{
    public class PopularityAddDtoValidator : AbstractValidator<PopularityAddDto>
    {
        public PopularityAddDtoValidator()
        {
            RuleFor(x => x.MovieId).NotNull().WithMessage("{PropertyName} is requiered").NotEmpty().WithMessage("{PropertyName} is requiered");
        }
    }
}
