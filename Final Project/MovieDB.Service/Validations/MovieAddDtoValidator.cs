using FluentValidation;
using MovieDB.Core.DTOs;

namespace MovieDB.Service.Validations
{
    public class MovieAddDtoValidator : AbstractValidator<MovieAddDto>
    {
        public MovieAddDtoValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("{PropertyName} is requiered").NotEmpty().WithMessage("{PropertyName} is requiered");
            RuleFor(x => x.MovieTypeId).NotNull().WithMessage("{PropertyName} is requiered").NotEmpty().WithMessage("{PropertyName} is requiered");
            RuleFor(x => x.Budget).NotNull().WithMessage("{PropertyName} is requiered").NotEmpty().WithMessage("{PropertyName} is requiered");
            RuleFor(x => x.Gross).NotNull().WithMessage("{PropertyName} is requiered").NotEmpty().WithMessage("{PropertyName} is requiered");
            RuleFor(x => x.ReleaseDate).NotNull().WithMessage("{PropertyName} is requiered").NotEmpty().WithMessage("{PropertyName} is requiered");
            RuleFor(x => x.ReleaseDate).Custom((date, context) =>
            {
                if (DateTime.UtcNow < date)
                    context.AddFailure("The entered date cannot be later than the current date");
            });
        }
    }
}
