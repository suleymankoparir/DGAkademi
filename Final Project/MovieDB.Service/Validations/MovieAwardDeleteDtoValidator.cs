using FluentValidation;
using MovieDB.Core.DTOs;

namespace MovieDB.Service.Validations
{
    public class MovieAwardDeleteDtoValidator : AbstractValidator<MovieAwardDeleteDto>
    {
        public MovieAwardDeleteDtoValidator()
        {
            RuleFor(x => x.MovieId).NotNull().WithMessage("{PropertyName} is requiered").NotEmpty().WithMessage("{PropertyName} is requiered");
            RuleFor(x => x.AwardId).NotNull().WithMessage("{PropertyName} is requiered").NotEmpty().WithMessage("{PropertyName} is requiered");
        }
    }
}
