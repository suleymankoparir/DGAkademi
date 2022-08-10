using ClassStudent.Data.DTOs;
using FluentValidation;

namespace ClassStudent.Data.Validations
{
    public class ClassAddDtoValidator : AbstractValidator<ClassAddDto>
    {
        public ClassAddDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("{PropertyName} is requiered.").NotNull().WithMessage("{PropertyName} is requiered.");
        }
    }
}
