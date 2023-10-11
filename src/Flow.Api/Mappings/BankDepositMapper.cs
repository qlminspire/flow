using Flow.Api.Contracts.Requests.BankDeposit;
using Flow.Api.Contracts.Responses.BankDeposit;
using Flow.Api.Contracts.Responses.CashAccount;
using Flow.Application.Models.BankDeposit;
using Flow.Application.Models.CashAccount;
using Riok.Mapperly.Abstractions;

namespace Flow.Api.Mappings;

[Mapper]
internal partial class BankDepositMapper
{
    public partial BankDepositResponse Map(BankDepositDto bankDepositDto);
    // .ForMember(dest => dest.Currency, opt => opt.MapFrom(src => src.Currency.Code));

    public partial ICollection<BankDepositResponse> Map(ICollection<BankDepositDto> bankDepositsDto);

    public partial CreateBankDepositDto Map(CreateBankDepositRequest createBankDepositRequest);
}
