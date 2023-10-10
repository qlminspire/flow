using Flow.Api.Models.Currency;
using Flow.Application.Contracts.Services;
using FluentValidation;

namespace Flow.Api.Validators.Currency;

public sealed class CreateCurrencyRequestValidator : AbstractValidator<CreateCurrencyRequest>
{
    private readonly ICurrencyService _currencyService;

    public CreateCurrencyRequestValidator(ICurrencyService currencyService)
    {
        _currencyService = currencyService;

        RuleFor(x => x.Code).NotEmpty().Length(3);
        RuleFor(x => x.Name).NotEmpty().Length(3, 64);
        RuleFor(x => x.IsActive).NotNull();
        // Make sure currency with same code not exists
    }
}
