using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using W_03.Core.Views;

namespace W_03.Service.Validations
{
    public class PreRegistrationViewValidator : AbstractValidator<PreRegistrationView>
    {
        public PreRegistrationViewValidator()
        {
            Regex regex = new Regex("\\b((25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)(\\.|$)){4}\\b");
            RuleFor(x => x.Email).NotEmpty().WithMessage("{PropertyName} is requiered.").NotNull().WithMessage("{PropertyName} is requiered.").EmailAddress().WithMessage("Wrong email format");
            RuleFor(x => x.Ip).NotEmpty().WithMessage("{PropertyName} is requiered.").NotNull().WithMessage("{PropertyName} is requiered.");
            RuleFor(x => x.Ip).Custom((data, context) =>
            {
                if (data!=null&&!regex.IsMatch(data))
                    context.AddFailure("Wrong ip format");
            });
        }
    }
}
