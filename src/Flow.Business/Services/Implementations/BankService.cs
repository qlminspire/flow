using AutoMapper;
using AutoMapper.QueryableExtensions;

using Microsoft.EntityFrameworkCore;

using Flow.Business.Models.Bank;
using Flow.DataAccess.Contracts;
using Flow.Entities;
using Flow.Entities.Core.Exceptions;
using System.Security.Cryptography;

namespace Flow.Business.Services.Implementations;

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
        var bank = await _unitOfWork.Banks.GetByCondition(x => x.Id == id).ProjectTo<BankDto>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(cancellationToken);

        return bank ?? throw new BankNotFoundException(id);
    }

    public Task<List<BankDto>> GetAsync(CancellationToken cancellationToken = default)
    {
        return _unitOfWork.Banks.GetAll().ProjectTo<BankDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);
    }

    public async Task<BankDto> CreateAsync(CreateBankDto dto, CancellationToken cancellationToken = default)
    {
        var existingBank = await _unitOfWork.Banks.GetByCondition(x => x.Name == dto.Name).FirstOrDefaultAsync(cancellationToken);
        if (existingBank != null)
            throw new DuplicatePreventionException();

        var bank = _mapper.Map<Bank>(dto);

        _unitOfWork.Banks.Create(bank);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return _mapper.Map<BankDto>(bank);
    }

    public async Task UpdateAsync(Guid id, UpdateBankDto dto, CancellationToken cancellationToken = default)
    {
        var existingBank = await _unitOfWork.Banks.GetByCondition(x => x.Id == id, true).FirstOrDefaultAsync(cancellationToken);
        if (existingBank == null)
            throw new BankNotFoundException(id);

        _mapper.Map(dto, existingBank);

        _unitOfWork.Banks.Update(existingBank);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var existingBank = await _unitOfWork.Banks.GetByCondition(x => x.Id == id, true).FirstOrDefaultAsync(cancellationToken);
        if (existingBank == null)
            throw new BankNotFoundException(id);

        _unitOfWork.Banks.Delete(existingBank);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public Task<bool> ExistsAsync(string name, CancellationToken cancellationToken = default)
    {
        return _unitOfWork.Banks.GetByCondition(x => x.Name == name).AnyAsync(cancellationToken);
    }
}
