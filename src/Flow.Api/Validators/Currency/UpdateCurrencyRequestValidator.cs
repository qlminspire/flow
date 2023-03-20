using Flow.Api.Models.Currency;
using Flow.Application.Services;
using FluentValidation;

namespace Flow.Api.Validators.Currency;

public sealed class UpdateCurrencyRequestValidator : AbstractValidator<UpdateCurrencyRequest>
{
    private readonly ICurrencyService _currencyService;

    public UpdateCurrencyRequestValidator(ICurrencyService currencyService)
    {
        _currencyService = currencyService;

        RuleFor(x => x.Code).NotEmpty().Length(3);
        RuleFor(x => x.Name).NotEmpty().Length(3, 64);

        // Make sure currency with same code not exists
    }
}
