using AutoMapper;
using Flow.Application.Models.AccountOperation;
using Flow.Domain.Entities;

namespace Flow.Api.Mappings;

internal sealed class AccountOperationProfile : Profile
{
    public AccountOperationProfile()
    {
        CreateMap<AccountOperation, AccountOperationDto>();
    }
}
