using Domain.Entity;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Configurations;

internal class PermissionConfiguration: IEntityTypeConfiguration<Permission>
{
    public void Configure(EntityTypeBuilder<Permission> builder)
    {
        builder.ToTable("Permission");
        builder.HasKey(e => new { e.Id });
        builder.Property(e => e.Id).ValueGeneratedOnAdd();

        builder.HasData(
               new Permission { Id = 1, PermissionCode = "User.View", PermissionText = "User", Created = DateTime.UtcNow, Updated = DateTime.UtcNow },
               new Permission { Id = 2, PermissionCode = "User.Create", PermissionText = "User", Created = DateTime.UtcNow, Updated = DateTime.UtcNow },
               new Permission { Id = 3, PermissionCode = "User.Remove", PermissionText = "User", Created = DateTime.UtcNow, Updated = DateTime.UtcNow },
               new Permission { Id = 4, PermissionCode = "Tenant.View", PermissionText = "Tenant", Created = DateTime.UtcNow, Updated = DateTime.UtcNow },
               new Permission { Id = 5, PermissionCode = "Tenant.Create", PermissionText = "Tenant", Created = DateTime.UtcNow, Updated = DateTime.UtcNow },
               new Permission { Id = 6, PermissionCode = "Tenant.Remove", PermissionText = "Tenant", Created = DateTime.UtcNow, Updated = DateTime.UtcNow },
               new Permission { Id = 7, PermissionCode = "Role.View", PermissionText = "Role", Created = DateTime.UtcNow, Updated = DateTime.UtcNow },
               new Permission { Id = 8, PermissionCode = "Role.Create", PermissionText = "Role", Created = DateTime.UtcNow, Updated = DateTime.UtcNow },
               new Permission { Id = 9, PermissionCode = "Role.Remove", PermissionText = "Role", Created = DateTime.UtcNow, Updated = DateTime.UtcNow });

    }
}
