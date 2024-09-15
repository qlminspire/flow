using Flow.Application.Models.BankDeposit;
using Flow.Domain.BankDeposits;
using Flow.Domain.Users;

namespace Flow.Infrastructure.Services;

internal sealed class BankDepositService : IBankDepositService
{
    private readonly BankDepositMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public BankDepositService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _mapper = new BankDepositMapper();
    }

    public async Task<BankDepositDto> GetAsync(Guid userId, Guid bankDepositId,
        CancellationToken cancellationToken = default)
    {
        var bankDeposit = await _unitOfWork.BankDeposits.GetForUserAsync(new UserId(userId),
                              new BankDepositId(bankDepositId), cancellationToken)
                          ?? throw new NotFoundException(bankDepositId);

        return _mapper.Map(bankDeposit);
    }

    public async Task<List<BankDepositDto>> GetAllAsync(Guid userId, CancellationToken cancellationToken)
    {
        var banks = await _unitOfWork.BankDeposits.GetAllForUserAsync(new UserId(userId), cancellationToken);
        return _mapper.Map(banks);
    }

    public async Task<BankDepositDto> CreateAsync(Guid userId, CreateBankDepositDto createBankDepositDto,
        CancellationToken cancellationToken = default)
    {
        var bankDeposit = BankDeposit.Create();

        _unitOfWork.BankDeposits.Create(bankDeposit.Value);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var depositDto = _mapper.Map(bankDeposit.Value);
        return depositDto;
    }
}