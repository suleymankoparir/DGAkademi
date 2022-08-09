using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W_02.Core.DTOs;

namespace W_02.Service.Validations
{
    public class PersonLoginDtoValidator:AbstractValidator<PersonLoginDto>
    {
        public PersonLoginDtoValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("{PropertyName} is requiered.").NotNull().WithMessage("{PropertyName} is requiered.");
            RuleFor(x => x.Password).NotEmpty().WithMessage("{PropertyName} is requiered.").NotNull().WithMessage("{PropertyName} is requiered.");
        }
    }
}
