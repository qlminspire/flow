using Flow.Application.Models.Debt;

namespace Flow.Infrastructure.Services;

internal sealed class DebtService : IDebtService
{
    private readonly DebtMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public DebtService(IUnitOfWork unitOfWork)
    {
        ArgumentNullException.ThrowIfNull(unitOfWork);

        _unitOfWork = unitOfWork;
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
        var currency = await _unitOfWork.Currencies.GetByIdAsync(createDebtDto.CurrencyId, cancellationToken);
        if (currency is null)
            throw new ValidationException();

        var debt = _mapper.Map(createDebtDto);
        debt.UserId = userId;

        _unitOfWork.Debts.Create(debt);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return _mapper.Map(debt);
    }
}