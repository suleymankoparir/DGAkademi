using FluentValidation;
using MovieDB.Core.DTOs;

namespace MovieDB.Service.Validations
{
    public class MovieCategoryDtoValidator : AbstractValidator<MovieCategoryDto>
    {
        public MovieCategoryDtoValidator()
        {
            RuleFor(x => x.MovieId).NotNull().WithMessage("{PropertyName} is requiered").NotEmpty().WithMessage("{PropertyName} is requiered");
            RuleFor(x => x.CategoryId).NotNull().WithMessage("{PropertyName} is requiered").NotEmpty().WithMessage("{PropertyName} is requiered");
        }
    }
}
