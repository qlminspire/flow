using Flow.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Flow.DataAccess.Configurations;

internal sealed class UserIncomeConfiguration : IEntityTypeConfiguration<UserIncome>
{
    public void Configure(EntityTypeBuilder<UserIncome> builder)
    {
       builder.HasOne(x => x.Account).WithOne().OnDelete(DeleteBehavior.Cascade);
    }
}
