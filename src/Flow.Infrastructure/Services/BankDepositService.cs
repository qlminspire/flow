using Flow.Application.Models.BankDeposit;

namespace Flow.Infrastructure.Services;

internal class BankDepositService : IBankDepositService
{
    private readonly BankDepositMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public BankDepositService(IUnitOfWork unitOfWork)
    {
        ArgumentNullException.ThrowIfNull(unitOfWork);

        _unitOfWork = unitOfWork;
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
        var bankDeposit = _mapper.Map(createBankDepositDto);
        bankDeposit.UserId = userId;

        _unitOfWork.BankDeposits.Create(bankDeposit);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var depositDto = _mapper.Map(bankDeposit);
        return depositDto;
    }
}