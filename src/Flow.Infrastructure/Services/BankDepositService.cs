using Flow.Application.Contracts.Persistence;
using Flow.Application.Contracts.Services;
using Flow.Application.Exceptions;
using Flow.Application.Mapperly;
using Flow.Application.Models.BankDeposit;

namespace Flow.Infrastructure.Services;

internal class BankDepositService : IBankDepositService
{
    private readonly IUnitOfWork _unitOfWork;

    private readonly BankDepositMapper _mapper;

    public BankDepositService(IUnitOfWork unitOfWork)
    {
        ArgumentNullException.ThrowIfNull(unitOfWork, nameof(unitOfWork));

        _unitOfWork = unitOfWork;

        _mapper = new BankDepositMapper();
    }

    public async Task<BankDepositDto> GetAsync(Guid userId, Guid depositId, CancellationToken cancellationToken = default)
    {
        var bankDeposit = await _unitOfWork.BankDeposits.GetByIdAsync(depositId, cancellationToken)
            ?? throw new NotFoundException();
        return _mapper.Map(bankDeposit);
    }

    public async Task<List<BankDepositDto>> GetAllAsync(Guid userId, CancellationToken cancellationToken)
    {
        var banks = await _unitOfWork.BankDeposits.GetAsync(x => x.UserId == userId, cancellationToken);
        return _mapper.Map(banks);
    }

    public async Task<BankDepositDto> CreateAsync(Guid userId, CreateBankDepositDto createBankDepositDto, CancellationToken cancellationToken = default)
    {
        var bankDeposit = _mapper.Map(createBankDepositDto);
        bankDeposit.UserId = userId;

        _unitOfWork.BankDeposits.Create(bankDeposit);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var depositDto = _mapper.Map(bankDeposit);
        return depositDto;
    }
}
