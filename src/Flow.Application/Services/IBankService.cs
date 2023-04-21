using Flow.Application.Common;
using Flow.Application.Models.Bank;

using OneOf;
using OneOf.Types;

namespace Flow.Application.Services;

public interface IBankService
{
    Task<OneOf<BankDto, NotFound>> GetAsync(Guid id, CancellationToken cancellationToken = default);

    Task<List<BankDto>> GetAsync(CancellationToken cancellationToken = default);

    Task<OneOf<BankDto, ValidationFailed>> CreateAsync(CreateBankDto dto, CancellationToken cancellationToken = default);

    Task<OneOf<Success, NotFound, ValidationFailed>> UpdateAsync(Guid id, UpdateBankDto dto, CancellationToken cancellationToken = default);

    Task<OneOf<Success, NotFound>> DeleteAsync(Guid id, CancellationToken cancellationToken = default);

    Task<bool> ExistsAsync(string name, CancellationToken cancellationToken = default);
}
