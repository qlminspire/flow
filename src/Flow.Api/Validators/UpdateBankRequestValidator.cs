using Flow.Api.Models.Bank;
using FluentValidation;

namespace Flow.Api.Validators;

public class UpdateBankRequestValidator : AbstractValidator<UpdateBankRequest>
{
    public UpdateBankRequestValidator()
    {
        RuleFor(x => x.Name).NotEmpty().Length(3, 32);
        RuleFor(x => x.IsActive).NotEmpty().NotNull();
    }
}
