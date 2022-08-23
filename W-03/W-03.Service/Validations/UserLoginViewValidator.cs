using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W_03.Core.Views;

namespace W_03.Service.Validations
{
    public class UserLoginViewValidator : AbstractValidator<UserLoginView>
    {
        public UserLoginViewValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("{PropertyName} is requiered.").NotNull().WithMessage("{PropertyName} is requiered.").EmailAddress().WithMessage("Wrong email format");
            RuleFor(x => x.Password).NotEmpty().WithMessage("{PropertyName} is requiered.").NotNull().WithMessage("{PropertyName} is requiered.");
        }
    }
}
