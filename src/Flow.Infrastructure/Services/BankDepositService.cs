using Flow.Application.Models.BankDeposit;
using Flow.Domain.BankDeposits;

namespace Flow.Infrastructure.Services;

internal class BankDepositService : IBankDepositService
{
    private readonly BankDepositMapper _mapper;
    private readonly TimeProvider _timeProvider;
    private readonly IUnitOfWork _unitOfWork;

    public BankDepositService(IUnitOfWork unitOfWork, TimeProvider timeProvider)
    {
        ArgumentNullException.ThrowIfNull(unitOfWork);

        _unitOfWork = unitOfWork;
        _timeProvider = timeProvider;
        _mapper = new BankDepositMapper();
    }

    public async Task<BankDepositDto> GetAsync(Guid userId, Guid bankDepositId,
        CancellationToken cancellationToken = default)
    {
        var bankDeposit = await _unitOfWork.BankDeposits.GetForUserAsync(userId, bankDepositId, cancellationToken)
                          ?? throw new NotFoundException();

        return _mapper.Map(bankDeposit);
    }

    public async Task<List<BankDepositDto>> GetAllAsync(Guid userId, CancellationToken cancellationToken)
    {
        var banks = await _unitOfWork.BankDeposits.GetAllForUserAsync(userId, cancellationToken);
        return _mapper.Map(banks);
    }

    public async Task<BankDepositDto> CreateAsync(Guid userId, CreateBankDepositDto createBankDepositDto,
        CancellationToken cancellationToken = default)
    {
        // TODO: DO THE REST

        var bankDeposit = BankDeposit.Create();

        _unitOfWork.BankDeposits.Create(bankDeposit.Value);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var depositDto = _mapper.Map(bankDeposit.Value);
        return depositDto;
    }
}