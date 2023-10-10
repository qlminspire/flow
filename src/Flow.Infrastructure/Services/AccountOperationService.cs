using AutoMapper;
using Flow.Application.Contracts.Persistence;
using Flow.Application.Contracts.Services;
using Flow.Application.Models.AccountOperation;

using Flow.Domain.Entities;

namespace Flow.Infrastructure.Services;

internal sealed class AccountOperationService : IAccountOperationService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public AccountOperationService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<AccountOperationDto> CreateAsync(Guid userId, CreateAccountOperationDto createAccountOperationDto, CancellationToken cancellationToken)
    {
        var accountOperation = _mapper.Map<AccountOperation>(createAccountOperationDto);

        _unitOfWork.AccountOperations.Create(accountOperation);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return _mapper.Map<AccountOperationDto>(accountOperation);
    }
}
