using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W_02.Core.Models;

namespace W_02.Service.Validations
{
    public class TokenValidator : AbstractValidator<Token>
    {
        public TokenValidator()
        {
            RuleFor(x => x.JwtToken).NotEmpty().WithMessage("{PropertyName} is requiered.").NotNull().WithMessage("{PropertyName} is requiered.");
            RuleFor(x => x.RefreshToken).NotEmpty().WithMessage("{PropertyName} is requiered.").NotNull().WithMessage("{PropertyName} is requiered.");
        }
    }
}
