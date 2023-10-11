using Flow.Application.Models.AccountOperation;

namespace Flow.Infrastructure.Services;

internal sealed class AccountOperationService : IAccountOperationService
{
    private readonly IUnitOfWork _unitOfWork;

    private readonly AccountOperationMapper _mapper;

    public AccountOperationService(IUnitOfWork unitOfWork)
    {
        ArgumentNullException.ThrowIfNull(unitOfWork, nameof(unitOfWork));

        _unitOfWork = unitOfWork;
        _mapper = new();
    }

    public async Task<AccountOperationDto> CreateAsync(Guid userId, CreateAccountOperationDto createAccountOperationDto, CancellationToken cancellationToken)
    {
        var accountOperation = _mapper.Map(createAccountOperationDto);

        _unitOfWork.AccountOperations.Create(accountOperation);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return _mapper.Map(accountOperation);
    }
}
