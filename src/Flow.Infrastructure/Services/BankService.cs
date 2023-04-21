using AutoMapper;
using AutoMapper.QueryableExtensions;
using Flow.Application.Common;
using Flow.Application.Common.Exceptions;
using Flow.Application.Models.Bank;
using Flow.Application.Persistence;
using Flow.Application.Services;
using Flow.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using OneOf;
using OneOf.Types;

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

    public async Task<OneOf<BankDto, NotFound>> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var bank = await _unitOfWork.Banks.GetByCondition(x => x.Id == id).ProjectTo<BankDto>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(cancellationToken);

        return bank != null ? bank : new NotFound();
    }

    public Task<List<BankDto>> GetAsync(CancellationToken cancellationToken = default)
    {
        return _unitOfWork.Banks.GetAll().ProjectTo<BankDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);
    }

    public async Task<OneOf<BankDto, ValidationFailed>> CreateAsync(CreateBankDto dto, CancellationToken cancellationToken = default)
    {
        var existingBank = await _unitOfWork.Banks.GetByCondition(x => x.Name == dto.Name).FirstOrDefaultAsync(cancellationToken);
        if (existingBank != null)
            return new ValidationFailed("The bank with same name already exists.");

        var bank = _mapper.Map<Bank>(dto);

        _unitOfWork.Banks.Create(bank);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return _mapper.Map<BankDto>(bank);
    }

    public async Task<OneOf<Success, NotFound, ValidationFailed>> UpdateAsync(Guid id, UpdateBankDto dto, CancellationToken cancellationToken = default)
    {
        var existingBank = await _unitOfWork.Banks.GetByCondition(x => x.Id == id, true).FirstOrDefaultAsync(cancellationToken);
        if (existingBank == null)
            return new NotFound();

        _mapper.Map(dto, existingBank);

        _unitOfWork.Banks.Update(existingBank);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return new Success();
    }

    public async Task<OneOf<Success, NotFound>> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var existingBank = await _unitOfWork.Banks.GetByCondition(x => x.Id == id, true).FirstOrDefaultAsync(cancellationToken);
        if (existingBank == null)
            return new NotFound();

        _unitOfWork.Banks.Delete(existingBank);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return new Success();
    }

    public Task<bool> ExistsAsync(string name, CancellationToken cancellationToken = default)
    {
        return _unitOfWork.Banks.GetByCondition(x => x.Name == name).AnyAsync(cancellationToken);
    }
}