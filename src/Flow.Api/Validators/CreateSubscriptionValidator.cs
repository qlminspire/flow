using Flow.Api.Models.Subscription;
using Flow.Application.Services;
using FluentValidation;

namespace Flow.Api.Validators;

public class CreateSubscriptionValidator : AbstractValidator<CreateSubscriptionRequest>
{
    private readonly ICurrencyService _currencyService;

    public CreateSubscriptionValidator(ICurrencyService currencyService)
    {
        _currencyService = currencyService;

        RuleFor(x => x.Service).NotEmpty().Length(2, 64);
        RuleFor(x => x.Price).NotNull().GreaterThan(0);
        //RuleFor(x => x.CurrencyId).NotEmpty()
        //    .MustAsync(_currencyService.ExistsAsync)
        //    .WithMessage("Currency not found");
    }
}
