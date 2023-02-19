﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

using Flow.Business.Models.BankDeposit;
using Flow.DataAccess.Contracts;
using Flow.Entities;
using Flow.Entities.Core.Exceptions;

namespace Flow.Business.Services.Implementations;

internal class BankDepositService : IBankDepositService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public BankDepositService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<BankDepositDto> GetAsync(Guid userId, Guid depositId, CancellationToken cancellationToken = default)
    {
        var bankDeposit = await _unitOfWork.BankDeposits.GetByCondition(x => x.UserId == userId && x.Id == depositId, true)
             .Include(x => x.Currency)
             .Include(x => x.RefundAccount)
             .ProjectTo<BankDepositDto>(_mapper.ConfigurationProvider)
             .FirstOrDefaultAsync(cancellationToken);

        return bankDeposit ?? throw new BankDepositNotFoundException(userId, depositId);
    }

    public Task<List<BankDepositDto>> GetAllAsync(Guid userId, CancellationToken cancellationToken)
    {
        return _unitOfWork.BankDeposits.GetByCondition(x => x.UserId == userId, true)
            .Include(x => x.Currency)
            .Include(x => x.RefundAccount)
            .ProjectTo<BankDepositDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }

    public async Task<BankDepositDto> CreateAsync(Guid userId, CreateBankDepositDto createBankDepositDto, CancellationToken cancellationToken = default)
    {
        var bankDeposit = _mapper.Map<BankDeposit>(createBankDepositDto);
        bankDeposit.UserId = userId;

        _unitOfWork.BankDeposits.Create(bankDeposit);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var depositDto = _mapper.Map<BankDepositDto>(bankDeposit);
        return depositDto;
    }
}
