using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W_01.Core.DTOs;

namespace W_01.Service.Validations
{
    public class UserDtoValidator : AbstractValidator<UserDto>
    {
        public UserDtoValidator()
        {
            RuleFor(x => x.UserName)
                .NotNull().WithMessage("The UserName field is required.")
                .NotEmpty().WithMessage("The UserName field is required.")
                .MinimumLength(4).WithMessage("{PropertyName} minimum length is 4 character")
                .MaximumLength(32).WithMessage("{PropertyName} maximum length is 32 character");
            RuleFor(x => x.Password)
                .NotNull().WithMessage("The Password field is required.")
                .NotEmpty().WithMessage("The Password field is required.")
                .MinimumLength(4).WithMessage("{PropertyName} minimum length is 4 character")
                .MaximumLength(32).WithMessage("{PropertyName} maximum length is 32 character");
        }
    }
}
