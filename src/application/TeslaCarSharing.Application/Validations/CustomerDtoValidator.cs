using FluentValidation;
using TeslaCarSharing.Application.DTOs.Customer;

namespace TeslaCarSharing.Application.Validations;

public class CustomerDtoValidator : AbstractValidator<CustomerDto>
{
    public CustomerDtoValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty().WithMessage("First name is required.");
        RuleFor(x => x.LastName).NotEmpty().WithMessage("Last name is required.");
        RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Email is not valid.");
        RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Phone number is required.");
    }
}
