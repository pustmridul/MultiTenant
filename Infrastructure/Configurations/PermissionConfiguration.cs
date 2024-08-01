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
               new Permission { Id = 1, PermissionCode = "User.View",  PermissionText= "User",Created= DateTime.UtcNow, Updated= DateTime.UtcNow},
               new Permission { Id = 2, PermissionCode = "User.Create", PermissionText = "User", Created = DateTime.UtcNow, Updated = DateTime.UtcNow },
               new Permission { Id = 3, PermissionCode = "User.Remove", PermissionText = "User", Created = DateTime.UtcNow, Updated = DateTime.UtcNow }
           // Add more role-permission relationships as needed
           );


    }
}
