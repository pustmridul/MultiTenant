using Domain.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Infrastructure.Configurations;


public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
{
    public void Configure(EntityTypeBuilder<UserRole> builder)
    {
        builder.ToTable("UserRole");
        builder.HasKey(e => new { e.Id });
        builder.Property(e => e.Id).ValueGeneratedOnAdd();


        builder.HasOne(e => e.Role)
          .WithMany(e => e.UserRoles)
          .HasForeignKey(e => e.RoleId)
          .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(e => e.User)
          .WithMany(e => e.UserRoles)
          .HasForeignKey(e => e.UserId)
          .OnDelete(DeleteBehavior.NoAction);

    }
}
