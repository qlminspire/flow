using AutoMapper;
using Flow.Application.Contracts.Persistence;
using Flow.Application.Contracts.Services;
using Flow.Application.Exceptions;
using Flow.Application.Models.Debt;
using Flow.Domain.Entities;

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
        var debt = await _unitOfWork.Debts.GetByIdAsync(debtId, cancellationToken)
            ?? throw new NotFoundException(nameof(debtId), debtId.ToString());
        return _mapper.Map<DebtDto>(debt);
    }

    public async Task<List<DebtDto>> GetAllAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        var debts = await _unitOfWork.Debts.GetAsync(x => x.UserId == userId, cancellationToken);
        return _mapper.Map<List<DebtDto>>(debts);
    }

    public async Task<DebtDto> CreateAsync(Guid userId, CreateDebtDto createDto, CancellationToken cancellationToken = default)
    {
        var debt = _mapper.Map<Debt>(createDto);
        debt.UserId = userId;

        _unitOfWork.Debts.Create(debt);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var currency = await _unitOfWork.Currencies.GetByIdAsync(debt.CurrencyId, CancellationToken.None);
        debt.Currency = currency;

        return _mapper.Map<DebtDto>(debt);
    }
}
