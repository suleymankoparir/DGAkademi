using FluentValidation;
using MovieDB.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDB.Service.Validations
{
    public class DirectorUpdateDtoValidator : AbstractValidator<DirectorUpdateDto>
    {
        public DirectorUpdateDtoValidator()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("{PropertyName} is requiered").NotEmpty().WithMessage("{PropertyName} is requiered");
            RuleFor(x => x.Name).NotNull().WithMessage("{PropertyName} is requiered").NotEmpty().WithMessage("{PropertyName} is requiered");
            RuleFor(x => x.Birthday).NotNull().WithMessage("{PropertyName} is requiered").NotEmpty().WithMessage("{PropertyName} is requiered");
            RuleFor(x => x.Birthday).Custom((date, context) =>
            {
                if (DateTime.UtcNow < date)
                    context.AddFailure("The entered date cannot be later than the current date");
            });
        }
    }
}
