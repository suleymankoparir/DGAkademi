using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W_02.Core.DTOs;

namespace W_02.Service.Validations
{
    public class ProductAddDtoValidator: AbstractValidator<ProductAddDto>
    {
        public ProductAddDtoValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("{PropertyName} is requiered").NotEmpty().WithMessage("{PropertyName} is requiered");
            RuleFor(x => x.Price).InclusiveBetween(1, decimal.MaxValue).WithMessage("{PropertyName} is requiered must be greater 0");
            RuleFor(x => x.Stock).InclusiveBetween(0, int.MaxValue).WithMessage("{PropertyName} is requiered must be greater or equel to 0");
        }
    }
}
