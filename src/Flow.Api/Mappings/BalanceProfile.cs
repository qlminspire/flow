﻿using AutoMapper;
using Flow.Api.Contracts.Responses.Balance;
using Flow.Application.Models.Balance;

namespace Flow.Api.Mappings;

internal sealed class BalanceProfile : Profile
{
    public BalanceProfile()
    {
        CreateMap<BalanceDto, BalanceResponse>();
        CreateMap<CalculatedBalanceDto, CalculatedBalanceResponse>();
    }
}
