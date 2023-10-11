using Riok.Mapperly.Abstractions;

using Flow.Api.Contracts.Requests.CashAccount;
using Flow.Api.Contracts.Responses.CashAccount;
using Flow.Application.Models.CashAccount;

namespace Flow.Api.Mappings;

[Mapper]
internal partial class CashAccountMapper
{
    public partial CashAccountResponse Map(CashAccountDto cashAccountDto);
    //  .ForMember(dest => dest.Currency, opt => opt.MapFrom(src => src.Currency.Code));

    public partial ICollection<CashAccountResponse> Map(ICollection<CashAccountDto> cashAccountsDto);

    public partial CreateCashAccountDto Map(CreateCashAccountRequest createCashAccountRequest);
}
