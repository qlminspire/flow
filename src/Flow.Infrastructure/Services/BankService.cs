using AutoMapper;
using Flow.Application.Contracts.Persistence;
using Flow.Application.Contracts.Services;
using Flow.Application.Exceptions;
using Flow.Application.Models.Bank;
using Flow.Domain.Entities;

namespace Flow.Infrastructure.Services;

internal sealed class BankService : IBankService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public BankService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<BankDto> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var bank = await _unitOfWork.Banks.GetByIdAsync(id, cancellationToken)
            ?? throw new NotFoundException();
        return _mapper.Map<BankDto>(bank);
    }

    public async Task<List<BankDto>> GetAsync(CancellationToken cancellationToken = default)
    {
        var banks = await _unitOfWork.Banks.GetAllAsync(cancellationToken);
        return _mapper.Map<List<BankDto>>(banks);
    }

    public async Task<BankDto> CreateAsync(CreateBankDto dto, CancellationToken cancellationToken = default)
    {
        var bank = _mapper.Map<Bank>(dto);

        _unitOfWork.Banks.Create(bank);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return _mapper.Map<BankDto>(bank);
    }

    public async Task UpdateAsync(Guid id, UpdateBankDto dto, CancellationToken cancellationToken = default)
    {
        var existingBank = await _unitOfWork.Banks.GetByIdAsync(id, cancellationToken) ?? throw new NotFoundException();

        _mapper.Map(dto, existingBank);

        _unitOfWork.Banks.Update(existingBank);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var existingBank = await _unitOfWork.Banks.GetByIdAsync(id, cancellationToken) ?? throw new NotFoundException();

        _unitOfWork.Banks.Delete(existingBank);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public Task<bool> ExistsAsync(string name, CancellationToken cancellationToken = default)
    {
        return _unitOfWork.Banks.ExistsAsync(x => x.Name == name, cancellationToken);
    }
}