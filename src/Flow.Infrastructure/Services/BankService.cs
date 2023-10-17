using Flow.Application.Models.Bank;

namespace Flow.Infrastructure.Services;

internal sealed class BankService : IBankService
{
    private readonly IUnitOfWork _unitOfWork;

    private readonly BankMapper _mapper;

    public BankService(IUnitOfWork unitOfWork)
    {
        ArgumentNullException.ThrowIfNull(unitOfWork);

        _unitOfWork = unitOfWork;
        _mapper = new();
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
        var bank = _mapper.Map(createBankDto);

        _unitOfWork.Banks.Create(bank);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return _mapper.Map(bank);
    }

    public async Task UpdateAsync(Guid id, UpdateBankDto updateBankDto, CancellationToken cancellationToken = default)
    {
        var bank = await _unitOfWork.Banks.GetByIdAsync(id, cancellationToken)
            ?? throw new NotFoundException();

        _mapper.Map(updateBankDto, bank);

        _unitOfWork.Banks.Update(bank);
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
        return _unitOfWork.Banks.ExistsAsync(x => x.Name == name, cancellationToken);
    }
}