using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W_03.Core.Views;

namespace W_03.Service.Validations
{
    public class SaleAddViewValidator : AbstractValidator<SaleAddView>
    {
        public SaleAddViewValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().WithMessage("{PropertyName} is requiered.").NotNull().WithMessage("{PropertyName} is requiered.");
            RuleFor(x => x.ProductId).NotEmpty().WithMessage("{PropertyName} is requiered.").NotNull().WithMessage("{PropertyName} is requiered.");
        }
    }
}
