using Flow.Application.Models.Bank;
using Flow.Domain.Banks;

namespace Flow.Infrastructure.Services;

internal sealed class BankService : IBankService
{
    private readonly BankMapper _mapper;
    private readonly TimeProvider _timeProvider;
    private readonly IUnitOfWork _unitOfWork;

    public BankService(IUnitOfWork unitOfWork, TimeProvider timeProvider)
    {
        ArgumentNullException.ThrowIfNull(unitOfWork);

        _unitOfWork = unitOfWork;
        _timeProvider = timeProvider;
        _mapper = new BankMapper();
    }

    public async Task<BankDto> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var bank = await _unitOfWork.Banks.GetByIdAsync(id, cancellationToken)
                   ?? throw new NotFoundException();

        return _mapper.Map(bank);
    }

    public async Task<List<BankDto>> GetAsync(CancellationToken cancellationToken = default)
    {
        var banks = await _unitOfWork.Banks.GetAllAsync(cancellationToken);
        return _mapper.Map(banks);
    }

    public async Task<BankDto> CreateAsync(CreateBankDto createBankDto, CancellationToken cancellationToken = default)
    {
        var createDate = _timeProvider.GetUtcNow().UtcDateTime;
        var bankName = BankName.Create(createBankDto.Name);

        var bankResult = Bank.Create(bankName.Value, createDate);
        var bank = bankResult.Value;

        _unitOfWork.Banks.Create(bank);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return _mapper.Map(bank);
    }

    public async Task ActivateAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var bank = await _unitOfWork.Banks.GetByIdAsync(id, cancellationToken)
                   ?? throw new NotFoundException();

        var activationDate = _timeProvider.GetUtcNow().UtcDateTime;
        bank.Activate(activationDate);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task DeactivateAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var bank = await _unitOfWork.Banks.GetByIdAsync(id, cancellationToken)
                   ?? throw new NotFoundException();

        var deactivationDate = _timeProvider.GetUtcNow().UtcDateTime;
        bank.Deactivate(deactivationDate);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var bank = await _unitOfWork.Banks.GetByIdAsync(id, cancellationToken)
                   ?? throw new NotFoundException();

        _unitOfWork.Banks.Delete(bank);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public Task<bool> ExistsAsync(string name, CancellationToken cancellationToken = default)
    {
        var bankName = BankName.Create(name);
        return _unitOfWork.Banks.ExistsAsync(x => x.Name == bankName.Value, cancellationToken);
    }
}