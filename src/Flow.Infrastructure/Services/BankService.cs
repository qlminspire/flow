﻿using Flow.Application.Models.Bank;
using Flow.Domain.Banks;

namespace Flow.Infrastructure.Services;

internal sealed class BankService : IBankService
{
    private readonly BankMapper _mapper;
    private readonly TimeProvider _timeProvider;
    private readonly IUnitOfWork _unitOfWork;

    public BankService(IUnitOfWork unitOfWork, TimeProvider timeProvider)
    {
        _unitOfWork = unitOfWork;
        _timeProvider = timeProvider;
        _mapper = new BankMapper();
    }

    public async Task<BankDto> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var bank = await _unitOfWork.Banks.GetByIdAsync(id, cancellationToken)
                   ?? throw new NotFoundException();

        return _mapper.Map(bank);
    }

    public async Task<List<BankDto>> GetAsync(CancellationToken cancellationToken = default)
    {
        var banks = await _unitOfWork.Banks.GetAllAsync(cancellationToken);
        return _mapper.Map(banks);
    }

    public async Task<BankDto> CreateAsync(CreateBankDto createBankDto, CancellationToken cancellationToken = default)
    {
        var name = BankName.Create(createBankDto.Name);
        var createdAt = _timeProvider.GetUtcNow().UtcDateTime;

        var bank = Bank.Create(name.Value, createdAt);

        _unitOfWork.Banks.Create(bank.Value);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return _mapper.Map(bank.Value);
    }

    public async Task ActivateAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var bank = await _unitOfWork.Banks.GetByIdAsync(id, cancellationToken)
                   ?? throw new NotFoundException();

        var activatedAt = _timeProvider.GetUtcNow().UtcDateTime;
        bank.Activate(activatedAt);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task DeactivateAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var bank = await _unitOfWork.Banks.GetByIdAsync(id, cancellationToken)
                   ?? throw new NotFoundException();

        var deactivatedAt = _timeProvider.GetUtcNow().UtcDateTime;
        bank.Deactivate(deactivatedAt);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var bank = await _unitOfWork.Banks.GetByIdAsync(id, cancellationToken)
                   ?? throw new NotFoundException();

        _unitOfWork.Banks.Delete(bank);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public Task<bool> ExistsAsync(string name, CancellationToken cancellationToken = default)
    {
        var bankName = BankName.Create(name);
        return _unitOfWork.Banks.ExistsAsync(x => x.Name == bankName.Value, cancellationToken);
    }
}