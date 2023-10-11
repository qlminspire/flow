using Flow.Application.Models.Debt;

namespace Flow.Infrastructure.Services;

internal sealed class DebtService : IDebtService
{
    private readonly IUnitOfWork _unitOfWork;

    private readonly DebtMapper _mapper;

    public DebtService(IUnitOfWork unitOfWork)
    {
        ArgumentNullException.ThrowIfNull(unitOfWork, nameof(unitOfWork));

        _unitOfWork = unitOfWork;

        _mapper = new DebtMapper();
    }

    public async Task<DebtDto> GetAsync(Guid userId, Guid debtId, CancellationToken cancellationToken = default)
    {
        var debt = await _unitOfWork.Debts.GetByIdAsync(debtId, cancellationToken)
            ?? throw new NotFoundException(nameof(debtId), debtId.ToString());

        return _mapper.Map(debt);
    }

    public async Task<List<DebtDto>> GetAllAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        var debts = await _unitOfWork.Debts.GetAsync(x => x.UserId == userId, cancellationToken);
        return _mapper.Map(debts);
    }

    public async Task<DebtDto> CreateAsync(Guid userId, CreateDebtDto createDto, CancellationToken cancellationToken = default)
    {
        var debt = _mapper.Map(createDto);
        debt.UserId = userId;

        _unitOfWork.Debts.Create(debt);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var currency = await _unitOfWork.Currencies.GetByIdAsync(debt.CurrencyId, CancellationToken.None);
        debt.Currency = currency;

        return _mapper.Map(debt);
    }
}
