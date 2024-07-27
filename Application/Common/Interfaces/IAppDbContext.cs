
namespace Application.Common.Interfaces
{
    public interface IAppDbContext
    {
        DbSet<User> Users { get; }
        DbSet<PaymentMethod> PaymentMethods { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
