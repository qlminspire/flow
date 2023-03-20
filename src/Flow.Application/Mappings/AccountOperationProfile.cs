using AutoMapper;
using Flow.Application.Models.AccountOperation;
using Flow.Domain.Entities;

namespace Flow.Application.Mappings;

internal sealed class AccountOperationProfile : Profile
{
    public AccountOperationProfile()
    {
        CreateMap<AccountOperation, AccountOperationDto>();
        CreateMap<CreateAccountOperationDto, AccountOperation>();
    }
}
