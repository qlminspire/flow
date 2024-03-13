using Flow.Application.Models.Debt;
using Flow.Domain.Currencies;
using Flow.Domain.Debts;

namespace Flow.Infrastructure.Services;

internal sealed class DebtService : IDebtService
{
    private readonly DebtMapper _mapper;
    private readonly TimeProvider _timeProvider;
    private readonly IUnitOfWork _unitOfWork;

    public DebtService(IUnitOfWork unitOfWork, TimeProvider timeProvider)
    {
        ArgumentNullException.ThrowIfNull(unitOfWork);

        _unitOfWork = unitOfWork;
        _timeProvider = timeProvider;
        _mapper = new DebtMapper();
    }

    public async Task<DebtDto> GetAsync(Guid userId, Guid debtId, CancellationToken cancellationToken = default)
    {
        var debt = await _unitOfWork.Debts.GetForUserAsync(userId, debtId, cancellationToken)
                   ?? throw new NotFoundException(nameof(debtId), debtId.ToString());

        return _mapper.Map(debt);
    }

    public async Task<List<DebtDto>> GetAllAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        var debts = await _unitOfWork.Debts.GetAllForUserAsync(userId, cancellationToken);
        return _mapper.Map(debts);
    }

    public async Task<DebtDto> CreateAsync(Guid userId, CreateDebtDto createDebtDto,
        CancellationToken cancellationToken = default)
    {
        var currencyCode = CurrencyCode.Create(createDebtDto.Currency);

        var user = await _unitOfWork.Users.GetByIdAsync(userId, cancellationToken);

        var currency = await _unitOfWork.Currencies.GetByCurrencyCodeAsync(currencyCode.Value, cancellationToken);
        if (currency is null)
            throw new ValidationException();

        var debtName = DebtName.Create(createDebtDto.Name);
        var amount = Money.Create(createDebtDto.Amount);
        var createdAt = _timeProvider.GetUtcNow().UtcDateTime;

        var debt = Debt.Create(user, debtName.Value, amount.Value, currency, createdAt);

        _unitOfWork.Debts.Create(debt.Value);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return _mapper.Map(debt.Value);
    }
}