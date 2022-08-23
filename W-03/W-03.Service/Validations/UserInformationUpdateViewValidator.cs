using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W_03.Core.Views;

namespace W_03.Service.Validations
{
    public class UserInformationUpdateViewValidator : AbstractValidator<UserInformationUpdateView>
    {
        public UserInformationUpdateViewValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("{PropertyName} is requiered.").NotNull().WithMessage("{PropertyName} is requiered.");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("{PropertyName} is requiered.").NotNull().WithMessage("{PropertyName} is requiered.");
            RuleFor(x => x.FullAddress).NotEmpty().WithMessage("{PropertyName} is requiered.").NotNull().WithMessage("{PropertyName} is requiered.");
            RuleFor(x => x.City).NotEmpty().WithMessage("{PropertyName} is requiered.").NotNull().WithMessage("{PropertyName} is requiered.");
            RuleFor(x => x.Country).NotEmpty().WithMessage("{PropertyName} is requiered.").NotNull().WithMessage("{PropertyName} is requiered.");
        }
    }
}
