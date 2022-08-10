using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W_02.Core.DTOs;

namespace W_02.Service.Validations
{
    public class PersonUpdateDtoValidator: AbstractValidator<PersonUpdateDto>
    {
        public PersonUpdateDtoValidator()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("{PropertyName} is requiered").NotEmpty().WithMessage("{PropertyName} is requiered");
            RuleFor(x => x.Id).InclusiveBetween(1, int.MaxValue).WithMessage("{PropertyName} is requiered must be greater or equel to 1");
            RuleFor(x => x.DepartmentId).InclusiveBetween(0, int.MaxValue).WithMessage("{PropertyName} is requiered must be greater or equel to 0");
            RuleFor(x => x.RoleId).InclusiveBetween(0, int.MaxValue).WithMessage("{PropertyName} is requiered must be greater or equel to 0");
        }
    }
}
