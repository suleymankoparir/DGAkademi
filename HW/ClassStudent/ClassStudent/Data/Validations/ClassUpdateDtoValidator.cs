using ClassStudent.Data.DTOs;
using FluentValidation;

namespace ClassStudent.Data.Validations
{
    public class ClassUpdateDtoValidator : AbstractValidator<ClassUpdateDto>
    {
        public ClassUpdateDtoValidator()
        {
            RuleFor(x => x.Id).InclusiveBetween(1, int.MaxValue).WithMessage("{PropertyName} must be greater than 0");
            RuleFor(x => x.Name).NotEmpty().WithMessage("{PropertyName} is requiered.").NotNull().WithMessage("{PropertyName} is requiered.");
        }
    }
}
