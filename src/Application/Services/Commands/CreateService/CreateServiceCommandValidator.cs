using FluentValidation;

namespace BookingHive.Application.Services.Commands.CreateService;

public class CreateServiceCommandValidator : AbstractValidator<CreateServiceCommand>
{
    public CreateServiceCommandValidator()
    {
        RuleFor(v => v.Title)
            .MaximumLength(100)
            .NotEmpty();

        RuleFor(v => v.Description)
            .MaximumLength(350);
    }
}
