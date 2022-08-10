using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W_02.Core.DTOs;

namespace W_02.Service.Validations
{
    public class ProductUpdateDtoValidator :AbstractValidator<ProductUpdateDto>
    {
        public ProductUpdateDtoValidator()
        {;
            RuleFor(x => x.Id).InclusiveBetween(1, int.MaxValue).WithMessage("{PropertyName} is requiered must be greater or equel to 1");
            RuleFor(x => x.Price).InclusiveBetween(1, decimal.MaxValue).WithMessage("{PropertyName} is requiered must be greater 1");
            RuleFor(x => x.Stock).InclusiveBetween(0, int.MaxValue).WithMessage("{PropertyName} is requiered must be greater or equel to 0");
        }
    }
}
