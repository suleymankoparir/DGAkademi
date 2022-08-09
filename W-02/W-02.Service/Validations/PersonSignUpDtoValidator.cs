using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W_02.Core.DTOs;

namespace W_02.Service.Validations
{
    public class PersonSignUpDtoValidator: AbstractValidator<PersonSignUpDto>
    {
        public PersonSignUpDtoValidator()
        {
            RuleFor(x=>x.FullName).NotNull().WithMessage("{PropertyName} is requiered").NotEmpty().WithMessage("{PropertyName} is requiered");
            RuleFor(x => x.UserName).NotNull().WithMessage("{PropertyName} is requiered").NotEmpty().WithMessage("{PropertyName} is requiered");
            RuleFor(x => x.Password).NotNull().WithMessage("{PropertyName} is requiered").NotEmpty().WithMessage("{PropertyName} is requiered");
            RuleFor(x => x.RoleId).NotNull().WithMessage("{PropertyName} is requiered").NotEmpty().WithMessage("{PropertyName} is requiered");
            RuleFor(x => x.DepartmantId).NotNull().WithMessage("{PropertyName} is requiered").NotEmpty().WithMessage("{PropertyName} is requiered");

            RuleFor(x => x.RoleId).InclusiveBetween(0, int.MaxValue).WithMessage("{PropertyName} is requiered must be greater or equel to 0");
            RuleFor(x => x.DepartmantId).InclusiveBetween(0, int.MaxValue).WithMessage("{PropertyName} is requiered must be greater or equel to 0");
        }
    }
}
