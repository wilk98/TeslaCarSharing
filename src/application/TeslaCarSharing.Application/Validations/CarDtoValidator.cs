using FluentValidation;
using TeslaCarSharing.Application.DTOs.Car;

namespace TeslaCarSharing.Application.Validations;


public class CarDtoValidator : AbstractValidator<CarDto>
{
    public CarDtoValidator()
    {
        RuleFor(x => x.RegistrationNumber)
            .NotEmpty().WithMessage("Registration number is required.")
            .Length(7).WithMessage("Registration number must have exactly 7 characters.");

        RuleFor(x => x.Model)
            .NotNull().WithMessage("Model is required.");

        RuleFor(x => x.Color)
            .NotEmpty().WithMessage("Color is required.");

        RuleFor(x => x.Year)
            .InclusiveBetween(1900, 2100).WithMessage("Year must be between 1900 and 2100.");

        RuleFor(x => x.Location)
            .NotNull().WithMessage("Location is required.");

    }
}
