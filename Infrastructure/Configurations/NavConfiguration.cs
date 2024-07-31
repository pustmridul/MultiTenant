using Domain.Entity;
namespace Infrastructure.Configurations;


public class NavConfiguration : IEntityTypeConfiguration<Nav>
{
    public void Configure(EntityTypeBuilder<Nav> builder)
    {
        builder.ToTable("Nav");
        builder.HasKey(e => new { e.Id });
        builder.Property(e => e.Id).ValueGeneratedOnAdd();

        builder.HasMany(n => n.Children)
           .WithOne()
           .HasForeignKey(n => n.ParentId);
    }
}
