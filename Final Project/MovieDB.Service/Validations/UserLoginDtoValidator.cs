using FluentValidation;
using MovieDB.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDB.Service.Validations
{
    public class UserLoginDtoValidator : AbstractValidator<UserLoginDto>
    {
        public UserLoginDtoValidator()
        {
            RuleFor(x => x.Username).NotNull().WithMessage("{PropertyName} is requiered").NotEmpty().WithMessage("{PropertyName} is requiered");
            RuleFor(x => x.Password).NotNull().WithMessage("{PropertyName} is requiered").NotEmpty().WithMessage("{PropertyName} is requiered");
        }
    }
}
