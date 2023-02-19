using AutoMapper;

using Flow.Api.Models.AccountOperation;
using Flow.Business.Models.AccountOperation;
using Flow.Entities;

namespace Flow.Api.Mappings;

internal sealed class AccountOperationProfile: Profile
{
    public AccountOperationProfile()
    {
        CreateMap<AccountOperation, AccountOperationDto>();
        CreateMap<CreateAccountOperationDto, AccountOperation>();
    }
}
