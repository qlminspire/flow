using AutoMapper;
using AutoMapper.QueryableExtensions;
using Flow.Application.Common.Exceptions;
using Flow.Application.Models.Debt;
using Flow.Application.Persistence;
using Flow.Application.Services;
using Flow.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Flow.Infrastructure.Services;

internal sealed class DebtService : IDebtService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DebtService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<DebtDto> GetAsync(Guid userId, Guid debtId, CancellationToken cancellationToken = default)
    {
        var debt = await _unitOfWork.Debts.GetByCondition(x => x.UserId == userId && x.Id == debtId, true)
            .Include(x => x.Currency)
            .ProjectTo<DebtDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);
        return debt ?? throw new AccountNotFoundException(userId, debtId);
    }

    public Task<List<DebtDto>> GetAllAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        return _unitOfWork.Debts.GetByCondition(x => x.UserId == userId, false)
            .Include(x => x.Currency)
            .ProjectTo<DebtDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }

    public async Task<DebtDto> CreateAsync(Guid userId, CreateDebtDto createDto, CancellationToken cancellationToken = default)
    {
        var debt = _mapper.Map<Debt>(createDto);
        debt.UserId = userId;

        _unitOfWork.Debts.Create(debt);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var currency = await _unitOfWork.Currencies.GetByCondition(x => x.Id == debt.CurrencyId)
            .FirstAsync(CancellationToken.None);
        debt.Currency = currency;

        return _mapper.Map<DebtDto>(debt);
    }
}
