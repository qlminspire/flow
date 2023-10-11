using Flow.Application.Models.Bank;

namespace Flow.Infrastructure.Services;

internal sealed class BankService : IBankService
{
    private readonly IUnitOfWork _unitOfWork;

    private readonly BankMapper _mapper;

    public BankService(IUnitOfWork unitOfWork)
    {
        ArgumentNullException.ThrowIfNull(unitOfWork, nameof(unitOfWork));

        _unitOfWork = unitOfWork;
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

    public async Task<BankDto> CreateAsync(CreateBankDto dto, CancellationToken cancellationToken = default)
    {
        var bank = _mapper.Map(dto);

        _unitOfWork.Banks.Create(bank);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return _mapper.Map(bank);
    }

    public async Task UpdateAsync(Guid id, UpdateBankDto dto, CancellationToken cancellationToken = default)
    {
        var existingBank = await _unitOfWork.Banks.GetByIdAsync(id, cancellationToken)
            ?? throw new NotFoundException();

        _mapper.Map(existingBank, dto);

        _unitOfWork.Banks.Update(existingBank);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var existingBank = await _unitOfWork.Banks.GetByIdAsync(id, cancellationToken)
            ?? throw new NotFoundException();

        _unitOfWork.Banks.Delete(existingBank);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public Task<bool> ExistsAsync(string name, CancellationToken cancellationToken = default)
    {
        return _unitOfWork.Banks.ExistsAsync(x => x.Name == name, cancellationToken);
    }
}