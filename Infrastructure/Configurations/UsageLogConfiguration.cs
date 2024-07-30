using Domain.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Configurations;


public class UsageLogConfiguration : IEntityTypeConfiguration<UserLog>
{
    public void Configure(EntityTypeBuilder<UserLog> builder)
    {
        builder.ToTable("UsageLog");
        builder.HasKey(e => new { e.UserId });
        builder.Property(e => e.UserId).ValueGeneratedOnAdd();
    }
}
