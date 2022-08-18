using FluentValidation;
using MovieDB.Core.DTOs;

namespace MovieDB.Service.Validations
{
    public class MoviePerformerDtoValidator : AbstractValidator<MoviePerformerDto>
    {
        public MoviePerformerDtoValidator()
        {
            RuleFor(x => x.MovieId).NotNull().WithMessage("{PropertyName} is requiered").NotEmpty().WithMessage("{PropertyName} is requiered");
            RuleFor(x => x.PerformerId).NotNull().WithMessage("{PropertyName} is requiered").NotEmpty().WithMessage("{PropertyName} is requiered");
        }
    }
}
