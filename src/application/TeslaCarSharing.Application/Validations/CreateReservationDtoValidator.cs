using FluentValidation;
using TeslaCarSharing.Application.DTOs.Reservation;

namespace TeslaCarSharing.Application.Validations;
public class CreateReservationDtoValidator : AbstractValidator<CreateReservationDto>
{
    public CreateReservationDtoValidator()
    {
        RuleFor(dto => dto.Customer).NotNull().SetValidator(new CustomerDtoValidator());
        RuleFor(dto => dto.CarId).NotEmpty();
        RuleFor(x => x.StartDate)
            .NotEmpty().WithMessage("Start date is required.")
            .LessThan(x => x.EndDate).WithMessage("Start date must be less than end date.")
            .GreaterThanOrEqualTo(DateTime.UtcNow).WithMessage("Start date must be in the future.");

        RuleFor(x => x.EndDate)
            .NotEmpty().WithMessage("End date is required.")
            .GreaterThan(x => x.StartDate).WithMessage("End date must be greater than start date.")
            .GreaterThanOrEqualTo(DateTime.UtcNow).WithMessage("End date must be in the future.");

        RuleFor(x => x.StartLocation)
            .NotEmpty().WithMessage("Start location is required.");

        RuleFor(x => x.EndLocation)
            .NotEmpty().WithMessage("End location is required.");
    }
}
