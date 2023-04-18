using System.ComponentModel.DataAnnotations;

namespace Flow.Api.Models.Currency;

public sealed record CreateCurrencyRequest
{
    [Required]
    [StringLength(3, MinimumLength = 3)]
    public string Code { get; init; }

    [Required]
    public string Name { get; init; }

    public bool IsActive { get; init; }
};
